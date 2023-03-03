using DevJJGR.Application.Dto;
using System.Linq.Expressions;

namespace DevJJGR.Application.Common.Interfaces
{
    public interface IProductsRepository : IRepository<DevJJGR.Domain.Entities.Products>
    {
        Task<IEnumerable<ProductsDTO>> GetAllProductsAllCatalogs();
        Task<IEnumerable<ProductsDTO>> GetAllByPredicateAsync(Expression<Func<DevJJGR.Domain.Entities.Products, bool>> predicate);
    }
}
