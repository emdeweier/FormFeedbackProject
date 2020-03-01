using FormFeedbackAPI.Models;
using FormFeedbackAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Services.Interfaces
{
    interface IFeedbackService
    {
        IEnumerable<FeedbackVM> Get();
        FeedbackVM Get(string id);
        int Add(FeedbackVM feedbackVM);
        bool Delete(string id);
    }
}
