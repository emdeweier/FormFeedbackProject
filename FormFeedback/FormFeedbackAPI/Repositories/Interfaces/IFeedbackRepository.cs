using FormFeedbackAPI.Models;
using FormFeedbackAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Repositories.Interfaces
{
    interface IFeedbackRepository
    {
        IEnumerable<Feedback> Get();
        Option Get(string id);
        int Add(FeedbackVM feedbackVM);
        bool Delete(string id);
    }
}
