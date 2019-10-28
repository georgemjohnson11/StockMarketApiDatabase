using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Stocks.Data.Models;


namespace Stocks.Data.Services
{

    public interface IStockTickerService
    {
        Task<IReadOnlyCollection<StockTicker>> GetAllAsync(CancellationToken ct);

        Task<StockTicker> GetByIdAsync(string ticker, CancellationToken ct);

        Task<StockTicker> UpdateAsync(StockTicker stockTicker, CancellationToken ct);

        Task<StockTicker> AddAsync(StockTicker stockTicker, CancellationToken ct);
    }
}
