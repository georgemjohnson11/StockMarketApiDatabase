using System;
using System.Collections.Generic;
using Stocks.Data.Services;
using Stocks.Domain.Services;
using Stocks.Data.Models;
using System.Threading;
using Autofac;
using Serilog;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterDecorator<IStockTickerService>((context, service) => new StockTickerServiceDecorator(service), "stocksService");
        }

        private class StockTickerServiceDecorator : IStockTickerService
        {
            private readonly IStockTickerService _inner;

            public StockTickerServiceDecorator(IStockTickerService inner)
            {
                _inner = inner;
            }

            public async Task<IReadOnlyCollection<IStockTickerService>> GetAllAsync(CancellationToken ct)
            {
                Log.Information($"######### Helloooooo from {nameof(GetAllAsync)} #########");
                return (IReadOnlyCollection<IStockTickerService>)_inner.GetAllAsync(ct);
            }

            public async Task<StockTicker> GetByIdAsync(string ticker, CancellationToken ct)
            {
                Log.Information($"######### Helloooooo from {nameof(GetByIdAsync)} #########");
                return await _inner.GetByIdAsync(ticker, ct);
            }

            public async Task<StockTicker> Update(StockTicker stockTicker, CancellationToken ct)
            {
                Log.Information($"######### Helloooooo from {nameof(Update)} #########");
                return await _inner.UpdateAsync(stockTicker, ct);
            }

            public async Task<StockTicker> Add(StockTicker stockTicker, CancellationToken ct)
            {
                Log.Information($"######### Helloooooo from {nameof(Add)} #########");
                return await _inner.AddAsync(stockTicker, ct);
            }

            Task<IReadOnlyCollection<StockTicker>> IStockTickerService.GetAllAsync(CancellationToken ct)
            {
                return _inner.GetAllAsync(ct);
            }

            public Task<StockTicker> UpdateAsync(StockTicker stockTicker, CancellationToken ct)
            {
                return _inner.UpdateAsync(stockTicker, ct);
            }

            public Task<StockTicker> AddAsync(StockTicker stockTicker, CancellationToken ct)
            {
                return _inner.AddAsync(stockTicker, ct);
            }

            public Task<StockTicker> RemoveAsync(StockTicker stockTicker, CancellationToken ct)
            {
                return _inner.RemoveAsync(stockTicker, ct);
            }
        }
    }
}