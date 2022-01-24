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
    }
}
