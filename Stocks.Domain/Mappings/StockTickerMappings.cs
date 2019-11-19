using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Stocks.Data.Models;

namespace Stocks.Domain.Mappings
{
    internal static class StockTickerMappings
    {
        public static StockTicker ToModel(this StockTicker entity)
        {
            return entity != null
                ? new StockTicker { Id = entity.Id, Name = entity.Name }
                : null;
        }

        public static StockTicker ToServiceModel(this StockTicker model)
        {
            return model != null
                ? new StockTicker { Id = model.Id, Name = model.Name }
                : null;
        }

        public static IReadOnlyCollection<StockTicker> ToModel(this IReadOnlyCollection<StockTicker> entities)
            => entities.MapCollection(ToModel);
    }
}