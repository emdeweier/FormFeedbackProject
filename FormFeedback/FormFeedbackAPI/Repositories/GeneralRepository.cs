using Dapper.Contrib.Extensions;
using FormFeedbackAPI.ConnectionStrings;
using FormFeedbackAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Repositories
{
    public class GeneralRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly ConnectionString _connectionString;

        public GeneralRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            var getall = await _connectionString.Connection.GetAllAsync<TEntity>();
            return getall;
        }

        public async Task<TEntity> Get(int Id)
        {
            var get = await _connectionString.Connection.GetAsync<TEntity>(Id);
            return get;
        }

        public async Task<int> Post(TEntity entity)
        {
            var post = await _connectionString.Connection.InsertAsync(entity);
            return post;
        }

        public async Task<bool> Put(TEntity entity)
        {
            var put = await _connectionString.Connection.UpdateAsync(entity);
            return put;
        }

        public async Task<bool> Delete(int Id)
        {
            var entity = await _connectionString.Connection.GetAsync<TEntity>(Id);
            var delete = await _connectionString.Connection.DeleteAsync(entity);
            return delete;
        }
    }
}
