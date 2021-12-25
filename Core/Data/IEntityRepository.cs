using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity); 
        Task AddRangeAsync(IEnumerable<T> entities); 
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        T Update(T entity);
    }
}
