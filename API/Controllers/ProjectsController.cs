using API.Base;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : BaseController<Project, ProjectRepository, String>
    {
        private readonly ProjectRepository projectRepository;

        public ProjectsController(ProjectRepository projectRepository): base(projectRepository)
        {
            this.projectRepository = projectRepository;
        }
    }
}
