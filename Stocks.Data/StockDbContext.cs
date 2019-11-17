using System.Configuration;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.EntityFrameworkCore;
using System.IO;
using CsvHelper;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;
using System;
using TinyCsvParser;

namespace Stocks.Data.Models
{
    public partial class StockDbContext : DbContext
    {
        public StockDbContext()
        {

        }

        public StockDbContext(DbContextOptions<StockDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.DockerDevelopment.json")
            .Build();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("StockDatabase"));
        }

        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Earnings> Earnings { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioStock> PortfolioStocks { get; set; }
        public DbSet<StockHistory> StockHistories { get; set; }
        public DbSet<StockSplits> StockSplits { get; set; }
        public DbSet<StockTicker> StockTickers { get; set; }
        public DbSet<CsvPipe> Pipes { get; set; }

        public static readonly LoggerFactory MyConsoleLoggerFactory
            = new LoggerFactory(new[] {
                new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Information, true) });



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Assembly assembly = Assembly.GetExecutingAssembly();
            /*string resourceName = "Stocks.Data.Models.Seeds.AMEX.csv";
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
            var csvParser = new CsvParser<StockTicker>(csvParserOptions, new CsvStockTickerMapping());
            var records = csvParser.ReadFromFile("Seeds/AMEX.csv", Encoding.UTF8).ToList();
            foreach (var ticker in records)
            {
                modelBuilder.Entity<StockTicker>().HasData(ticker);
            }*/
            /*using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    
                    CsvReader csvReader = new CsvReader(reader);
                    //csvReader.Configuration.WillThrowOnMissingField = false;
                    var records = csvReader.GetRecords<StockTicker>().Distinct().ToArray();

                }
            }*/
        }
    }
}