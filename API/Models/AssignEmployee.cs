using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_T_AssignEmployees")]
    public class AssignEmployee
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Project")]
        public String IdProject { get; set; }
        public ProgressStatus Status_Assign { get; set; }
        [ForeignKey("Employee")]
        public String IdEmployee { get; set; }
        public String Position { get; set; }

        [JsonIgnore]
        public virtual Employee employee { get; set; }

        public virtual Project Project { get; set; }

        

    }


}
