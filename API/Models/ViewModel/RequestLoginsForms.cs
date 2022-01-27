using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.ViewModel
{
    public class RequestLoginsForms
    {
        public int status { get; set; }
        public String idToken { get; set; }
        public int result { get; set; }
        public String message { get; set; }
        public String errors { get; set; }
    }
}
