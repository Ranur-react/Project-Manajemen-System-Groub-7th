using API.Base;
using API.Models;
using API.Models.FormModel;
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
        [Route("RegisteredData")]
        [HttpGet]
        public ActionResult RegisteredData()
        {

            try
            {
                var result = accountRepository.RegisteredData();
                if (result.Count() > 0)
                {
                       return Ok(new  { Status = StatusCodes.Status200OK, Results = result, Message = $" {result.Count()} Data Berhasil Didapatkan " });
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
                        return Ok(new { status = StatusCodes.Status201Created, result, message = $"Data Berhasil Tersimpan ke [{ControllerContext.ActionDescriptor.ControllerName}]" });
                        // return Ok(result);
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
        [HttpPost("Login")]
        public ActionResult Login(LoginVM loginVM)
        {
            try
            {
                var result = accountRepository.Login(loginVM);
                if (result > 0)
                {
                    if (result == 3)
                    {
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = "Akun ditemukan,Password salah" });
                    }

                    if (result == 2)
                    {
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = "Akun tidak ditemukan, email yang digunakan tidak terdaftar didatabase " });
                    }

                    else
                    {
                        return Ok(new { status = StatusCodes.Status201Created,  result, message = "Login Berhasil" });
                    }
                }
                else
                {
                    return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = $" Data gagal Ditambahkan Sudah ada di dalam database" });
                }
            }
            catch(Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errors = e.Message + "~Login Controller" });
            }
        }
    }
}
