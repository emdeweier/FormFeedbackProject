using FormFeedbackAPI.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Models
{
    [Table("TB_M_Points")]
    public class Point : BaseModel
    {
        public int Value { get; set; }
        public string Note { get; set; }
    }
}
