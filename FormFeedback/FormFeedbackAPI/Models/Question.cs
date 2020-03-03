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
        public string Q_Name { get; set; }
        public string Type { get; set; }
        public int OptionId { get; set; }
    }
}
