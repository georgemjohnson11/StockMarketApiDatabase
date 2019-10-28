using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stocks.Data.Models;
using Stocks.Data.Services;
using Stocks.Domain.Mappings;

namespace Stocks.Domain.Controllers
{
    [Route("stocktickers")]
    public class StockTickerController : ControllerBase
    {
        private readonly IStockTickerService _stockTickerService;

        public StockTickerController(IStockTickerService stockTickerService)
        {
            _stockTickerService = stockTickerService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync(CancellationToken ct)
        {
            var result = await _stockTickerService.GetAllAsync(ct);
            return Ok(result.ToModel());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(string ticker, CancellationToken ct)
        {
            var stockTicker =  await _stockTickerService.GetByIdAsync(ticker, ct);
            if (stockTicker == null)
            {
                return NotFound();
            }
            return Ok(stockTicker.ToModel());
        }

        [HttpPost]
        [Route("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAsync(string ticker, StockTicker model, CancellationToken ct)
        {
            var stockTicker =  await _stockTickerService.UpdateAsync(model.ToServiceModel(), ct);
            stockTicker.Id = ticker;

            if (stockTicker == null)
            {
                return NotFound();
            }
            return Ok(stockTicker.ToModel());

        }

        [HttpPut]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddAsync(StockTicker model, CancellationToken ct)
        {
            model.Id = "GOOG";
            var stockTicker = await _stockTickerService.AddAsync(model.ToServiceModel(), ct);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = stockTicker.Id }, stockTicker.ToModel());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveAsync(StockTicker ticker, CancellationToken ct)
        {
            await _stockTickerService.RemoveAsync(ticker, ct);
            return NoContent();
        }
    }
}