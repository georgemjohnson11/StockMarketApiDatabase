using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stocks.Data.Models
{
    public class Earnings
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime EarningsDate { get; set; }
        public string Ticker { get; set; }
        public int FromPortfolioId { get; set; }
        public int FromAccountId { get; set; }

        [ForeignKey("Ticker")]
        public StockTicker StockTicker { get; set; }
        [ForeignKey("FromPortfolioId")]
        public Portfolio PortfolioId { get; set; }
        [ForeignKey("FromAccountId")]
        public Accounts AccountId { get; set; }





    }
}
