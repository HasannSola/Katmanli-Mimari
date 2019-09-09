using LAP.ENTITIES.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LAP.DAL.Abstract
{
    public interface IRepository<T> where T : class
    {     
          /// <summary>
          /// Tüm nesneleri al
          /// </summary>
          /// <returns></returns>
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Tüm nesneleri ve ilişkili olan nesneler ile beraber getir.Expression ile
        /// </summary>
        /// <param name="includeProperties">ilişkili nesneler</param>
        /// <returns></returns>
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// Tüm nesneleri ve ilişkili olan nesneler ile beraber getir. 
        /// </summary>
        /// <param name="includeProperties">ilişkili nesneler</param>
        /// <returns></returns>
        IQueryable<T> GetAllIncluding(params object[] includeProperties);

        /// <summary>
        /// Asenkron olarak nesneleri ve ilişkili olan nesneler ile beraber getir.
        /// </summary>
        /// <param name="includeProperties">ilişkili nesneler</param>
        /// <returns></returns>
        Task<List<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// Tek bir nesne ve ilişkili olan nesneler ile beraber getir.
        /// </summary>
        /// <param name="expression">nesne property</param>
        /// <param name="includeProperties">ilişkili olduğu tüm nesneler</param>
        /// <returns></returns>
        T GetIncluding(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// Gönderilen parametreye göre bir nesne döndür
        /// </summary>
        /// <param name="Id">nesne Id</param>
        /// <returns></returns>
        T Get(object Id);

        T Get(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Gönderilen nesneyi kaydet
        /// </summary>
        /// <param name="obj">nesne</param>
        /// <returns></returns>
        CResult<T> Add(T obj);

        /// <summary>
        /// Gönderilen nesneleri kaydet
        /// </summary>
        /// <param name="obj">nesne</param>
        /// <returns></returns>
        CResult<T> BulkInsert(List<T> obj);

        /// <summary>
        /// Gönderilen nesneyi kaydet asenkron 
        /// </summary>
        /// <param name="obj">nesne</param>
        /// <returns></returns>
        Task<CResult<T>> AddAsync(T obj);

        /// <summary>
        /// Gönderilen nesneyi güncelle.
        /// </summary>
        /// <param name="obj">gönderilen nesne</param>
        /// <returns></returns>
        CResult<T> Update(T obj);

        /// <summary>
        /// Gönderilen nesneyi güncelle asenkron
        /// </summary>
        /// <param name="obj">gönderilen nesne</param>
        /// <returns></returns>
        Task<CResult<T>> UpdateAsync(T obj);

        /// <summary>
        /// Gönderilen parameterye göre bir nesne sil
        /// </summary>
        /// <param name="Id">nesne Id</param>
        /// <returns></returns>
        CResult<string> Delete(object Id);

    
    }
}
