using FormFeedbackAPI.Models;
using FormFeedbackAPI.Repositories.Interfaces;
using FormFeedbackAPI.Services.Interfaces;
using FormFeedbackAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Services
{
    public class QuestionService : IQuestionService
    {
        IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public int Add(QuestionVM questionVM)
        {
            if (string.IsNullOrWhiteSpace(questionVM.Q_Name) || questionVM.Q_Name.Trim() == "")
            {
                return 0;
            }
            else
            {
                var save = _questionRepository.Add(questionVM);
                if (save > 0)
                {
                    return save;
                }
                return 0;
            }
        }

        public bool Delete(string id)
        {
            var delete = _questionRepository.Delete(id);
            if (delete == true)
            {
                return true;
            }
            return false;
        }

        public int Edit(string id, QuestionVM questionVM)
        {
            if (string.IsNullOrWhiteSpace(questionVM.Q_Name) || questionVM.Q_Name.Trim() == "")
            {
                return 0;
            }
            else
            {
                var save = _questionRepository.Edit(id, questionVM);
                if (save > 0)
                {
                    return save;
                }
                return 0;
            }
        }

        public IEnumerable<QuestionVM> Get()
        {
            var question = _questionRepository.Get();
            if (question != null)
            {
                return question;
            }
            return null;
        }

        public QuestionVM Get(string id)
        {
            var question = _questionRepository.Get(id);
            if (question != null)
            {
                return question;
            }
            return null;
        }
    }
}
