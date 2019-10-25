using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Stocks.Data.Models;
using YahooFinanceApi;

namespace Stocks.Domain.Controllers
{
    [Produces("application/json")]
    public class ViewsStockDataController : Controller
    {
        [Route("~/api/{ticker}/{start}/{end}")]
        [HttpGet]
        public List<StockHistory> GetStockData(ViewsStockDataController instance, string ticker, string start,string end)
        {
            var startDate = DateTime.Parse(start);
            var endDate = DateTime.Parse(end);
            ticker = ticker.ToUpper();
            List<StockHistory> models = new List<StockHistory>();
            try
            {
                using (var db = new StockDbContext())
                {
                    foreach (StockHistory history in db.StockHistories
                        .Where(b => b.Ticker.Equals(ticker) && b.Date > startDate && b.Date < endDate).ToList<StockHistory>())
                    {
                        models.Add(history);
                    }
                }
            }
            catch
            {

            }
            return models;
        }
    }
}
