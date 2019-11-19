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
    [ApiController]
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
            return Ok(response.ToModel());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(string id, CancellationToken ct)
        {
            var stockTicker =  await _stockTickerService.GetByIdAsync(id.ToUpper(), ct);

            if (stockTicker == null)
            {
                return NotFound();
            }
            Log.Debug(stockTicker.Id);
            return Ok(stockTicker.ToServiceModel());
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        [Route("{id}")]
        public async Task<ActionResult> UpdateAsync(string id, StockTicker model, CancellationToken ct)
        {
            var stockTicker =  await _stockTickerService.UpdateAsync(model.ToModel(), ct);
            stockTicker.Id = id.ToUpper();

            if (stockTicker == null)
            {
                return NotFound();
            }
            return Ok(stockTicker.ToModel());

        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> AddAsync(StockTicker model, CancellationToken ct)
        {
            model.Id = "GOOG";
            var stockTicker = await _stockTickerService.AddAsync(model.ToModel(), ct);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = stockTicker.Id.ToUpper() }, stockTicker.ToModel());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> RemoveAsync(string id, CancellationToken ct)
        {
            await _stockTickerService.RemoveAsync(id.ToUpper(), ct);
            return NoContent();
        }
    }
}