using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stocks.Data.Models
{
    public class ExchangeRates

    {
        public int Id { get; set; }
        public string CurrencyFromId { get; set; }
        public string CurrencyToId { get; set; }
        public short Ratio { get; set; }
        public DateTime RateTime { get; set; }

        [ForeignKey("CurrencyFromId")]
        public StockHistory StockFromId { get; set; }
        [ForeignKey("CurrencyToId")]
        public StockHistory StockToId { get; set; }


    }
}
