using Microsoft.AspNetCore.Mvc;
using Stocks.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YahooFinanceApi;

namespace Stocks.Domain.Controllers
{
    [Produces("application/json")]
    public class ApiStockDataController : Controller
    {
        [Route("~/api/generate/{ticker}/{start}/{end}/{period}")]
        [HttpGet]
        public async Task<List<StockHistory>> GetStockData(ApiStockDataController instance, string ticker, string start,string end, string period)
        {
            var p = Period.Daily;
            if (period.ToLower() == "weekly") p = Period.Weekly;
            else if (period.ToLower() == "monthly") p = Period.Monthly;
            var startDate = DateTime.Parse(start);
            var endDate = DateTime.Parse(end);
            ticker = ticker.ToUpper();
            var hist = await Yahoo.GetHistoricalAsync(ticker, startDate, endDate, p);
            List<StockHistory> models = new List<StockHistory>();
            try
            {
                using (var db = new StockDbContext())
                {

                    foreach (var r in hist)
                    {
                        db.Add(new StockHistory
                        {
                            Ticker = db.StockTickers
                                       .Single(d => d.Id == ticker).Id,
                            Date = r.DateTime,
                            Open = r.Open,
                            High = r.High,
                            Low = r.Low,
                            Close = r.Close,
                            AdjustedClose = r.AdjustedClose,
                            Volume = r.Volume
                        });
                        models.Add(new StockHistory
                        {
                            Ticker = ticker,
                            Date = r.DateTime,
                            Open = r.Open,
                            High = r.High,
                            Low = r.Low,
                            Close = r.Close,
                            AdjustedClose = r.AdjustedClose,
                            Volume = r.Volume
                        });
                    }
                    db.SaveChanges();
                }
                var dividendhistory = await Yahoo.GetDividendsAsync(ticker, startDate, endDate);
                using (var db = new StockDbContext())
                {
                    foreach (var r in dividendhistory)
                    {
                        var tickerUpdate = db.StockHistories
                                             .Single(d => d.Ticker == ticker && d.Date.Equals(r.DateTime));
                        tickerUpdate.Dividend = r.Dividend;
                        db.StockHistories.Update(tickerUpdate);
                    }
                    db.SaveChanges();
                }
            }
            catch
            {

            }
            return models;
        }
    }
}
