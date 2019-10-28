using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Stocks.Data.Models;

namespace Stocks.Domain.Mappings
{
    public static class StockTickerMappings
    {
        public static StockTicker ToModel(this StockTicker model)
        {
            return model != null ? new StockTicker { Id = model.Id, Name = model.Name } : null;
        }

        public static StockTicker ToServiceModel(this StockTicker model)
        {
            return model != null ? new StockTicker { Id = model.Id, Name = model.Name } : null;
        }

        public static IReadOnlyCollection<StockTicker> ToModel(this IReadOnlyCollection<StockTicker> models)
        {
            if (models.Count == 0)
            {
                return Array.Empty<StockTicker>();
            }

            var stockTickers = new StockTicker[models.Count];
            var i = 0;
            foreach (var model in models)
            {
                stockTickers[i] = model.ToModel();
                ++i;
            }

            return new ReadOnlyCollection<StockTicker>(stockTickers);
        }
    }
}