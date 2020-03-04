using FormFeedbackAPI.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Models
{
    [Table("TB_T_Events")]
    public class Event : BaseModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int PresentatorId { get; set; }
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room{ get; set; }
    }
}
