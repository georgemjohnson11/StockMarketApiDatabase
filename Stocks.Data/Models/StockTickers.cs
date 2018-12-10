using System;
using TinyCsvParser;
using TinyCsvParser.Mapping;
using TinyCsvParser.TypeConverter;

namespace Stocks.Data.Models
{
    public class StockTicker
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime UpdatedTime { get; set; }
        public DateTime IPOYear { get; set; }
        public decimal LastSale { get; set; }
        public decimal MarketCap { get; set; }
        public decimal ADR_TSO { get; set; }
        public string Industry { get; set; }
        public string Sector { get; set; }
        public string Country { get; set; }
        public bool Active { get; set; }
        public bool IsCurrency { get; set; }
        public string ExchangeMarket { get; set; }


        /*public StockTicker GetStockTickerById(string inputId)
        {
            using (var db = new StockDbContext())
            {
                               
            }
        }*/
    }

    public class CsvStockTickerMapping : CsvMapping<StockTicker>
    {
        public CsvStockTickerMapping() : base()
        {
            MapProperty(0, x => x.Id);
            MapProperty(1, x => x.Name);
            MapProperty(3, x => x.MarketCap);
            MapProperty(4, x => x.ADR_TSO);
            MapProperty(5, x => x.IPOYear);
            MapProperty(6, x => x.Sector);
            MapProperty(7, x => x.Industry);


        }
    }

    /*class CsvStockTickerMapping : ITypeConverter<StockTicker>
    {
        public Type TargetType => typeof(DateTime);

        public bool TryConvert(string value, out DateTime result)
        {
            try
            {
                result = Convert.ToDecimal(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }*/
}
