using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClient_Project_Management_System.Base;
using WebClient_Project_Management_System.Repositories.Data;

namespace WebClient_Project_Management_System.Controllers
{
    public class ProjectsController : BaseController<Project, ProjectRepository, int>
    {
        private readonly ProjectRepository projectRepository;

        public ProjectsController(ProjectRepository repository) : base(repository)
        {
            this.projectRepository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
