using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_T_ProjectHistorys")]
    public class ProjectHistory
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Project")]
        public String IdProject  { get; set; }
        [ForeignKey("Progress")]
        public int IdProgres { get; set; }

        [JsonIgnore]
        public virtual Project Project { get; set; }
        public virtual Progress Progress { get; set; }
        
    }
}
