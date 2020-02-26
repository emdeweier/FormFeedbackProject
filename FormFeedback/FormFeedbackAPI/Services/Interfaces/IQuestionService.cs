using FormFeedbackAPI.Models;
using FormFeedbackAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Services.Interfaces
{
    public interface IQuestionService
    {
        IEnumerable<QuestionVM> Get();
        QuestionVM Get(string id);
        int Add(QuestionVM questionVM);
        int Edit(string id, QuestionVM questionVM);
        bool Delete(string id);
    }
}
