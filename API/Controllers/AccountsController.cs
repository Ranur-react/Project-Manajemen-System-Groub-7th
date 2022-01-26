using API.Base;
using API.Models;

using API.Repository.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Account, AccountRepository, int>
    {
        private readonly AccountRepository accountRepository;
        public IConfiguration _Configuration;

        public AccountsController(AccountRepository accountRepository,IConfiguration configuration) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this._Configuration = configuration;
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
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = "Password salah" });
                    }

                    if(result == 2)
                    {
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = "Username tidak ditemukan" });
                    }

                    else
                    {
                        // return Ok("Login Berhasil");
                        var get = accountRepository.RegisteredData(loginVM.Username).Role;

                        var role = "";


                        role = get.Name;
                        var data = new LoginVM
                        {
                            Username = loginVM.Username,
                            Role = role
                        };
                        var calaims = new List<Claim> {
                            new Claim("Username",data.Username),
                        };
                       
                        calaims.Add(new Claim("roles", get.Name));
                        
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _Configuration["Jwt:Issuer"],
                            _Configuration["Jwt:Audience"],
                            calaims,
                            expires: DateTime.UtcNow.AddMinutes(10),
                            signingCredentials: signIn

                            );
                        var idToken = new JwtSecurityTokenHandler().WriteToken(token);
                        calaims.Add(new Claim("TokenSecurity", idToken.ToString()));

                        return Ok(new  { Status = HttpStatusCode.OK, IdToken = idToken, Result = result, Message = "Login Berhasil" });

                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errors = e.Message + "~Login Controller" });
            }
        }

    }
}
