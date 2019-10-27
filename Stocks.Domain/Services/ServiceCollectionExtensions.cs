using System;
using Microsoft.Extensions.DependencyInjection;
using Stocks.Data.Services;

namespace Stocks.Domain.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddSingleton<IStockTickerService, InMemoryStockTickerService>();

            //more services...

            return services;
        }
    }
}
