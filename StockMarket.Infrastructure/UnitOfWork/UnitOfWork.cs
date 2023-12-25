using StockMarket.Domain.Abstractions;
using StockMarket.Infrastructure.DBContext;
using System.Threading.Tasks;

namespace StockMarket.Infrastructure.UnitOfWork
{


    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IStockRepository StockRepository { get; }
        public IOrderRepository OrderRepository { get; }

        public UnitOfWork(ApplicationDbContext context, IStockRepository stockRepository, IOrderRepository orderRepository)
        {
            _context = context;
            StockRepository = stockRepository;
            OrderRepository = orderRepository;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
