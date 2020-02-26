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
    public class OptionService : IOptionService
    {
        IOptionRepository _optionRepository;

        public OptionService(IOptionRepository optionRepository)
        {
            _optionRepository = optionRepository;
        }

        public int Add(OptionVM optionVM)
        {
            if (string.IsNullOrWhiteSpace(optionVM.O_Name) || optionVM.O_Name.Trim() == "")
            {
                return 0;
            }
            else
            {
                var save = _optionRepository.Add(optionVM);
                if (save > 0)
                {
                    return save;
                }
                return 0;
            }
        }

        public bool Delete(string id)
        {
            var delete = _optionRepository.Delete(id);
            if (delete == true)
            {
                return true;
            }
            return false;
        }

        public int Edit(string id, OptionVM optionVM)
        {
            if (string.IsNullOrWhiteSpace(optionVM.O_Name) || optionVM.O_Name.Trim() == "")
            {
                return 0;
            }
            else
            {
                var save = _optionRepository.Edit(id, optionVM);
                if (save > 0)
                {
                    return save;
                }
                return 0;
            }
        }

        public IEnumerable<Option> Get()
        {
            var option = _optionRepository.Get();
            if (option != null)
            {
                return option;
            }
            return null;
        }

        public Option Get(string id)
        {
            var option = _optionRepository.Get(id);
            if (option != null)
            {
                return option;
            }
            return null;
        }
    }
}
