using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_T_TestTasks")]
    public class TestingTask
    {
        [Key]
        [Required(ErrorMessage = "it must have a value")]
        public int Id { get; set; }
        [ForeignKey("DevelopTask")]
        public int IdTask { get; set; }
        public String Details { get; set; }
        public DateTime DateTest { get; set; }
        [ForeignKey("Employee")]
        public String Tester { get; set; }
        public TestTask TestStatus { get; set; }

        [JsonIgnore]
        public virtual DevelopTask DevelopTask { get; set; }

        public virtual Employee Employee { get; set; }


    }
}

public enum TestTask
{
    Testing,
    Running,
    Bug
}
