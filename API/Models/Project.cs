using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_M_Projects")]
    public class Project
    {
        [Key]
        [Required(ErrorMessage = "it must have a value")]
        public String Id { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        public String Name { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        public DateTime AssignDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Details{ get; set; }

       
        public ICollection<ProjectHistory> ProjectHistory { get; set; }

        [JsonIgnore]
        public ICollection<AssignEmployee> AssignEmployee { get; set; }
    }
}
