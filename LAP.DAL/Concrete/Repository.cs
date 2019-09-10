using LAP.DAL.Abstract;
using LAP.ENTITIES.CustomModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LAP.DAL.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private LapContext _context = null;
        private DbSet<T> dbSet;
        public Repository(LapContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
       
        public CResult<string> Delete(object Id)
        {
            try
            {
                var item = Get(Id);
                _context.Entry(item).State = EntityState.Modified;
                dbSet.Remove(item);
                _context.SaveChanges();
                return new CResult<string>() { Succeeded = true, Desc = "Silme işlemi başarılı." };
            }
            catch (Exception ex)
            {
                return new CResult<string>() { Succeeded = false, Desc = ex.Message.ToString() };
            }

        }
   
        public T Get(object Id)
        {
            try
            {
                return dbSet.Find(Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Repository.Get ; Repository", ex);
            }
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            try
            {
                if (expression == null)
                {
                    return dbSet;
                }
                return dbSet.Where(expression);

            }
            catch (Exception ex)
            {
                throw new Exception("Repository.GetAll ; Repository", ex);
            }
        }
        public T Get(Expression<Func<T, bool>> expression)
        {
            try
            {
                return dbSet.FirstOrDefault(expression);

            }
            catch (Exception ex)
            {
                throw new Exception("Repository.GetAll ; Repository", ex);
            }
        }
   
        public CResult<T> Add(T obj)
        {
            try
            {
                dbSet.Add(obj);
                _context.SaveChanges();
                return new CResult<T>() { Object = obj, Succeeded = true, Desc = "Kayıt işlemi başarılı." };
            }
            catch (Exception ex)
            {
                return new CResult<T>() { Succeeded = false, Desc = ex.Message.ToString(), ex = ex };
            }

        }

        public async Task<CResult<T>> AddAsync(T obj)
        {
            try
            {
                dbSet.Add(obj);
                await _context.SaveChangesAsync();
                return new CResult<T>() { Object = obj, Succeeded = true, Desc = "Kayıt işlemi başarılı." };
            }
            catch (Exception ex)
            {
                return new CResult<T>() { Succeeded = false, Desc = ex.Message.ToString(), ex = ex };
            }
        }

        public CResult<T> Update(T obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
                return new CResult<T>() { Object = obj, Succeeded = true, Desc = "Güncelleme işlemi başarılı." };
            }
            catch (Exception ex)
            {
                return new CResult<T>() { Object = obj, Succeeded = false, Desc = ex.Message.ToString(), ex = ex };
            }

        }

        public async Task<CResult<T>> UpdateAsync(T obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new CResult<T>() { Object = obj, Succeeded = true, Desc = "Güncelleme işlemi başarılı." };
            }
            catch (Exception ex)
            {
                return new CResult<T>() { Object = obj, Succeeded = false, Desc = ex.Message.ToString(), ex = ex };
            }

        }
 
        public virtual IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {

                IQueryable<T> query = dbSet;
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
                return query;
                // return query.AsNoTracking();//, AsNoTracking kullanırsak yaptığımız select üzerinde herhangi bir update işlemi uygulayamıyoruz.
            }
            catch (Exception ex)
            {
                throw new Exception("Repository.GetAllIncluding ; Repository", ex);
            }

        }

        public T GetIncluding(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> query = dbSet;
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
                // return query.AsNoTracking().FirstOrDefault(expression);//Bu kullanıldığında buradaki buradaki instance update edilmez
                return query.FirstOrDefault(expression);
            }
            catch (Exception ex)
            {
                throw new Exception("Repository.GetIncluding ; Repository", ex);
            }
        }
   

        public async Task<List<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> query = dbSet;
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Repository.GetAllIncludingAsync ; Repository", ex);
            }
        }
        public DbContext GetContext()
        {
            return _context;
        }

        public IQueryable<T> GetAllIncluding(params object[] includeProperties)
        {
            try
            {
                IQueryable<T> query = dbSet;
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty.ToString());
                }
                // return query.AsNoTracking();
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception("Repository.GetAllIncluding ; Repository", ex);
            }

        }

        public CResult<T> BulkInsert(List<T> obj)
        {
            try
            {
                dbSet.AddRange(obj);
                _context.SaveChangesAsync();
                return new CResult<T>() { Object = null, Succeeded = true, Desc = "Kayıt işlemi başarılı." };
            }
            catch (Exception ex)
            {
                throw new Exception("Repository.BulkInsert ; Repository", ex);
            }
        }
    }
}
