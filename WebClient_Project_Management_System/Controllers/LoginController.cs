using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient_Project_Management_System.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index(string src)
        {

            ViewData["src"] = src;
            ViewData["WelComeTitle"] = src == null ? "Sign In" : "Relogin";
            return View();
        }
    }
}
