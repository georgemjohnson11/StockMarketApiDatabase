using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Stocks.Data.Models;


namespace Stocks.Domain.Controllers
{
    [Route("stocks")]
    public class StockController : Controller
    {
        private static string currentStockTicker = "GOOG";
        private static List<StockTicker> stocks = new List<StockTicker>();
        public IActionResult Index()
        {
            return View(stocks);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(string ticker)
        {
            using (var db = new StockDbContext())
            {
                var stock = db.StockTickers.FirstOrDefault(g => g.Id == ticker);
                if (stock == null)
                {
                    return NotFound();
                }
                return View(stock);
                }            
        }

        [HttpPost]
        [Route("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string ticker, StockTicker model)
        {
            using (var db = new StockDbContext())
            {
                var stock = db.StockTickers.SingleOrDefault(g => g.Id == ticker);

                if(stock == null)
                {
                    return NotFound();
                }

                stock.Name = model.Name;

                stock.Name = model.Name;
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        [Route("create")]
        public IActionResult CreateNew()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(StockTicker model)
        {
            using (var db = new StockDbContext())
            {
                db.StockTickers.Add(model);
                db.SaveChanges();
                currentStockTicker = model.Id;
                stocks.Add(model);
            }
            return RedirectToAction("Index");
        }
    }
}