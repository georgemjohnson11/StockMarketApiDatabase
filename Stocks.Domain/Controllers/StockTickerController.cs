using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Stocks.Data.Models;
using Stocks.Data.Services;
using Stocks.Domain.Mappings;

namespace Stocks.Domain.Controllers
{
    [Route("stocktickers")]
    public class StockTickerController : Controller
    {
        private readonly IStockTickerService _stockTickerService;

        public StockTickerController(IStockTickerService stockTickerService)
        {
            _stockTickerService = stockTickerService;
        }

        public IActionResult Index()
        {
            return View(_stockTickerService.GetAll().ToViewModel());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(string ticker)
        {
            var stockTicker = _stockTickerService.GetById(ticker);
            if (stockTicker == null)
            {
                return NotFound();
            }
            return View(stockTicker.ToViewModel());
        }

        [HttpPost]
        [Route("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string ticker, StockTicker model)
        {
            var stockTicker = _stockTickerService.Update(model.ToServiceModel());

            if(stockTicker == null)
            {
                return NotFound();
            }
            stockTicker.Name = model.Name;
            return RedirectToAction("Index");

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
            }
            return RedirectToAction("Index");
        }
    }
}