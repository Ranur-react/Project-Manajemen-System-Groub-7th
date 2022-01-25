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
    public class ProgressesController : BaseController<Progress, ProgressRepository, int>
    {
        private readonly ProgressRepository progressRepository;

        public ProgressesController(ProgressRepository progressRepository):base(progressRepository)
        {
            this.progressRepository = progressRepository;
        }
    }
}
