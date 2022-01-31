using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class LoginForm
    {
        public string Username { get; set; }
    
        public string Password { get; set; }

        public String Role { get; set; }
    }
}
