using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_M_Progress")]
    public class Progress
    {
        [Key]
        public int Id { get; set; }
        public String ColorCode { get; set; }
        public String Name { get; set; }
        public String ProgresDetails { get; set; }
        public DateTime DateEntry { get; set; }
        [ForeignKey("Employee")]
        public String Approver { get; set; }
        
        public ProgressStatus ProgressStatus { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProjectHistory> ProjectHistory { get; set; }

        public virtual ICollection<DevelopTask> DevelopTask { get; set; }

        public virtual Employee Employee { get; set; }

    }

}

public enum ProgressStatus
{
    Initialization,
    Requirement,
    BusinessDesign,
    DesignSystem,
    DatabaseDesign,
    UxUiDesign,
    Developing,
    Testing,
    Deploying,
    Done,
}
