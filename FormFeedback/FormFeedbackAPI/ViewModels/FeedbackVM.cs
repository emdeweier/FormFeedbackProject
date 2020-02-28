using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.ViewModels
{
    public class FeedbackVM
    {
        public string fId { get; set; }
        public string Answer { get; set; }
        public string Note { get; set; }
        public string qId { get; set; }
        public string pId { get; set; }
    }
}
