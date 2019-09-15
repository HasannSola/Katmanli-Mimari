using LAP.DAL.Abstract;
using LAP.ENTITIES.CustomModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LAP.DAL.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private LapContext _context { get; set; }
        public Repository()
        {

        }

        public CResult<string> Delete(object Id)
        {
            try
            {
                using (_context = new LapContext())
                {
                    var item = _context.Set<T>().Find(Id); ;
                    _context.Set<T>().Remove(item);
                    _context.SaveChanges();
                    return new CResult<string>() { Succeeded = true, Desc = "Silme işlemi başarılı." };
                }
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
                using (_context = new LapContext())
                {
                    return _context.Set<T>().Find(Id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Repository.Get ; Repository", ex);
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            try
            {
                using (_context = new LapContext())
                {
                    if (expression == null)
                    {
                        return _context.Set<T>().ToList();
                    }
                    return _context.Set<T>().Where(expression).ToList();
                }
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
                using (_context = new LapContext())
                {
                    return _context.Set<T>().FirstOrDefault(expression);
                }
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
                using (_context = new LapContext())
                {
                    _context.Set<T>().Add(obj);
                    _context.SaveChanges();
                    return new CResult<T>() { Object = obj, Succeeded = true, Desc = "Kayıt işlemi başarılı." };
                }
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
                using (_context = new LapContext())
                {
                    await _context.Set<T>().AddAsync(obj);
                    await _context.SaveChangesAsync();
                    return new CResult<T>() { Object = obj, Succeeded = true, Desc = "Kayıt işlemi başarılı." };
                }
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
                using (_context = new LapContext())
                {
                    _context.Entry(obj).State = EntityState.Modified;
                    _context.SaveChanges();
                    return new CResult<T>() { Object = obj, Succeeded = true, Desc = "Güncelleme işlemi başarılı." };
                }
            }
            catch (Exception ex)
            {
                return new CResult<T>() { Object = obj, Succeeded = false, Desc = ex.Message.ToString(), ex = ex };
            }
        }

        public virtual List<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                using (_context = new LapContext())
                {
                    IQueryable<T> query = _context.Set<T>();
                    foreach (var includeProperty in includeProperties)
                    {
                        query = query.Include(includeProperty);
                    }
                    return query.ToList();
                    // return query.AsNoTracking();//, AsNoTracking kullanırsak yaptığımız select üzerinde herhangi bir update işlemi uygulayamıyoruz.
                }
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
                using (_context = new LapContext())
                {
                    IQueryable<T> query = _context.Set<T>();
                    foreach (var includeProperty in includeProperties)
                    {
                        query = query.Include(includeProperty);
                    }
                    return query.FirstOrDefault(expression);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Repository.GetIncluding ; Repository", ex);
            }
        }

        public List<T> GetAllIncluding(params object[] includeProperties)
        {
            try
            {
                using (_context = new LapContext())
                {
                    IQueryable<T> query = _context.Set<T>();
                    foreach (var includeProperty in includeProperties)
                    {
                        query = query.Include(includeProperty.ToString());
                    }
                    return query.ToList();
                }
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
                using (_context = new LapContext())
                {
                    _context.Set<T>().AddRange(obj);
                    _context.SaveChangesAsync();
                    return new CResult<T>() { Object = null, Succeeded = true, Desc = "Kayıt işlemi başarılı." };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Repository.BulkInsert ; Repository", ex);
            }
        }
    }
}
