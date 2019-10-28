using System;
using System.Collections.Generic;
using Stocks.Data.Services;
using Stocks.Domain.Services;
using Stocks.Data.Models;
using Autofac;
using Serilog;

namespace Microsoft.Extensions.DependencyInjection
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryStockTickerService>().Named<IStockTickerService>("stocktickersService").SingleInstance();
            builder.RegisterDecorator<IStockTickerService>((context, service) => new StockTickerServiceDecorator(service), "stocksService");
        }

        private class StockTickerServiceDecorator : IStockTickerService
        {
            private readonly IStockTickerService _inner;

            public StockTickerServiceDecorator(IStockTickerService inner)
            {
                _inner = inner;
            }

            public IReadOnlyCollection<IStockTickerService> GetAll()
            {
                Log.Information($"######### Helloooooo from {nameof(GetAll)} #########");
                return (IReadOnlyCollection<IStockTickerService>)_inner.GetAll();
            }

            public StockTicker GetById(string ticker)
            {
                Log.Information($"######### Helloooooo from {nameof(GetById)} #########");
                return _inner.GetById(ticker);
            }

            public StockTicker Update(StockTicker stockTicker)
            {
                Log.Information($"######### Helloooooo from {nameof(Update)} #########");
                return _inner.Update(stockTicker);
            }

            public StockTicker Add(StockTicker stockTicker)
            {
                Log.Information($"######### Helloooooo from {nameof(Add)} #########");
                return _inner.Add(stockTicker);
            }

            IReadOnlyCollection<StockTicker> IStockTickerService.GetAll()
            {
                return _inner.GetAll();
            }
        }
    }
}