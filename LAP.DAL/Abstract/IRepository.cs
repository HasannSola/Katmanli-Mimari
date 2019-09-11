using LAP.ENTITIES.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LAP.DAL.Abstract
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Tüm nesneleri al
        /// </summary>
        /// <returns></returns>
        List<T> GetAll(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Tüm nesneleri ve ilişkili olan nesneler ile beraber getir.Expression ile
        /// </summary>
        /// <param name="includeProperties">ilişkili nesneler</param>
        /// <returns></returns>
        List<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// Tüm nesneleri ve ilişkili olan nesneler ile beraber getir. 
        /// </summary>
        /// <param name="includeProperties">ilişkili nesneler</param>
        /// <returns></returns>
        List<T> GetAllIncluding(params object[] includeProperties);

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
        /// Gönderilen parameterye göre bir nesne sil
        /// </summary>
        /// <param name="Id">nesne Id</param>
        /// <returns></returns>
        CResult<string> Delete(object Id);
    }
}
