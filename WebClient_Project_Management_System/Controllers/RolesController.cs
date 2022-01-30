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
    public class RolesController : BaseController<Role, RoleRepository, int>
    {
        private readonly RoleRepository roleRepository;

        public RolesController(RoleRepository repository) : base(repository)
        {
            this.roleRepository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
