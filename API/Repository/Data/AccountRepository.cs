using API.Context;
using API.Models;
using API.Models.FormModel;
using API.ViewModel;
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
                var act = new Account
                {
                    Username = emp.Id,
                    Password = BCrypt.Net.BCrypt.HashPassword(registerForm.Password),
                    RoleId = registerForm.RoleId,
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

        public int Login(LoginVM loginVM)
        {
            var checkUsername = CheckDataAccount(CheckDataEmployee(loginVM.Username).Id);

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
    }
}
