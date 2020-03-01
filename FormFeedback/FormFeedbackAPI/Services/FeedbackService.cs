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
    public class FeedbackService : IFeedbackService
    {
        IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public int Add(FeedbackVM feedbackVM)
        {
            if (string.IsNullOrWhiteSpace(feedbackVM.Answer) || feedbackVM.Answer.Trim() == "")
            {
                return 0;
            }
            else if (string.IsNullOrWhiteSpace(feedbackVM.Note) || feedbackVM.Note.Trim() == "")
            {
                return 0;
            }
            else
            {
                var save = _feedbackRepository.Add(feedbackVM);
                if (save > 0)
                {
                    return save;
                }
                return 0;
            }
        }

        public bool Delete(string id)
        {
            var delete = _feedbackRepository.Delete(id);
            if (delete == true)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<FeedbackVM> Get()
        {
            var feedback = _feedbackRepository.Get();
            if (feedback != null)
            {
                return feedback;
            }
            return null;
        }

        public FeedbackVM Get(string id)
        {
            var feedback = _feedbackRepository.Get(id);
            if (feedback != null)
            {
                return feedback;
            }
            return null;
        }
    }
}
