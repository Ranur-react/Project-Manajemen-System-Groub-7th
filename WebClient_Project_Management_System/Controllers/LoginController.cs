using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient_Project_Management_System.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index(string returnUrl)
        {

            ViewData["returnUrl"] = returnUrl;
            ViewData["WelComeTitle"] = returnUrl == null ? "Login" : "Relogin";

            return View();
        }
    }
}
