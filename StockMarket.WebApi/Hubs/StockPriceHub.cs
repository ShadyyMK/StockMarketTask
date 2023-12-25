namespace StockMarket.WebApi.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using StockMarket.Domain.Entities;

    public class StockPriceHub : Hub
    {
        public async Task BroadcastStockPriceChange(List<Stock> updatedStocks)
        {
            await Clients.All.SendAsync("ReceiveStockPriceUpdate", updatedStocks);
        }
    }

}
