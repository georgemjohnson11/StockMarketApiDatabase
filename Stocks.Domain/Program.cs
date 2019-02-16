using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Stocks.Data.Models;

namespace Stocks.Domain
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseKestrel()
                   .UseContentRoot(Directory.GetCurrentDirectory())
                   .UseUrls("https://testlocal:5001", "http://testlocal:26342", "http://testlocal:44338","http://testlocal:5000")
                   .UseStartup<Startup>();

        public static async void GetData()
        {
            //We will make a GET request to a really cool website...
            using (var db = new StockDbContext())
            {
                foreach (StockTicker ticker in db.StockTickers)
                {
                    try {
                        string baseUrl = "http://localhost:5001/api/ApiStockData/" + ticker.Id.ToUpper() + "/2000-01-01/2019-02-13/daily";
                        //The 'using' will help to prevent memory leaks.

                        //Create a new instance of HttpClient
                        using (HttpClient client = new HttpClient())
                        {
                            //Setting up the response...         
                            using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                            {                     
                                await Task.Delay(50);
                            }
                        }
                    }
                    catch {
                        
                    }
                }
            }
        }
    }
}
