using StockMarket.ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.ApplicationService.Services.Interfaces
{
    public interface IStockService
    {
        public Task<IEnumerable<StockDto>> GetAllStocksAsync();
        public Task<StockDto> GetStockByIdAsync(int stockId);
        public Task UpdateStockPriceAsync(int stockId, decimal newPrice);
        public Task AddNewStockAsync(StockDto stockDto);
    }
}
