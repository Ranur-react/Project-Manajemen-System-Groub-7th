using API.Models;
using API.Models.FormModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClient_Project_Management_System.Base;
using WebClient_Project_Management_System.Repositories.Data;

namespace WebClient_Project_Management_System.Controllers
{
    [Authorize]
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
        [HttpPost]
        public IActionResult EmployeeListAdd(KeyForm Key)
        {
            ViewBag.IdProject = Key.Id;
            return View();
        }
        [HttpPost]
        public ActionResult<Object> Find(KeyForm entity)
        {
            var result = EmployeeRepository.Find(entity);
            try
            {

                return Json(result);

            }
            catch (Exception e)
            {

                return Json(new { Message = e.Message });
            }
        }
    }
}
