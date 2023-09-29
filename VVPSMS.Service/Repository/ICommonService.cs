using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMS.Service.Repository
{
    public interface ICommonService<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(int id);
        Task<T> GetById(int id);
        Task<bool> InsertOrUpdateRange(List<T> entity);
        Task<bool> InsertOrUpdate(T entity);
        Task<bool> Update(T entity1,T entity);
        Task<bool> Remove(T entity);
        Task<bool> RemoveRange(List<T> entity);

        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
    }
}
