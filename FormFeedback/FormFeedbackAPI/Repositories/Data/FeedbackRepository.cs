using Dapper;
using FormFeedbackAPI.ConnectionStrings;
using FormFeedbackAPI.Models;
using FormFeedbackAPI.Repositories.Interfaces;
using FormFeedbackAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Repositories.Data
{
    public class FeedbackRepository : GeneralRepository<Feedback>
    {
        public FeedbackRepository(ConnectionString connectionString) : base(connectionString)
        {

        }

    }
}
