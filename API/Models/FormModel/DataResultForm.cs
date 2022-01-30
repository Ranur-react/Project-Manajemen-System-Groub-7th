using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.FormModel
{
    public class DataResultForm
    {
        public int status { get; set; }
        public Object result { get; set; }
        public String message { get; set; }
        public String errors { get; set; }
    }
}
