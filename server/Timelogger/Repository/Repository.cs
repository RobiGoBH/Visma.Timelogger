using Timelogger.DAL.Base;
using Timelogger.DAL.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Timelogger.DAL.Repository
{
    internal class Repository<T> : IRepository<T>
        where T : BaseEntity
    {

        readonly TimeloggerContext _context;

        public Repository(TimeloggerContext context) =>
            _context = context;

        public Task<T> GetByIdAsync(int id)
        {
            return _context.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task<T> GetSingleOrDefaultByCriteriaAsync(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().SingleOrDefaultAsync(criteria);
        }

        public Task<List<T>> GetAllByCriteriaAsync(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().Where(criteria).ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);

            await _context.SaveChangesAsync();
        }

        public Task<List<T>> GetAllAsync()
        {
            return _context.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
