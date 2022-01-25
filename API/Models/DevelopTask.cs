using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_T_DevelopTasks")]
    public class DevelopTask
    {
        [Key]
        [Required(ErrorMessage = "it must have a value")]
        public int Id { get; set; }
        [ForeignKey("Progress")]
        public int IdProgres { get; set; }
        public String TaskName { get; set; }
        public DateTime DateEntry { get; set; }
        [ForeignKey("Employee")]
        public String Worker { get; set; }
        public DateTime DeadLine { get; set; }
        public StatusTask StatusTask { get; set; }
        public String Details { get; set; }

        [JsonIgnore]
        public virtual Progress Progress { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<TestingTask> TestingTask { get; set; }

        
    }
}

public enum StatusTask
{
    Todo,
    InProgress,
    Debugging,
    Done,

}
