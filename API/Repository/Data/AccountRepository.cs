using API.Context;
using API.Models;
using API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class AccountRepository: GeneralRepository<MyContext, Account, int>
    {
        private readonly MyContext myContex;
        public AccountRepository(MyContext myContext) : base(myContext) {
            this.myContex = myContext;
        }

        public Account RegisteredData(string param)
        {
            var dataAccount = CheckDataAccount(CheckDataEmployee(param).Id);
            return dataAccount;
        }

        public Account CheckDataAccount(String param)
        {
            var respond = myContex.Accounts.Find(param);
            return respond;
        }

        public Employee CheckDataEmployee(String param)
        {
            var respond = myContex.Employees.Where(e => e.Id == param || e.Email == param || e.Phone == param).FirstOrDefault();
            return respond;
        }

        public int Login(LoginVM loginVM)
        {
            var checkUsername = myContex.Accounts.
                Where(e => e.Username == loginVM.Username || e.Username == loginVM.Username).FirstOrDefault();
            if (checkUsername != null)
            {
                var getPassword = myContex.Accounts.Where(e => e.Username == checkUsername.Username).FirstOrDefault();
             //   bool checkPassword = BCrypt.Net.BCrypt.Verify(loginVM.Password, getPassword.Password);
                  bool checkPassword = loginVM.Password == getPassword.Password ;
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
