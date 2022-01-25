using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class TestingTaskRepository : GeneralRepository<MyContext, TestingTask, int>
    {
        public TestingTaskRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
