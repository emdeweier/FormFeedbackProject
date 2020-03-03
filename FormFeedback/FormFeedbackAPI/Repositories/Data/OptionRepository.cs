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
    //public class OptionRepository : IOptionRepository
    //{
    //    public readonly ConnectionString _connectionString;

    //    public OptionRepository(ConnectionString connectionString)
    //    {
    //        _connectionString = connectionString;
    //    }

    //    DynamicParameters param = new DynamicParameters();

    //    public int Add(OptionVM optionVM)
    //    {
    //        var procCheck = "SP_CheckOption";
    //        param.Add("@oOptions", optionVM.O_Name);
    //        var check = _connectionString.Connection.Query<Option>(procCheck, param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
    //        if (check == null)
    //        {
    //            var procInsert = "SP_InsertOption";
    //            param.Add("@oId", Guid.NewGuid().ToString());
    //            param.Add("@oCreatedate", DateTimeOffset.Now.LocalDateTime);
    //            param.Add("@oIsdelete", false);
    //            var insert = _connectionString.Connection.Execute(procInsert, param, commandType: System.Data.CommandType.StoredProcedure);
    //            return insert;
    //        }
    //        return 0;
    //    }

    //    public bool Delete(string id)
    //    {
    //        var Id = Get(id);
    //        if (Id != null)
    //        {
    //            var procDelete = "SP_DeleteOption";
    //            param.Add("@oId", Id.Id);
    //            param.Add("@oDeletedate", DateTimeOffset.Now.LocalDateTime);
    //            var delete = _connectionString.Connection.Execute(procDelete, param, commandType: System.Data.CommandType.StoredProcedure);
    //            return Convert.ToBoolean(delete);
    //        }
    //        return false;
    //    }

    //    public int Edit(string id, OptionVM optionVM)
    //    {
    //        var Id = Get(id);
    //        if (Id == null)
    //        {
    //            return 0;
    //        }
    //        else
    //        {
    //            var procCheck = "SP_CheckOption";
    //            param.Add("@oOptions", optionVM.O_Name);
    //            var check = _connectionString.Connection.Query<Question>(procCheck, param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
    //            if (check != null)
    //            {
    //                return 0;
    //            }
    //            else
    //            {
    //                var procUpdate = "SP_UpdateOption";
    //                param.Add("@oId", Id.Id);
    //                param.Add("@oUpdatedate", DateTimeOffset.Now.LocalDateTime);
    //                var update = _connectionString.Connection.Execute(procUpdate, param, commandType: System.Data.CommandType.StoredProcedure);
    //                return update;
    //            }
    //        }
    //    }

    //    public IEnumerable<Option> Get()
    //    {
    //        var procName = "SP_GetOption";
    //        param.Add("@oId", "null");
    //        var options = _connectionString.Connection.Query<Option>(procName, param, commandType: System.Data.CommandType.StoredProcedure);
    //        return options;
    //    }

    //    public Option Get(string id)
    //    {
    //        var procName = "SP_GetOption";
    //        param.Add("@oId", id);
    //        var options = _connectionString.Connection.Query<Option>(procName, param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
    //        return options;
    //    }
    //}

    public class OptionRepository : GeneralRepository<Option>
    {
        public OptionRepository(ConnectionString connectionString) : base(connectionString)
        {

        }
    }
}
