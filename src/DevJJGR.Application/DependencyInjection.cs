using AutoMapper;
using DevJJGR.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DevJJGR.Application
{
    public static partial class DependencyInjection
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {

            services.AddScoped(provider => new MapperConfiguration(x =>
            {

                x.AddProfile(new ProductsProfile());
                x.AddProfile(new CategoriesProfile());


            }).CreateMapper());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
