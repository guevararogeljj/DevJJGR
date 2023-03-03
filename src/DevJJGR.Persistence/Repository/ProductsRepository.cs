using AutoMapper;
using DevJJGR.Application.Common.Interfaces;
using DevJJGR.Application.Dto;
using DevJJGR.Domain.Entities;
using DevJJGR.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DevJJGR.Persistence.Repository
{
    public class ProductsRepository : Repository<Products>, IProductsRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public ProductsRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            this._applicationDbContext = dbContext;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<ProductsDTO>> GetAllByPredicateAsync(Expression<Func<Products, bool>> predicate)
        {
            return await this._mapper.ProjectTo<ProductsDTO>(this._applicationDbContext.Products
            .Where(predicate)
            .Include(x => x.Categories)
            .AsNoTracking())
            .ToListAsync();
        }

        public async Task<IEnumerable<ProductsDTO>> GetAllProductsAllCatalogs()
        {
            return await this._mapper.ProjectTo<ProductsDTO>(this._applicationDbContext.Products
            .Include(x => x.Categories)
            .AsNoTracking())
            .ToListAsync();
        }
    }
}
