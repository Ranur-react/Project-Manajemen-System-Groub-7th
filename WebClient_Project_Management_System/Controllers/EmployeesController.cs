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
    public class EmployeesController : BaseController<Employee, EmployeeRepository, String>
    {
        private readonly EmployeeRepository EmployeeRepository;

        public EmployeesController(EmployeeRepository repository) : base(repository)
        {
            this.EmployeeRepository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
