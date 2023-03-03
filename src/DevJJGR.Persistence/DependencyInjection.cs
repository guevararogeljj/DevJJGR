using AutoMapper;
using DevJJGR.Application.Common.Interfaces;
using DevJJGR.Application.Mappings;
using DevJJGR.Persistence.Common;
using DevJJGR.Persistence.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevJJGR.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddScoped(provider => new MapperConfiguration(x =>
            {
                x.AddProfile(new ProductsProfile());
                x.AddProfile(new CategoriesProfile());
            }).CreateMapper());

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<ICategoriesRepository, CategoriesRepository>();
            return services;
        }
    }
}
