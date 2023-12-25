using AutoMapper;
using StockMarket.ApplicationService.DTOs;
using StockMarket.ApplicationService.Services.Interfaces;
using StockMarket.Domain.Abstractions;
using StockMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.ApplicationService.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StockService(IStockRepository stockRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StockDto>> GetAllStocksAsync()
        {
            var stocks = await _stockRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StockDto>>(stocks);
        }

        public async Task<StockDto> GetStockByIdAsync(int stockId)
        {
            var stock = await _stockRepository.GetByIdAsync(stockId);
            if (stock == null) return null;

            return _mapper.Map<StockDto>(stock);
        }

        public async Task UpdateStockPriceAsync(int stockId, decimal newPrice)
        {
            var stock = await _stockRepository.GetByIdAsync(stockId);
            if (stock == null)
                throw new Exception("Stock not found");

            stock.UpdatePrice(newPrice); 
            await _stockRepository.UpdateAsync(stock);
            await _unitOfWork.CommitAsync();
        }

        public async Task AddNewStockAsync(StockDto stockDto)
        {
            var stock = _mapper.Map<Stock>(stockDto);
            await _stockRepository.AddAsync(stock);
            await _unitOfWork.CommitAsync();
        }

    }

}
