using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stocks.Data.Models;
using Stocks.Data.Services;
using Stocks.Domain.Mappings;
using Serilog;

namespace Stocks.Domain.Controllers
{
    [Route("stocktickers")]
    public class StockTickerController : ControllerBase
    {
        private readonly IStockTickerService _stockTickerService;

        public StockTickerController(IStockTickerService stockTickerService)
        {
            Log.Debug("Starting up StockTickerController");

            _stockTickerService = stockTickerService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<StockTicker>> GetAllAsync(CancellationToken ct)
        {
            Log.Debug("Getting All StockTickers");
            var response = await _stockTickerService.GetAllAsync(ct);
            return Ok(response.ToService());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(string ticker, CancellationToken ct)
        {
            Log.Debug("Getting a StockTickers");

            var stockTicker =  await _stockTickerService.GetByIdAsync(ticker, ct);
            if (stockTicker == null)
            {
                return NotFound();
            }
            return Ok(stockTicker);
        }

        [HttpPut]
        [Route("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateAsync(string ticker, StockTicker model, CancellationToken ct)
        {
            var stockTicker =  await _stockTickerService.UpdateAsync(model.ToEntity(), ct);
            stockTicker.Id = ticker;

            if (stockTicker == null)
            {
                return NotFound();
            }
            return Ok(stockTicker.ToService());

        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> AddAsync(StockTicker model, CancellationToken ct)
        {
            model.Id = "GOOG";
            var stockTicker = await _stockTickerService.AddAsync(model.ToEntity(), ct);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = stockTicker.Id }, stockTicker.ToEntity());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> RemoveAsync(string ticker, CancellationToken ct)
        {
            await _stockTickerService.RemoveAsync(ticker, ct);
            return NoContent();
        }
    }
}