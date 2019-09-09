using LAP.ENTITIES.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LAP.BLL.Abstract
{
    public interface IBaseManager<T> where T : class
    {
        CResult<T> Add(T entity);

        Task<CResult<T>> AddAsync(T entity);

        CResult<string> Delete(object entityId);

        T Get(object entityId);

        T Get(Expression<Func<T, bool>> expression);

        IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null);

        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetAllIncluding(params object[] includeProperties);

        Task<List<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);

        CResult<T> Update(T entity);

        Task<CResult<T>> UpdateAsync(T entity);

        CResult<T> BulkInsert(List<T> obj);
    }
}
