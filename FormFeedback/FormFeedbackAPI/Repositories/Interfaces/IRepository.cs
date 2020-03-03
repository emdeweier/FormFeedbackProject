using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Repositories.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int Id);
        Task<int> Post(T entity);
        Task<bool> Put(T entity);
        Task<bool> Delete(int Id);
    }
}
