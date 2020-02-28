using Dapper;
using FormFeedbackAPI.ConnectionStrings;
using FormFeedbackAPI.Models;
using FormFeedbackAPI.Repositories.Interfaces;
using FormFeedbackAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public readonly ConnectionString _connectionString;

        public FeedbackRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        DynamicParameters param = new DynamicParameters();
        
        public IEnumerable<Feedback> Get()
        {
            throw new NotImplementedException();
        }

        public Option Get(string id)
        {
            throw new NotImplementedException();
        }

        public int Add(FeedbackVM feedbackVM)
        {
            var procInsert = "SP_InsertFeedback";
            param.Add("@fId", Guid.NewGuid().ToString());
            param.Add("@fAnswer", feedbackVM.Answer);
            param.Add("@fNote", feedbackVM.Note);
            param.Add("@fQuestionId", feedbackVM.qId);
            param.Add("@fPointId", feedbackVM.pId);
            param.Add("@fCreateDate", DateTimeOffset.Now.LocalDateTime);
            var insert = _connectionString.Connection.Execute(procInsert, param, commandType: System.Data.CommandType.StoredProcedure);
            return insert;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
