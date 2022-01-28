using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.FormModel
{
    public class MailContent
    {
        public int Token { get; set; }
        public DateTime TimeNow { get; set; }
        public String Email { get; set; }
        public String body { get; set; }
    }
}
