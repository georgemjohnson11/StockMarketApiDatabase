using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Stocks.Data.Services;
using Microsoft.EntityFrameworkCore;
using Stocks.Data.Models;
using Stocks.Domain.Mappings;

namespace Stocks.Domain.Services
{
    public class StockTickersService : IStockTickerService
    {
        private readonly StockDbContext _context;

        public StockTickersService(StockDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<StockTicker>> GetAllAsync(CancellationToken ct)
        {
            var stockTickers = await _context.StockTickers.AsNoTracking().OrderBy(g => g.Id).ToListAsync(ct);
            return stockTickers.ToModel();
        }

        public async Task<StockTicker> GetByIdAsync(string id, CancellationToken ct)
        {
            var stockTickers = await _context.StockTickers.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id, ct);
            return stockTickers.ToModel();
        }

        public async Task<StockTicker> UpdateAsync(StockTicker stockTickers, CancellationToken ct)
        {
            var updatedStockTickerEntry = _context.StockTickers.Update(stockTickers.ToModel());
            await _context.SaveChangesAsync(ct);
            return updatedStockTickerEntry.Entity.ToServiceModel();
        }


        public async Task<StockTicker> AddAsync(StockTicker stockTickers, CancellationToken ct)
        {
            var addedStockTickerEntry = _context.StockTickers.Add(stockTickers.ToModel());
            await _context.SaveChangesAsync(ct);
            return addedStockTickerEntry.Entity.ToServiceModel();
        }

        public async Task<StockTicker> RemoveAsync(string ticker, CancellationToken ct)
        {
            var stockTickers = await _context.StockTickers.SingleOrDefaultAsync(g => g.Id == ticker, ct);
            if (stockTickers != null)
            {
                _context.Remove(stockTickers);
                await _context.SaveChangesAsync(ct);
            }
            return stockTickers.ToServiceModel();
        }
    }
}