using API.Base;
using API.Models;
using API.Models.FormModel;
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
    public class ProjectsController : BaseController<Project, ProjectRepository, String>
    {
        private readonly ProjectRepository projectRepository;

        public ProjectsController(ProjectRepository projectRepository): base(projectRepository)
        {
            this.projectRepository = projectRepository;
        }
        [HttpPost("GetById")]
        public ActionResult<Project> GetById(KeyForm key)
        {
            try
            {
                var result = projectRepository.Get(key.Id);
                if (result != null)
                {
                    return Ok(result);
                    // return Ok(new { status = StatusCodes.Status200OK, result, message = $" Data Berhasil Didapatkan dengan parameter {key}" });
                }
                else
                {
                    return Ok(result);
                    //return BadRequest(new { status = StatusCodes.Status204NoContent, result, message = $"tidak ada indikasi data ditemukan di [{ControllerContext.ActionDescriptor.ControllerName}] dengan paramter {key}" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errorMessage = e.Message });

            }
        }

        
    }
}
