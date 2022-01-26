using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_M_Accounts")]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        public String Password { get; set; }
        [ForeignKey("Employee")]
        [Required(ErrorMessage = "it must have a value")]
        public String Username { get; set; }
        public Status Status { get; set; }
        public DateTime ExpiredToken { get; set; }
        public DateTime Last_online { get; set; }
        public String Avatar { get; set; }
        public int OTP { get; set; }
        public Boolean IsUsed { get; set; }
        public virtual Role Role { get; set; }
        [JsonIgnore]
        public virtual Employee Employee { get; set; }
    }

}
public enum Status
{
    enable,
    disable,
    limited

}


