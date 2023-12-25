using StockMarket.ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.ApplicationService.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        public Task<OrderDto> GetOrderByIdAsync(int orderId);
        public Task<int> PlaceOrderAsync(OrderCreateOrUpdateDto orderDto);
        public Task UpdateOrderAsync(int orderId, OrderCreateOrUpdateDto updatedOrderDto);
    }
}
