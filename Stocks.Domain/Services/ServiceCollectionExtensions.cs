using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Stocks.Domain.Mappings;
using System.Threading.Tasks;
using IdentityModel;

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

                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("scope", "StockTickerManagement")
                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });
            mvcBuilder.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            mvcBuilder.AddJsonFormatters();
            mvcBuilder.AddAuthorization();
            mvcBuilder.AddControllersAsServices();
            return services;
        }

        public static IServiceCollection AddConfiguredAuth(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookies", options =>
                {
                    options.EventsType = typeof(CustomCookieAuthenticationEvents);
                })
                .AddOpenIdConnect("oidc", options =>
                {
                    options.SignInScheme = "Cookies";

                    options.Authority = "https://localhost:5005";
                    options.RequireHttpsMetadata = false;

                    options.ClientId = "WebFrontend";
                    options.ClientSecret = "secret";
                    options.ResponseType = OidcConstants.ResponseTypes.Code;

                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;

                    options.Scope.Add("StockTickers");
                    options.Scope.Add(OidcConstants.StandardScopes.OfflineAccess);

                    options.Events.OnRedirectToIdentityProvider = context =>
                    {
                        if (!context.HttpContext.Request.Path.StartsWithSegments("/auth/login"))
                        {
                            context.HttpContext.Response.StatusCode = 401;
                            context.HandleResponse();
                        }
                        return Task.CompletedTask;
                    };
                });

            services
                .AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

            return services;
        }
    }
}
