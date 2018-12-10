using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stocks.Data.Models
{
    public class ExchangeRate

    {
        public int Id { get; set; }
        public string TickerFrom { get; set; }
        public string TickerTo { get; set; }
        public short Ratio { get; set; }
        public DateTime RateTime { get; set; }

        [ForeignKey("TickerTo")]
        public StockTicker TickerFromId { get; set; }
        [ForeignKey("TickerFrom")]
        public StockTicker TickerToId { get; set; }


    }
}
