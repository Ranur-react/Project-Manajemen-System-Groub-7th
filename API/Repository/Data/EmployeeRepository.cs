using API.Context;
using API.Models;
using API.Models.FormModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<MyContext, Employee, String>
    {
        private readonly MyContext myContext;

        public EmployeeRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;

        }
        

        public Employee Find(KeyForm Key)
        {
            String param = Key.Id;
            var respond = myContext.Employees.Where(e => e.Id == param || e.Email == param || e.Phone == param).FirstOrDefault();
            return respond;
        }
    }
}
