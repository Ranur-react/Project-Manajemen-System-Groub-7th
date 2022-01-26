using API.Base;
using API.Models;
using API.Repository.Data;
using API.ViewModel;
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
    public class AccountsController : BaseController<Account, AccountRepository, int>
    {
        private readonly AccountRepository accountRepository;

        public AccountsController(AccountRepository accountRepository) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpPost("Login")]
        public ActionResult Login(LoginVM loginVM)
        {
            try
            {
                var result = accountRepository.Login(loginVM);
                if(result > 0)
                {
                    if(result == 3)
                    {
                        return BadRequest();
                    }

                    if(result == 2)
                    {
                        return BadRequest();
                    }

                    else
                    {
                        return Ok("Login Berhasil");
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
