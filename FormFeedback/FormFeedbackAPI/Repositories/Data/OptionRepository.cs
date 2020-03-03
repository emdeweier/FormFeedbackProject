using Dapper;
using FormFeedbackAPI.ConnectionStrings;
using FormFeedbackAPI.Models;
using FormFeedbackAPI.Repositories.Interfaces;
using FormFeedbackAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Repositories.Data
{
    public class OptionRepository : GeneralRepository<Option>
    {
        public OptionRepository(ConnectionString connectionString):base(connectionString)
        {

        }
    }
}
