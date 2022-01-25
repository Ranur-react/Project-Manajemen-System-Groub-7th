using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class AssignEmployeeRepository : GeneralRepository<MyContext, AssignEmployee, int>
    {
        public AssignEmployeeRepository(MyContext myContext) : base(myContext)
        {
            
        }
    }
}
