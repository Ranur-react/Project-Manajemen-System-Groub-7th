using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.ViewModel
{
    public class FormProgress
    {
   
        public String ColorCode { get; set; }
        public String Name { get; set; }
        public String ProgresDetails { get; set; }
        public DateTime DateEntry { get; set; }
  
        public String Approver { get; set; }

        public ProgressStatus ProgressStatus { get; set; }
        public String IdProject { get; set; }


    }
}
