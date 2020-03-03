using Dapper;
using FormFeedbackAPI.ConnectionStrings;
using FormFeedbackAPI.Contexts;
using FormFeedbackAPI.Models;
using FormFeedbackAPI.Repositories.Interfaces;
using FormFeedbackAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Repositories.Data
{
    public class QuestionRepository : GeneralRepository<Question>
    {
        public QuestionRepository(ConnectionString connectionString):base(connectionString)
        {

        }
    }
}
