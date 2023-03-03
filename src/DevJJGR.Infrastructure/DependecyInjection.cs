using System;
using DevJJGR.Application.Common.Interfaces;
using DevJJGR.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DevJJGR.Infrastructure
{
	public static partial class DependecyInjection
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddMemoryCache();
			services.AddTransient<IRabbitMQService, RabbitMQService>();
			return services;
		}
	}
}

