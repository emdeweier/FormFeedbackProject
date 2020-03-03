using FormFeedbackAPI.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Models
{
    [Table("TB_T_Feedback")]
    public class Feedback : BaseModel
    {
        public string Answer { get; set; }
        public string Note { get; set; }
        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
        public int PointId { get; set; }
        [ForeignKey("PointId")]
        public Point Point { get; set; }
    }
}
