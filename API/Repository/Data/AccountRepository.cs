using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class AccountRepository: GeneralRepository<MyContext, Account, int>
    {
        public AccountRepository(MyContext myContext) : base(myContext) { }
    }
}
