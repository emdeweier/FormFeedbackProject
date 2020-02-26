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
        [Key]
        public string Id { get; set; }
        public int Value { get; set; }
        public string Note { get; set; }

        public Point() { }

        public void Create()
        {
            CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public void Update()
        {
            CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public void Delete()
        {
            IsDelete = true;
            CreateDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
