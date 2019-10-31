using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net;
using System.Net.Http;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using IdentityModel.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using ProxyKit;
using Stocks.Data.Models;
using Stocks.Domain.AuthTokenHelpers;
using Stocks.Domain.Services;

namespace Stocks.Domain
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("StockDatabase");
            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<StockDbContext>(options => options.UseNpgsql(connectionString))
                    .BuildServiceProvider();

            services.AddRequiredMvcComponents();


            services
                .AddTransient<CustomCookieAuthenticationEvents>()
                .AddTransient<ITokenRefresher, TokenRefresher>()
                .AddTransient<AccessTokenHttpMessageHandler>()
                .AddHttpContextAccessor();

            services
                .AddHttpClient<ITokenRefresher, TokenRefresher>();


            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddConfiguredAuth();


            services
                .AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

            services.AddProxy();

            services
                .AddSingleton<EnforceAuthenticatedUserMiddleware>()
                .AddSingleton<ValidateAntiForgeryTokenMiddleware>();

            //add Stocks.Data.Services and Stocks.Domain.Services using Autofac
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<AutofacModule>();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("Index.html");
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseMiddleware<EnforceAuthenticatedUserMiddleware>();
            app.UseMiddleware<ValidateAntiForgeryTokenMiddleware>();

            app.Map("/api", api =>
            {
                api.RunProxy(async context =>
                {
                    var endpointLookup = context.RequestServices.GetRequiredService<ProxiedApiRouteEndpointLookup>();
                    if (endpointLookup.TryGet(context.Request.Path, out var endpoint))
                    {
                        var forwardContext = context
                            .ForwardTo(endpoint)
                            .CopyXForwardedHeaders();

                        var token = await context.GetAccessTokenAsync();
                        forwardContext.UpstreamRequest.SetBearerToken(token);

                        return await forwardContext.Send();
                    }

                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                });
            });

            app.UseStaticFiles();
            app.UseCookiePolicy();
            
            app.UseMvcWithDefaultRoute();
        }
    }
}
