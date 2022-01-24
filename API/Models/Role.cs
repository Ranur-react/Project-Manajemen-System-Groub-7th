using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_M_Roles")]
    public class Role
    {
        [Key]
        [Required(ErrorMessage = "it must have a value")]
        public int Id { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        public String Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
