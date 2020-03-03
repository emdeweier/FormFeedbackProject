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
    [Table("TB_M_Options")]
    public class Option : BaseModel
    {
        public string O_Name { get; set; }
    }
}
