using AutoMapper;
using DevJJGR.Application.Common.Interfaces;
using DevJJGR.Domain.Entities;
using DevJJGR.Persistence.Common;

namespace DevJJGR.Persistence.Repository
{
    public class CategoriesRepository : Repository<Categories>, ICategoriesRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public CategoriesRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            this._applicationDbContext = dbContext;
            this._mapper = mapper;
        }

    }
}
