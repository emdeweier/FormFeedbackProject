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
        [Key]
        public string Id { get; set; }
        public string Answer { get; set; }
        public string Note { get; set; }
        public string QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
        public string PointId { get; set; }
        [ForeignKey("PointId")]
        public Point Point { get; set; }

        public Feedback() { }

        public void Create()
        {
            CreateDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
