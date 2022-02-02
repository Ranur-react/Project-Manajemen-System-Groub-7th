using API.Context;
using API.Models;
using API.Models.FormModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class ProjectRepository : GeneralRepository<MyContext, Project, String>
    {
        private readonly MyContext myContext;
        public ProjectRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        public Project GetById(KeyForm key)
        {
            return myContext.Projects.Find(key.Id);
        }
    }
}
