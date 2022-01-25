using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class ProjectRepository : GeneralRepository<MyContext, Project, int>
    {
        public ProjectRepository(MyContext myContext) : base(myContext)
        {
            
        }
    }
}
