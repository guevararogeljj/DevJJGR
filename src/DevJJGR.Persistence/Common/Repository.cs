using DevJJGR.Application.Common.Interfaces;
using DevJJGR.Application.Common.Specifications;
using DevJJGR.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DevJJGR.Persistence.Common
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        //source for repository specification pattern https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implementation-entity-framework-core

        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext dbContext)
        {
            this._context = dbContext;
        }
        public async Task AddAsync(T item)
        {
            await this._context.AddAsync(item);
        }

        public async Task AddRangeAsync(List<T> range)
        {
            await this._context.AddRangeAsync(range);
        }

        public async Task<int> CountAsync()
        {
            return await this._context.Set<T>().CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await this._context.Set<T>().Where(predicate).CountAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).CountAsync();
        }

        public async Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await this._context.Set<T>().Where(predicate).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> FilterAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).AsNoTracking().ToListAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await this._context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await this._context.Set<T>().AsNoTracking().AnyAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this._context.Set<T>().Where(x => x.Visible).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> PaginationAscAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderBy, int page, int sizePage)
        {
            return await this._context.Set<T>().Where(predicate).OrderBy(orderBy).Skip((--page) * sizePage).Take(sizePage).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> PaginationDescAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderBy, int page, int sizePage)
        {
            return await this._context.Set<T>().Where(predicate).OrderByDescending(orderBy).Skip((--page) * sizePage).Take(sizePage).AsNoTracking().ToListAsync();
        }

        public void Remove(T item)
        {
            item.SoftRemove();
            this.Update(item);
        }

        public async Task SaveChangesAsync()
        {
            await this._context.SaveChangesAsync();
        }
        public async Task SaveChangesAsync(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Detached;

            await this._context.SaveChangesAsync();
        }

        public void UpdateRange(IEnumerable<T> items)
        {
            this._context.UpdateRange(items);
        }

        public void Update(T item)
        {
            this._context.Update(item);
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            IEnumerable<T> lstByRemove = items.Select(x =>
            {
                x.SoftRemove();
                return x;
            });
            this._context.UpdateRange(lstByRemove);
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(this._context.Set<T>().AsQueryable(), specification);
        }

        public void DeleteRange(IEnumerable<T> items)
        {
            this._context.RemoveRange(items);
        }

        public void Delete(T item)
        {
            this._context.Remove(item);
        }

        public async Task<T> FirstOrDefaultTrackingAsync(Expression<Func<T, bool>> predicate)
        {
            return await this._context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllTrackingAsync()
        {
            return await this._context.Set<T>().Where(x => x.Visible).ToListAsync();
        }

        public async Task<IEnumerable<T>> FilterTrackingAsync(Expression<Func<T, bool>> predicate)
        {
            return await this._context.Set<T>().Where(predicate).ToListAsync();
        }
    }
}
