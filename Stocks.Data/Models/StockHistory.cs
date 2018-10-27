using System;

namespace Stocks.Data.Models
{
    public class StockHistory
    {
        public string Id { get; set; }
        public DateTime History { get; set; }
        public short Open { get; set; }
        public short Close { get; set; }
        public short Volume { get; set; }


    }
}
