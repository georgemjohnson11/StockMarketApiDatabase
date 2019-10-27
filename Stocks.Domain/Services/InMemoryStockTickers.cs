using System.Collections.Generic;
using System.Linq;
using Stocks.Data.Models;
using Stocks.Data.Services;

namespace Stocks.Domain.Services
{
    public class InMemoryStockTickerService : IStockTickerService
    {
        private readonly List<StockTicker> _stockTickers = new List<StockTicker>();
        private string _currentId = "GOOG";
        
        public IReadOnlyCollection<StockTicker> GetAll()
        {
            return _stockTickers.AsReadOnly();
        }

        public StockTicker GetById(string ticker)
        {
            return _stockTickers.SingleOrDefault(g => g.Id == ticker);
        }

        public StockTicker Update(StockTicker stockTickers)
        {
            var toUpdate = _stockTickers.SingleOrDefault(g => g.Id == stockTickers.Id);

            if (toUpdate == null)
            {
                return null;
            }

            toUpdate.Name = stockTickers.Name;
            return toUpdate;
        }

        public StockTicker Add(StockTicker stockTickers)
        {
            _stockTickers.Add(stockTickers);
            return stockTickers;
        }
    }
}