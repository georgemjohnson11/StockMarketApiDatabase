using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Stocks.Data.Models;
using Stocks.Domain.Formats;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System;
using Stocks.Domain.Services;
using Stocks.Domain.AuthTokenHelpers;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http;
using Stocks.Domain.Controllers;
using System.IdentityModel.Tokens.Jwt;

namespace Stocks.Domain
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("StockDatabase");
            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<StockDbContext>(options => options.UseNpgsql(connectionString))
                    .BuildServiceProvider();

            services.AddSpaStaticFiles(options => options.RootPath = "stocks-ui/dist");


            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });

            var csvFormatterOptions = new CsvFormatterOptions();
            services.AddRequiredMvcComponents();

            services.AddSingleton<IDiscoveryCache>(r =>
            {
                var factory = r.GetRequiredService<IHttpClientFactory>();
                return new DiscoveryCache("https://localhost:5005", () => factory.CreateClient());
            });

            services
                .AddTransient<CustomCookieAuthenticationEvents>()
                .AddTransient<ITokenRefresher, TokenRefresher>()
                .AddTransient<AccessTokenHttpMessageHandler>()
                .TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services
                .AddHttpClient<ITokenRefresher, TokenRefresher>()
                .AddHttpMessageHandler<AccessTokenHttpMessageHandler>();            


            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddConfiguredAuth();

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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
                {
                    spa.Options.SourcePath = "stocks-ui";
                    if (env.IsDevelopment())
                    {
                        spa.UseVueDevelopmentServer();
                    }
                });
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}
