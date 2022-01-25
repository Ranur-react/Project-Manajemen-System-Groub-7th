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
    public class AssignEmployeesController : BaseController<AssignEmployee, AssignEmployeeRepository, int>
    {
        private readonly AssignEmployeeRepository assignEmployeeRepository;

        public AssignEmployeesController(AssignEmployeeRepository assignEmployeeRepository): base(assignEmployeeRepository)
        {
            this.assignEmployeeRepository = assignEmployeeRepository;
        }
    }
}
