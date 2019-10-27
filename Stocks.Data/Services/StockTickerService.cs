using System;
using System.Collections.Generic;
using Stocks.Data.Models;


namespace Stocks.Data.Services
{

    public interface IStockTickerService
    {
        IReadOnlyCollection<StockTicker> GetAll();

        StockTicker GetById(string ticker);

        StockTicker Update(StockTicker stockTicker);

        StockTicker Add(StockTicker stockTicker);
    }
}
