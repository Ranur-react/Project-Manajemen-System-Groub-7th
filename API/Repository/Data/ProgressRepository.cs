using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class ProgressRepository : GeneralRepository<MyContext, Progress, int>
    {
        public ProgressRepository(MyContext myContext) : base(myContext)
        {
            
        }
    }
}
