using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.ViewModels
{
    public class QuestionVM
    {
        public string qId { get; set; }
        public string Q_Name { get; set; }
        public string Type { get; set; }
        public string oId { get; set; }
        public string O_Name { get; set; }
    }
}
