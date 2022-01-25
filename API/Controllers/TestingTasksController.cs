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
    public class TestingTasksController : BaseController<TestingTask, TestingTaskRepository, int>
    {
        private readonly TestingTaskRepository testingTaskRepository;

        public TestingTasksController(TestingTaskRepository testingTaskRepository):base(testingTaskRepository)
        {
            this.testingTaskRepository = testingTaskRepository;
        }
    }
}
