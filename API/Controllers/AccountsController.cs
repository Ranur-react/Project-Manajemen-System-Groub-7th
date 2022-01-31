using API.Base;
using API.Models;
using API.Models.FormModel;
using API.Models.ViewModel;
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
        public ActionResult Login(LoginForm loginVM)
        {
            try
            {
                var result = accountRepository.Login(loginVM);
                if(result > 0)
                {
                    if(result == 3)
                    {
                        return BadRequest(new RequestLoginsForms { status = StatusCodes.Status400BadRequest, result=result, message = "Password salah" });
                    }

                    if(result == 2)
                    {
                        return BadRequest(new RequestLoginsForms { status = StatusCodes.Status400BadRequest, result=result, message = "Username tidak ditemukan" });
                    }

                    else
                    {
                        // return Ok("Login Berhasil");
                        var get = accountRepository.Registered(loginVM.Username).Role;

                        var role = "";


                        role = get.Name;
                        var data = new LoginForm
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
                        return Ok(new RequestLoginsForms { status = StatusCodes.Status200OK, idToken = idToken, result = result, message = "Login Berhasil" });
                        //return Ok(new RequestLoginsForms { status = HttpStatusCode.OK, IdToken = idToken, Result = result, Message = "Login Berhasil" });

                    }
                }
                else
                {
                    return BadRequest(new RequestLoginsForms { status = StatusCodes.Status400BadRequest, result = result, message = "Login Gagal, Akun tidak ditemukan" });

                }
            }
            catch (Exception e)
            {
                return BadRequest(new RequestLoginsForms { status = StatusCodes.Status417ExpectationFailed, errors = e.Message + "~Login Controller" });
            }
        }
        [Route("RegisteredData")]
        [HttpGet]
        public ActionResult RegisteredData()
        {

            try
            {
                var result = accountRepository.RegisteredData();
                if (result.Count() > 0)
                {
                    return Ok(new { Status = StatusCodes.Status200OK, Results = result, Message = $" {result.Count()} Data Berhasil Didapatkan " });
                }
                else
                {
                    return BadRequest(new { status = StatusCodes.Status204NoContent, result, message = $"tidak ada indikasi data ditemukan di [{ControllerContext.ActionDescriptor.ControllerName}] silahkan tambah data" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errorMessage = e.Message });
            }
        }
        [Route("Register")]
        [HttpPost]
        public ActionResult Register(FormRegister entity)
        {
            try
            {
                var result = accountRepository.Register(entity);
                switch (result)
                {
                    case 1:
                        //return Ok(new { status = StatusCodes.Status201Created, result, message = $"Data Berhasil Tersimpan ke [{ControllerContext.ActionDescriptor.ControllerName}]" });
                     return Ok(result);
                    case 2:
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = "Pastikan  Email Belum Pernah Digunakan" });
                    case 3:
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = "Pastikan Nomor Handphone Milikmu atau Belum Pernah Digunakan " });
                    default:
                        //return BadRequest(result);
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = $" Data gagal Ditambahkan Sudah ada di dalam database [{ControllerContext.ActionDescriptor.ControllerName}]" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errors = e.Message });
            }
        }
        [Route("Forgot")]
        [HttpPost]
        public ActionResult Forgot(MailForm mailForm)
        {
            try
            {
                var result = accountRepository.ForgotPassword(mailForm);
                if (result > 0)
                {
                    if (result == 2)
                    {
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = "Akun tidak ditemukan, email / phonsell yang digunakan tidak terdaftar didatabase " });
                    }
                    else if (result == 3)
                    {
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = "OTP Gagal Dikirimkan ke Email mu, ulangi" });
                    }
                    else
                    {
                        return Ok(new { status = StatusCodes.Status201Created, result, message = "OTP Dikirimkan ke Email mu, Periksa Kotak Masuk atau folder SPAM di Email mu" });
                    }
                }
                else
                {
                    return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = $" Data gagal Ditambahkan Sudah ada di dalam database" });
                }

            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errors = e.Message });
            }
        }
        [Route("ChangePassword")]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordForm cForm)
        {
            try
            {
                var result = accountRepository.ChangePassword(cForm);
                if (result > 0)
                {
                    if (result == 2)
                    {
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = "Token Sudah digunakan, Kirim Token ulang" });
                    }
                    else if (result == 3)
                    {
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = "Token Sudah kadaluarsa, Kirim Token ulang" });
                    }
                    else if (result == 4)
                    {
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = "Token Salah , Check kembali atau coba kirim ulang" });
                    }
                    else
                    {
                        //panggil Mail sender disini
                        return Ok(new { status = StatusCodes.Status201Created, result, message = "Token benar, Password sudah berhasil dirubah" });
                    }
                }
                else
                {
                    return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = $" Data gagal diproses Sudah ada di dalam database" });
                }

            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errors = e.Message + "~Controller" });
            }
        }


    }
}
