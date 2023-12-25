using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StockMarket.ApplicationService.DTOs;
using StockMarket.ApplicationService.Services.Interfaces;
using StockMarket.Domain.Abstractions;
using StockMarket.Domain.Entities;

namespace StockMarket.ApplicationService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
            //return orders.Select(o => new OrderDto
            //{
            //    Id = o.Id,
            //    PersonName = o.PersonName,
            //    Price = o.Price,
            //    Quantity = o.Quantity,
            //    StockId = o.StockId
            //});
        }
        public async Task<OrderDto> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null) return null;

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<int> PlaceOrderAsync(OrderCreateOrUpdateDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.AddAsync(order);
            await _unitOfWork.CommitAsync();
            return order.Id;
        }

        public async Task UpdateOrderAsync(int orderId, OrderCreateOrUpdateDto updatedOrderDto)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new Exception("Order not found"); 

            _mapper.Map(updatedOrderDto, order);
            await _orderRepository.UpdateAsync(order);
            await _unitOfWork.CommitAsync();
        }
    }

}
