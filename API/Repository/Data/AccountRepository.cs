using API.Context;
using API.Models;
using API.Models.FormModel;
using API.ViewModel;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class AccountRepository: GeneralRepository<MyContext, Account, int>
    {
        private readonly MyContext myContext;
        public AccountRepository(MyContext myContext) : base(myContext) {
            this.myContext = myContext;
        }

        public Account Registered(string param)
        {
            var dataAccount = CheckDataAccount(CheckDataEmployee(param).Id);
            return dataAccount;
        }

        public Account CheckDataAccount(String param)
        {
            var respond = myContext.Accounts.Where(e => e.Username == param ).FirstOrDefault();
            return respond;
        }

        public Employee CheckDataEmployee(String param)
        {
            var respond = myContext.Employees.Where(e => e.Id == param || e.Email == param || e.Phone == param).FirstOrDefault();
            return respond;
        }

     
        public IEnumerable<Employee> GetEmployee()
        {
            return myContext.Employees.ToList(); //Get data from Employee Entity
        }
        public IEnumerable<Object> RegisteredData()
        {

            //one record relationable data
            var qry = from emp in myContext.Employees
                      join act in myContext.Accounts
                         on emp.Id equals act.Username
                      join rol in myContext.Roles
                         on act.RoleId equals rol.Id
                      select new FormRegister
                      {
                          Id = emp.Id,
                          FullName = emp.FirstName + ",  " + emp.LastName,
                          FirstName = emp.FirstName,
                          LastName = emp.LastName,
                          Phone = emp.Phone,
                          Gender = emp.Gender,
                          Email = emp.Email,
                          BirthDate = emp.BirthDate,
                          Avatar = act.Avatar,
                          RoleId = rol.Id,
                          RoleName = rol.Name
                      };
            return qry;


        }
        public int Register(FormRegister registerForm) //use postman  to test
        {
            var Id = registerForm.Id;
            if (Id == null)
            {
                int countE = this.GetEmployee().Count();
                if (countE != 0)
                {
                    string MaxE = this.GetEmployee().Max(e => e.Id);
                    Id = (Int32.Parse(MaxE) + 1).ToString();
                }
                else
                {
                    var empCount = countE + 1;
                    var Year = DateTime.Now.Year;
                    Id = $"{Year}0{empCount.ToString()}";

                }
            }

            var checkEmailPhone = CheckEmailAndPhone(registerForm);
            if (checkEmailPhone != 1)
            {
                return checkEmailPhone;
            }
            else
            {
                var emp = new Employee
                {
                    Id = Id,
                    FirstName = registerForm.FirstName,
                    LastName = registerForm.LastName,
                    Phone = registerForm.Phone,
                    BirthDate = registerForm.BirthDate,
                    Email = registerForm.Email,
                    Gender = registerForm.Gender
                };
                myContext.Employees.Add(emp);
                myContext.SaveChanges();
                var roleId = 1;
                var act = new Account
                {
                    Username = emp.Id,
                    Password = BCrypt.Net.BCrypt.HashPassword(registerForm.Password),
                    RoleId = roleId,
                    Status = 0,
                    Avatar = registerForm.Avatar
                };
                myContext.Accounts.Add(act);
                myContext.SaveChanges();
                return 1;
            }

        }
        public int CheckEmailAndPhone(FormRegister employee)
        {
            var checkEmail = myContext.Employees.Where(e => e.Email == employee.Email).FirstOrDefault();
            if (checkEmail != null)
            {
                return 2;
            }
            else
            {
                var checkPhone = myContext.Employees.Where(e => e.Phone == employee.Phone).FirstOrDefault();
                if (checkPhone != null)
                {
                    return 3;
                }
                else
                {
                    return 1;
                }
            }
        }
        public int CheckPhone(FormRegister employee)
        {
            var checkPhone = myContext.Employees.Where(e => e.Phone == employee.Phone).FirstOrDefault();
            if (checkPhone != null)
            {
                return 3;
            }
            else
            {
                return 1;
            }
        }
        public int CheckEmail(FormRegister employee)
        {
            var checkEmail = myContext.Employees.Where(e => e.Email == employee.Email).FirstOrDefault();
            if (checkEmail != null)
            {
                return 2;
            }
            else
            {
                return 1;
            }

        }

        public int Login(LoginForm loginVM)
        {
            var ce = CheckDataEmployee(loginVM.Username);
            if (ce != null)
            {

                var checkUsername = CheckDataAccount(ce.Id);

                /*var checkUsername = myContext.Accounts.
                    Where(e => e.Username == loginVM.Username || e.Username == loginVM.Username).FirstOrDefault();*/

                if (checkUsername != null)
                {
                    var getPassword = myContext.Accounts.Where(e => e.Username == checkUsername.Username).FirstOrDefault();
                    bool checkPassword = BCrypt.Net.BCrypt.Verify(loginVM.Password, getPassword.Password);
                    //     bool checkPassword = loginVM.Password == getPassword.Password ;
                    if (checkPassword)
                    {
                        return 1;
                    }
                    else
                    {
                        return 3;
                    }
                }
                else
                {
                    return 2;
                }
            }
            else {
                return 0;
            }
        }
        public int ForgotPassword(MailForm mailForm)
        {
            var checkEmail = CheckDataEmployee(mailForm.Email);
            if (checkEmail != null)
            {
                // 1. buat token
                var tokenGenerate = GenerateToken();
                var checkAccount = CheckDataAccount(checkEmail.Id);
                if (checkAccount != null)
                {
                    myContext.Entry(checkAccount).State = EntityState.Detached;
                }

                checkAccount.OTP = tokenGenerate;
                // 2. buat waktu kadaluarsa
                var timeNow = DateTime.Now.AddMinutes(5);
                checkAccount.ExpiredToken = timeNow;
                checkAccount.IsUsed = true;
                // 3. Simpan ke database
                myContext.Entry(checkAccount).State = EntityState.Modified;
                var dbRespond = myContext.SaveChanges();
                // 4. buat konten / element dari email yang akan diri
                var mailContent = new MailContent
                {
                    Email = checkEmail.Email,
                    TimeNow = timeNow,
                    Token = tokenGenerate,
                    body = $"{checkEmail.LastName},{checkEmail.FirstName} "
                };
                //panggil Mail sender disini
                var respond = SendMail(mailContent);

                switch (respond)
                {
                    case 1:
                        return dbRespond;
                    default:
                        return 3;
                }
            }
            else
            {
                return 2;

            }
        }
        public int GenerateToken()
        {
            int _min = 111111;
            int _max = 999999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
        public int SendMail(MailContent mailContent)
        {
            try
            {
                MimeMessage message = new MimeMessage();

                MailboxAddress from = new MailboxAddress("noreply",
                "dumy@gunungmas-seluler.com");
                message.From.Add(from);

                MailboxAddress to = new MailboxAddress(mailContent.body,
                mailContent.Email);
                message.To.Add(to);

                message.Subject = "OTP Lupa Password";
                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = $"<h2>OTP : {mailContent.Token}</h2>" +
                    $"<br>" +
                    $"<p align=\"center\">Masukan OTP di halaman ganti password sebelum {mailContent.TimeNow} agar password anda dapat anda ganti</p>";
                message.Body = bodyBuilder.ToMessageBody();

                SmtpClient client = new SmtpClient();
                client.Connect("mail.gunungmas-seluler.com", 465, true);
                client.Authenticate("dumy@gunungmas-seluler.com", "Dumy0@@@");
                client.Send(message);
                client.Disconnect(true);
                client.Dispose();
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public int ChangePassword(ChangePasswordForm cForm)
        {
            try
            {
                var dataAccount = Registered(cForm.Email);
                if (dataAccount.OTP != cForm.OTP)
                {
                    return 4;
                }
                else
                {
                    if (dataAccount.ExpiredToken < DateTime.Now)
                    {
                        return 3;
                    }
                    else
                    {
                        if (!dataAccount.IsUsed)
                        {
                            return 2;
                        }
                        else
                        {
                            if (dataAccount != null)
                            {
                                myContext.Entry(dataAccount).State = EntityState.Detached;
                            }

                            dataAccount.Password = BCrypt.Net.BCrypt.HashPassword(cForm.Password);
                            dataAccount.IsUsed = false;
                            myContext.Entry(dataAccount).State = EntityState.Modified;
                            return myContext.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }

        }
    }
}
