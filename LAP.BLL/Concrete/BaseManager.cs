using LAP.BLL.Abstract;
using LAP.DAL.Abstract;
using LAP.ENTITIES.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LAP.BLL.Concrete
{
    public abstract class BaseManager<T> : IBaseManager<T> where T : class
    {
        private IRepository<T> _genericDal;

        public BaseManager(IRepository<T> InitContext)
        {
            _genericDal = InitContext;
        }

        protected BaseManager()
        {
        }

        public virtual CResult<T> Add(T entity)
        {
            return _genericDal.Add(entity);
        }

        public virtual async Task<CResult<T>> AddAsync(T entity)
        {
            return await _genericDal.AddAsync(entity);
        }

        public CResult<T> BulkInsert(List<T> obj)
        {
            return _genericDal.BulkInsert(obj);
        }

        public virtual CResult<string> Delete(object entityId)
        {
            return _genericDal.Delete(entityId);
        }

        public virtual T Get(object Id)
        {
            return _genericDal.Get(Id);
        }
        public virtual T Get(Expression<Func<T, bool>> expression)
        {
            return _genericDal.Get(expression);
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _genericDal.GetAll(expression);
        }

        public virtual List<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            return _genericDal.GetAllIncluding(includeProperties);
        }

        public virtual List<T> GetAllIncluding(params object[] includeProperties)
        {
            return _genericDal.GetAllIncluding(includeProperties);
        }

        public T GetIncluding(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeProperties)
        {
            return _genericDal.GetIncluding(expression, includeProperties);
        }

        public CResult<string> HardDelete(object entityId)
        {
            return _genericDal.Delete(entityId);
        }

        public virtual CResult<T> Update(T entity)
        {
            return _genericDal.Update(entity);
        }
    }
}
