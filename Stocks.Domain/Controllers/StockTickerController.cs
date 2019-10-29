using System.Collections.Generic;
using System.Net.Http;
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
        private const string BaseAddress = "/stocktickers";
        private readonly HttpClient _httpClient;

        public StockTickerController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<StockTicker>> GetAllAsync(CancellationToken ct)
        {
            var response = await _httpClient.GetAsync(BaseAddress, ct);
            var result = await response.Content.ReadAsAsync<IReadOnlyCollection<StockTicker>>(ct);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(string ticker, CancellationToken ct)
        {
            var stockTicker =  await _stockTickerService.GetByIdAsync(ticker, ct);
            if (stockTicker == null)
            {
                return NotFound();
            }
            return Ok(stockTicker);
        }

        [HttpPost]
        [Route("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateAsync(string ticker, StockTicker model, CancellationToken ct)
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
        public async Task<ActionResult> AddAsync(StockTicker model, CancellationToken ct)
        {
            model.Id = "GOOG";
            var stockTicker = await _stockTickerService.AddAsync(model.ToServiceModel(), ct);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = stockTicker.Id }, stockTicker.ToModel());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> RemoveAsync(StockTicker ticker, CancellationToken ct)
        {
            await _stockTickerService.RemoveAsync(ticker, ct);
            return NoContent();
        }
    }
}