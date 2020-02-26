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

namespace FormFeedbackAPI.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        public readonly ConnectionString _connectionString;

        public QuestionRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        DynamicParameters param = new DynamicParameters();

        public int Add(QuestionVM questionVM)
        {
            var procCheck = "SP_CheckQuestion";
            param.Add("@qQuestion", questionVM.Q_Name);
            param.Add("@qType", questionVM.Type);
            var check = _connectionString.Connection.Query<Question>(procCheck, param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
            if (check == null)
            {
                var procInsert = "SP_InsertQuestion";
                param.Add("@qId", Guid.NewGuid().ToString());
                param.Add("@qOptionId", questionVM.oId);
                param.Add("@qCreateDate", DateTimeOffset.Now.LocalDateTime);
                var insert = _connectionString.Connection.Execute(procInsert, param, commandType: System.Data.CommandType.StoredProcedure);
                return insert;
            }
            return 0;
        }

        public bool Delete(string id)
        {
            var Id = Get(id);
            if (Id != null)
            {
                var procDelete = "SP_DeleteQuestion";
                param.Add("@qId", Id.qId);
                param.Add("@qDeleteDate", DateTimeOffset.Now.LocalDateTime);
                var delete = _connectionString.Connection.Execute(procDelete, param, commandType: System.Data.CommandType.StoredProcedure);
                return Convert.ToBoolean(delete);
            }
            return false;
        }

        public int Edit(string id, QuestionVM questionVM)
        {
            var Id = Get(id);
            if (Id == null)
            {
                return 0;
            }
            else
            {
                var procCheck = "SP_CheckQuestion";
                param.Add("@qQuestion", questionVM.Q_Name);
                param.Add("@qType", questionVM.Type);
                var check = _connectionString.Connection.Query<Question>(procCheck, param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                if (check != null)
                {
                    return 0;
                }
                else
                {
                    var procUpdate = "SP_UpdateQuestion";
                    param.Add("@qId", Id.qId);
                    param.Add("@qOptionId", questionVM.oId);
                    param.Add("@qUpdateDate", DateTimeOffset.Now.LocalDateTime);
                    var update = _connectionString.Connection.Execute(procUpdate, param, commandType: System.Data.CommandType.StoredProcedure);
                    return update;
                }
            }
        }

        public IEnumerable<QuestionVM> Get()
        {
            var procName = "SP_GetQuestion";
            param.Add("@qId", "null");
            var questions = _connectionString.Connection.Query<QuestionVM>(procName, param, commandType: System.Data.CommandType.StoredProcedure);
            return questions;
        }

        public QuestionVM Get(string id)
        {
            var procName = "SP_GetQuestion";
            param.Add("@qId", id);
            var questions = _connectionString.Connection.Query<QuestionVM>(procName, param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
            return questions;
        }
    }
}
