using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.FormModel
{
    public class FormRegister
    {
        public String Id { get; set; }
        public String FullName { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        public String FirstName { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        public String LastName { get; set; }
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        [EmailAddress(ErrorMessage = "it's must as Email value, please rechek your typing value, use @ symbol for representations domain after mailName")]
        public String Email { get; set; }
        public DateTime BirthDate { get; set; }
        [Phone(ErrorMessage = "It's must as Phone number , pelease check your value")]
        public String Phone { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        public int RoleId{ get; set; }
        [Required(ErrorMessage = "it must have a value")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8}$",
         ErrorMessage = "Password must have minimum one lowwer case and one uppercase and also 8 digit length of all chracters")]
        public virtual String Password { get; set; }
        public String RoleName { get; set; }
        public String Avatar { get; set; }

    }
}
