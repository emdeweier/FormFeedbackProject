using FormFeedbackAPI.Models;
using FormFeedbackAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Services.Interfaces
{
    public interface IOptionService
    {
        IEnumerable<Option> Get();
        Option Get(string id);
        int Add(OptionVM optionVM);
        int Edit(string id, OptionVM optionVM);
        bool Delete(string id);
    }
}
