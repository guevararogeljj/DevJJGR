using DevJJGR.Domain.Common;
using System.Linq.Expressions;

namespace DevJJGR.Application.Common.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task AddAsync(T item);
        Task AddRangeAsync(List<T> range);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllTrackingAsync();
        Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FilterTrackingAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FilterAsync(ISpecification<T> specification);
        Task<IEnumerable<T>> PaginationAscAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderBy, int page, int sizePage);
        Task<IEnumerable<T>> PaginationDescAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderBy, int page, int sizePage);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultTrackingAsync(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        void UpdateRange(IEnumerable<T> items);
        void Update(T item);
        void RemoveRange(IEnumerable<T> items);
        void Remove(T item);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(ISpecification<T> specification);
        Task SaveChangesAsync();
        Task SaveChangesAsync(T entity);
        void DeleteRange(IEnumerable<T> items);
        void Delete(T item);
    }
}
