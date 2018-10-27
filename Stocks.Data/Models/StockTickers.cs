using System;

namespace Stocks.Data.Models
{
    public class StockTickers
    {
        public string Id { get; set; }
        public DateTime History { get; set; }
        public decimal Open { get; set; }
        public decimal Close { get; set; }
        public decimal AdjustedClose { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Volume { get; set; }
        public bool Active { get; set; }
        public bool IsCurrency { get; set; }
    }
}
