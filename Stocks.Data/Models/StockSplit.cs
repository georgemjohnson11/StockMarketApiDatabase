using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stocks.Data.Models
{
    public class StockSplits
    {
        public int Id { get; set; }
        public string StockId { get; set; }
        public short Factor { get; set; }
        public DateTime SplitTimestamp { get; set; }

        [ForeignKey("StockId")]
        public StockHistory Stock { get; set; }

    }
}
