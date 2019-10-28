using System.Threading;
using System.Threading.Tasks;
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

        public async Task<IActionResult> IndexAsync(CancellationToken ct)
        {
            var result = await _stockTickerService.GetAllAsync(ct);
            return View("Index", result.ToViewModel());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> DetailsAsync(string ticker, CancellationToken ct)
        {
            var stockTicker =  await _stockTickerService.GetByIdAsync(ticker, ct);
            if (stockTicker == null)
            {
                return NotFound();
            }
            return View(stockTicker.ToViewModel());
        }

        [HttpPost]
        [Route("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(string ticker, StockTicker model)
        {
            var stockTicker =  await _stockTickerService.UpdateAsync(model.ToServiceModel(), ct);

            if(stockTicker == null)
            {
                return NotFound();
            }
            stockTicker.Name = model.Name;
            return RedirectToAction("Index", stockTicker.ToViweModel());

        }

        [HttpGet]
        [Route("create")]
        public IActionResult CreateNew()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public async IActionResult Create(StockTicker model)
        {
            using (var db = new StockDbContext())
            {
                db.StockTickers.Add(model);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}