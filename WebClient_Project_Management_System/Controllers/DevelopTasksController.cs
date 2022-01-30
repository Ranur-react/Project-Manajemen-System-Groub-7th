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
    public class DevelopTasksController : BaseController<DevelopTask, DevelopTaskRepository, int>
    {
        private readonly DevelopTaskRepository developTaskRepository;

        public DevelopTasksController(DevelopTaskRepository repository) : base(repository)
        {
            this.developTaskRepository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
