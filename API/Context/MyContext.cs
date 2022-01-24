using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        public DbSet<Account> Accounts{ get; set; }
        public DbSet<Employee> Employees{ get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AssignEmployee> AssignEmployees { get; set; }
        public DbSet<DevelopTask> DevelopTasks { get; set; }
        public DbSet<Progress> Progresses { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectHistory> ProjectHistorys { get; set; }
        public DbSet<TestingTask> TestTasks{ get; set; }
    }
}
