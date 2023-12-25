using StockMarket.Domain.Entities;
using StockMarket.Infrastructure.DBContext;

namespace StockMarket.WebApi
{
    public static class DataSeeder
    {
        public static void SeedData(ApplicationDbContext context)
        {
            Random random = new Random();

            var stocks = new List<Stock> 
            {
                new Stock() { Id = 1, Name = "Vianet", Price = random.Next(1, 101) },
                new Stock() { Id = 2, Name = "Agritek", Price = random.Next(1, 101) },
                new Stock() { Id = 3, Name = "Akamai", Price = random.Next(1, 101) },
                new Stock() { Id = 4, Name = "Baidu", Price = random.Next(1, 101) },
                new Stock() { Id = 5, Name = "Blinkx", Price = random.Next(1, 101) },
                new Stock() { Id = 6, Name = "Blucora", Price = random.Next(1, 101) },
                new Stock() { Id = 7, Name = "Boingo", Price = random.Next(1, 101) },
                new Stock() { Id = 8, Name = "Brainybrawn", Price = random.Next(1, 101) },
                new Stock() { Id = 9, Name = "Carbonite", Price = random.Next(1, 101) },
                new Stock() { Id = 10, Name = "China Finance", Price = random.Next(1, 101) },
                new Stock() { Id = 11, Name = "ChinaCache", Price = random.Next(1, 101) },
                new Stock() { Id = 12, Name = "ADR", Price = random.Next(1, 101) },
                new Stock() { Id = 13, Name = "ChitrChatr", Price = random.Next(1, 101) },
                new Stock() { Id = 14, Name = "Cnova", Price = random.Next(1, 101) },
                new Stock() { Id = 15, Name = "Cogent", Price = random.Next(1, 101) },
                new Stock() { Id = 16, Name = "Crexendo", Price = random.Next(1, 101) },
                new Stock() { Id = 17, Name = "CrowdGather", Price = random.Next(1, 101) },
                new Stock() { Id = 18, Name = "EarthLink", Price = random.Next(1, 101) },
                new Stock() { Id = 19, Name = "Eastern", Price = random.Next(1, 101) },
                new Stock() { Id = 20, Name = "ENDEXX", Price = random.Next(1, 101) },
                new Stock() { Id = 21, Name = "Envestnet", Price = random.Next(1, 101) },
                new Stock() { Id = 22, Name = "Epazz", Price = random.Next(1, 101) },
                new Stock() { Id = 23, Name = "FlashZero", Price = random.Next(1, 101) },
                new Stock() { Id = 24, Name = "Genesis", Price = random.Next(1, 101) },
                new Stock() { Id = 25, Name = "InterNAP", Price = random.Next(1, 101) },
                new Stock() { Id = 26, Name = "MeetMe", Price = random.Next(1, 101) },
                new Stock() { Id = 27, Name = "Netease", Price = random.Next(1, 101) },
                new Stock() { Id = 28, Name = "Qihoo", Price = random.Next(1, 101) }
            };

            context.Stocks.AddRange(stocks);
            context.SaveChanges();
        }
    }

}
