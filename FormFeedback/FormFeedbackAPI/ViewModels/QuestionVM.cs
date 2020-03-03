using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.ViewModels
{
    public class QuestionVM
    {
        public string Id { get; set; }
        public string Q_Name { get; set; }
        public string Type { get; set; }
        public string OptionId { get; set; }
        public string O_Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }

        public bool IsDelete { get; set; }
    }
}
