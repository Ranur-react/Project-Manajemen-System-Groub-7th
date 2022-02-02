using API.Models;
using API.Models.FormModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebClient_Project_Management_System.Base;
using WebClient_Project_Management_System.Models;
using WebClient_Project_Management_System.Repositories.Data;

namespace WebClient_Project_Management_System.Controllers
{
    public class ProjectsController : BaseController<Project, ProjectRepository, String>
    {
        private readonly ProjectRepository projectRepository;

        public ProjectsController(ProjectRepository repository) : base(repository)
        {
            this.projectRepository = repository;
        }
        [HttpPost]
        public async Task<JsonResult> GetById(KeyForm Key)
        {
            var result = await projectRepository.GetById(Key);
            return Json(result);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ModalProjects(int id)
        {
            return PartialView("~/Views/Employees/index.cshtml");
        }
        [HttpGet]
        public IActionResult ProjectDetails(String id)
        {
                ViewBag.IdProject= id;
            return View();
        }


        [HttpPost]
        public IActionResult Add (Project entity)
        {
            var result =  projectRepository.Post(entity);
            return RedirectToAction("index", "Projects",new { status= result });
        }

    }
}
