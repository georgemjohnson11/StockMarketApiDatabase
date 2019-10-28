using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace Stocks.Domain
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(Path.Combine(Environment.CurrentDirectory, "logs", "stocks.log"), rollingInterval: RollingInterval.Day)
                .CreateLogger();
            Log.Debug("Starting up");

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseKestrel()
                   .UseUrls("https://testlocal:12433")
                   .UseContentRoot(Directory.GetCurrentDirectory())
                   .UseStartup<Startup>();

    }
}
