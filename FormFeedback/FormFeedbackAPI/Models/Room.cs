using FormFeedbackAPI.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Models
{
    [Table("TB_M_Room")]
    public class Room : BaseModel
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Floor { get; set; }
    }
}
