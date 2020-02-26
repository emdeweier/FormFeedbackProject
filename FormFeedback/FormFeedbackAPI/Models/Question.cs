using FormFeedbackAPI.Bases;
using FormFeedbackAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Models
{
    [Table("TB_M_Questions")]
    public class Question : BaseModel
    {
        [Key]
        public string Id { get; set; }
        public string Q_Name { get; set; }
        public string Type { get; set; }
        public string OptionId { get; set; }
        [ForeignKey("OptionId")]
        public Option Option { get; set; }
    }
}
