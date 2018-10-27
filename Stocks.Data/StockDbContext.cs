using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.EntityFrameworkCore;
using Stocks.Data.Models;

namespace Stocks.Data
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options)
            : base(options)
        {

        }

        public StockDbContext()
        {
        }

        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Earnings> Earnings { get; set; }
        public DbSet<ExchangeRates> ExchangeRates { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioStock> PortfolioStocks { get; set; }
        public DbSet<StockHistory> StockHistories { get; set; }
        public DbSet<StockSplits> StockSplits { get; set; }

        public static readonly LoggerFactory MyConsoleLoggerFactory
            = new LoggerFactory(new[] {
                new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Information, true) });

    }
}
