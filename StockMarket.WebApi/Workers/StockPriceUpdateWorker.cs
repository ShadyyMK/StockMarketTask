using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using StockMarket.ApplicationService.Services.Interfaces;
using StockMarket.WebApi.Hubs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StockMarket.WebApi.Workers
{
    public class StockPriceUpdateWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHubContext<StockPriceHub> _hubContext;
        private readonly TimeSpan _updateInterval = TimeSpan.FromSeconds(10);

        public StockPriceUpdateWorker(IServiceProvider serviceProvider, IHubContext<StockPriceHub> hubContext)
        {
            _serviceProvider = serviceProvider;
            _hubContext = hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var stockService = scope.ServiceProvider.GetRequiredService<IStockService>();
                    await UpdateStockPricesAsync(stockService);
                }

                await Task.Delay(_updateInterval, stoppingToken);
            }
        }

        private async Task UpdateStockPricesAsync(IStockService stockService)
        {
            var stocks = await stockService.GetAllStocksAsync();

            foreach (var stock in stocks)
            {
                var newPrice = GenerateRandomPrice();
                await stockService.UpdateStockPriceAsync(stock.ID, newPrice);
            }

            stocks = await stockService.GetAllStocksAsync(); // Reload updated stock prices
            await _hubContext.Clients.All.SendAsync("ReceiveStockPriceUpdate", stocks);
        }

        private decimal GenerateRandomPrice()
        {
            Random random = new Random();
            return random.Next(1, 101); // Random price between 1 and 100
        }
    }
}
