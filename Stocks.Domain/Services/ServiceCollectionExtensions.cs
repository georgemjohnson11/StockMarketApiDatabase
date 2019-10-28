using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Stocks.Domain.Mappings;

namespace Stocks.Domain.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRequiredMvcComponents(this IServiceCollection services)
        {
            services.AddTransient<ApiExceptionFilter>();

            var mvcBuilder = services.AddMvcCore(options =>
            {
                options.Filters.AddService<ApiExceptionFilter>();
            });
            mvcBuilder.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            mvcBuilder.AddJsonFormatters();
            return services;
        }
    }
}
