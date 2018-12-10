using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stocks.Data.Models
{
    public class StockHistory
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal Close { get; set; }
        public decimal AdjustedClose { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Volume { get; set; }
        public bool Active { get; set; }
        public bool IsCurrency { get; set; }
        public decimal Dividend { get; set; }
        [ForeignKey("Ticker")]
        public StockTicker StockTicker { get; set; }

    }
}
