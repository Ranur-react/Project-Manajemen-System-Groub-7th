using API.Base;
using API.Models;
using API.Models.FormModel;
using API.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employee, EmployeeRepository, String>
    {
        private readonly EmployeeRepository employeeRepository;
        public IConfiguration _Configuration;
        public EmployeesController(EmployeeRepository employeeRepository, IConfiguration configuration) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            this._Configuration = configuration;
        }
        [Route("Find")]
        [HttpPost]
        public ActionResult Find(KeyForm Key)
        {

            try
            {
                var result = employeeRepository.Find(Key);
                
                    return Ok(result);
                
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errorMessage = e.Message });


            }
        }
    }
}
