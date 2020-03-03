using FormFeedbackAPI.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Models
{
    [Table("TB_R_Reports")]
    public class Report : BaseModel
    {
        public int FeedbackId { get; set; }
        public string TotalPoint { get; set; }
        public string Result { get; set; }
        [ForeignKey("FeedbackId")]
        public Feedback Feedback { get; set; }
    }
}
