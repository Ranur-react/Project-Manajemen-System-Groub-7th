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
    public class ProjectHistorysController : BaseController<ProjectHistory, ProjectHistoryRepository, int>
    {
        private readonly ProjectHistoryRepository ProjectHistoryRepository;

        public ProjectHistorysController(ProjectHistoryRepository repository) : base(repository)
        {
            this.ProjectHistoryRepository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
