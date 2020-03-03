using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Bases
{
    public class BaseModel : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }

        public bool IsDelete { get; set; }

        public void Create()
        {
            IsDelete = false;
            CreateDate = DateTime.Now;
        }

        public void Update()
        {
            UpdateDate = DateTime.Now;
        }

        public void Delete()
        {
            IsDelete = true;
            DeleteDate = DateTime.Now;
        }
    }
}
