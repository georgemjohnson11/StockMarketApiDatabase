using System;

namespace Stocks.Data.Models
{
    public class StockTicker
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime UpdatedTime { get; set; }
        public DateTime IPOYear { get; set; }
        public DateTime LastSale { get; set; }
        public decimal MarketCap { get; set; }
        public decimal ADR_TSO { get; set; }
        public string Industry { get; set; }
        public string Sector { get; set; }
        public string Country { get; set; }
        public bool Active { get; set; }
        public bool IsCurrency { get; set; }
    }
}
