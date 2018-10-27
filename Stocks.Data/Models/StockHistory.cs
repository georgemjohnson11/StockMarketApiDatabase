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
        public decimal Ask { get; set; }
        public decimal AverageDailyVolume10Day { get; set; }
        public decimal AverageDailyVolume3Month { get; set; }
        public decimal Bid { get; set; }
        public decimal BookValue { get; set; }
        public DateTime DividendDate { get; set; }
        public DateTime EarningsTimestamp { get; set; }
        public DateTime EarningsTimestampEnd { get; set; }
        public DateTime EarningsTimestampStart { get; set; }
        public decimal FiftyDayAverage { get; set; }
        public decimal FiftyDayAverageChange { get; set; }
        public decimal FiftyDayAverageChangePercent { get; set; }
        public decimal FiftyTwoWeekHigh { get; set; }
        public decimal FiftyTwoWeekHighChange { get; set; }
        public decimal FiftyTwoWeekHighChangePercent { get; set; }
        public decimal FiftyTwoWeekLow { get; set; }
        public decimal FiftyTwoWeekLowChange { get; set; }
        public decimal FiftyTwoWeekLowChangePercent { get; set; }
        public decimal RegularMarketChangePercent { get; set; }
        public decimal RegularMarketDayHigh { get; set; }
        public decimal RegularMarketDayLow { get; set; }
        public decimal RegularMarketOpen { get; set; }
        public decimal RegularMarketPreviousClose { get; set; }
        public decimal RegularMarketPrice { get; set; }
        public decimal RegularMarketVolume { get; set; }
        public decimal TwoHundredDayAverage { get; set; }
        public decimal TwoHundredDayAverageChange { get; set; }
        public decimal TwoHundredDayAverageChangePercent { get; set; }

        [ForeignKey("Ticker")]
        public StockTickers StockTicker { get; set; }

    }
}
