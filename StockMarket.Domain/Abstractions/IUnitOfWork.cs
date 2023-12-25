using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Domain.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IStockRepository StockRepository { get; }
        IOrderRepository OrderRepository { get; }
        Task CommitAsync();  // Commits all changes
    }

}
