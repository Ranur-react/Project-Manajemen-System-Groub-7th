using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_M_Employees")]
    public class Employee
    {
        [Key]
        [Required(ErrorMessage = "it must have a value")]
        public String Id { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        public String FirstName { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        public String LastName { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        [EmailAddress(ErrorMessage = "it's must as Email value, please rechek your typing value, use @ symbol for representations domain after mailName")]
        public String Email { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        [Phone(ErrorMessage = "It's must as Phone number , pelease check your value")]
        public String Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public virtual Account Accounts{ get; set; }

    }

}
public enum Gender
{
    Male,
    Female
}

