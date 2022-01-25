using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class DevelopTaskRepository : GeneralRepository<MyContext, DevelopTask, int>
    {
        public DevelopTaskRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
