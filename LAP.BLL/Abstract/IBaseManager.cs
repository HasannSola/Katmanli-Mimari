using LAP.ENTITIES.CustomModels;
using System;
using System.Collections.Generic;
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

        List<T> GetAll(Expression<Func<T, bool>> expression = null);

        List<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);

        List<T> GetAllIncluding(params object[] includeProperties);

        CResult<T> Update(T entity);

        CResult<T> BulkInsert(List<T> obj);
    }
}
