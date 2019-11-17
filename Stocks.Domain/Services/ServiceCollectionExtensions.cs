using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stocks.Domain.Mappings;
using Stocks.Domain.Configuration;
using System.Threading.Tasks;
using IdentityModel;
using Autofac;
using Stocks.Data.Services;

namespace Stocks.Domain.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRequiredMvcComponents(this IServiceCollection services)
        {
            services.AddTransient<ApiExceptionFilter>();

            var mvcBuilder = services
                .AddMvcCore(options =>
                {
                    options.Filters.AddService<ApiExceptionFilter>();

                    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .RequireClaim("scope", "stocktickers")
                    .Build();
                    options.Filters.Add(new AuthorizeFilter(policy));
                })
                .AddApiExplorer();
            mvcBuilder.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            mvcBuilder.AddJsonFormatters();
            mvcBuilder.AddAuthorization();
            mvcBuilder.AddControllersAsServices();
            return services;
        }

        public static IServiceCollection AddConfiguredAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    var authServiceConfig = configuration.GetSection<AuthServiceSettings>(nameof(AuthServiceSettings));

                    options.Authority = authServiceConfig.Authority;
                    options.RequireHttpsMetadata = authServiceConfig.RequireHttpsMetadata;
                    options.Audience = "StockTickers";
                });

            return services;
        }

        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<IStockTickerService, StockTickersService>();

            //more business services...

            return services;
        }


    }
}
