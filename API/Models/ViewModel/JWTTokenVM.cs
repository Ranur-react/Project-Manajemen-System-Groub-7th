using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Models.ViewModel
{
    public class JWTTokenVM
    {
        public HttpStatusCode Status { get; set; }
        public string IdToken { get; set; }
        public int Result { get; set; }
        public String Message { get; set; }
    }
}
