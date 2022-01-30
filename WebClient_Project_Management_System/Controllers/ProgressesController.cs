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
    public class ProgressesController : BaseController<Progress, ProgressRepository, int>
    {
        private readonly ProgressRepository ProgressRepository;

        public ProgressesController(ProgressRepository repository) : base(repository)
        {
            this.ProgressRepository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
