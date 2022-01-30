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
    public class TestingTasksController : BaseController<TestingTask, TestingTaskRepository, int>
    {
        private readonly TestingTaskRepository testingTaskRepository;

        public TestingTasksController(TestingTaskRepository repository) : base(repository)
        {
            this.testingTaskRepository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
