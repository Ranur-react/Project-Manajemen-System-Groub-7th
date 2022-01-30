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
    public class AssignEmployeesController : BaseController<AssignEmployee, AssignEmployeeRepository, int>
    {
        private readonly AssignEmployeeRepository assignEmployeeRepository;

        public AssignEmployeesController(AssignEmployeeRepository repository) : base(repository)
        {
            this.assignEmployeeRepository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
