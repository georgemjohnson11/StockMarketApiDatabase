using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stocks.Data.Models
{
    public class PortfolioStock

    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public string Ticker { get; set; }
        public DateTime PurchaseTime { get; set; }
        public short PurchaseQuantity { get; set; }
        public decimal PurchasePrice { get; set; }

        [ForeignKey("Ticker")]
        public StockTickers StockTicker { get; set; }
        [ForeignKey("PortfolioId")]
        public Portfolio Porfolio { get; set; }


    }
}
