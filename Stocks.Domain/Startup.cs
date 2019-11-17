using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProxyKit;
using Stocks.Data.Models;
using Stocks.Domain.Services;
using System.Threading.Tasks;

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
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("StockDatabase");
            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<StockDbContext>(options => options.UseNpgsql(connectionString))
                    .BuildServiceProvider();

            services.AddRequiredMvcComponents();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

            services.AddProxy();

            services.AddBusiness();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            services.AddConfiguredAuth(_configuration);
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

            app.Use(async (context, next) =>
            {
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.Add("X-Powered-By", "GMJNOW");
                    return Task.CompletedTask;
                });

                await next.Invoke();
            });
            app.UseAuthentication();

            app.UseStaticFiles();
            app.UseCookiePolicy();
            
            app.UseMvcWithDefaultRoute();
            app.UseOpenApi(); // Serves the registered OpenAPI/Swagger documents by default on `/swagger/{documentName}/swagger.json`
            app.UseSwaggerUi3();
        }
    }
}
