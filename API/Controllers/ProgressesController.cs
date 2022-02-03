using API.Base;
using API.Models;
using API.Models.ViewModel;
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
    public class ProgressesController : BaseController<Progress, ProgressRepository, int>
    {
        private readonly ProgressRepository progressRepository;

        public ProgressesController(ProgressRepository progressRepository):base(progressRepository)
        {
            this.progressRepository = progressRepository;
        }

        [Route("AddProgress")]
        [HttpPost]
        public ActionResult AddProgress(FormProgress entity)
        {
            try
            {
                var result = progressRepository.RequestRequirement(entity);
                switch (result)
                {
                    case 1:
                        
                        return Ok(result);
                    
                    default:
                        
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = $" Data gagal Ditambahkan Sudah ada di dalam database [{ControllerContext.ActionDescriptor.ControllerName}]" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errors = e.Message });
            }
        }
    }
}
