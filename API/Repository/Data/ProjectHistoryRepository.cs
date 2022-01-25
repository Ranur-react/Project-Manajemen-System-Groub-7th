using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class ProjectHistoryRepository : GeneralRepository<MyContext, ProjectHistory, int>
    {
        public ProjectHistoryRepository(MyContext myContext) : base(myContext)
        {
            
        }
    }
}
