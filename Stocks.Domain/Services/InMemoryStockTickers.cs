using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Stocks.Data.Models;
using Stocks.Data.Services;

namespace Stocks.Domain.Services
{
    public class InMemoryStockTickerService : IStockTickerService
    {
        private static readonly Random RandomGenerator = new Random();
        private readonly List<StockTicker> _stockTickers = new List<StockTicker>();
        private string _currentId = "GOOG";
        
        public async Task<IReadOnlyCollection<StockTicker>> GetAllAsync(CancellationToken ct)
        {
            await Task.Delay(1000, ct);
            return await Task.FromResult<IReadOnlyCollection<StockTicker>>(_stockTickers.AsReadOnly());
        }

        public async Task<StockTicker> GetByIdAsync(string ticker, CancellationToken ct)
        {
            await Task.Delay(1000, ct);
            return await Task.FromResult(_stockTickers.SingleOrDefault(g => g.Id == ticker));
        }

        public async Task<StockTicker> UpdateAsync(StockTicker stockTickers, CancellationToken ct)
        {
            var toUpdate = _stockTickers.SingleOrDefault(g => g.Id == stockTickers.Id);

            if (toUpdate == null)
            {
                return null;
            }

            toUpdate.Name = stockTickers.Name;
            return await Task.FromResult(toUpdate);
        }

        public async Task<StockTicker> AddAsync(StockTicker stockTickers, CancellationToken ct)
        {
            await Task.Delay(5000, ct);
            _stockTickers.Add(stockTickers);
            return await Task.FromResult(stockTickers);
        }

        private async Task<int> CallExternalServiceAsync(int multiplier, CancellationToken ct)
        {
            await Task.Delay(1000 * multiplier);
            return RandomGenerator.Next();
        }
    }
}