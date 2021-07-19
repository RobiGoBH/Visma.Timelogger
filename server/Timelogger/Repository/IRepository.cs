using Timelogger.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Timelogger.DAL.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetSingleOrDefaultByCriteriaAsync(Expression<Func<T, bool>> criteria);
        Task<List<T>> GetAllByCriteriaAsync(Expression<Func<T, bool>> criteria);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
