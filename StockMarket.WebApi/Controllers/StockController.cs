namespace StockMarket.WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StockMarket.ApplicationService.DTOs;
    using StockMarket.ApplicationService.Services.Interfaces;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStocks()
        {
            var stocks = await _stockService.GetAllStocksAsync();
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStock(int id)
        {
            var stock = await _stockService.GetStockByIdAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStockPrice(int id, [FromBody] decimal newPrice)
        {
            try
            {
                await _stockService.UpdateStockPriceAsync(id, newPrice);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddStock([FromBody] StockDto stockDto)
        {
            await _stockService.AddNewStockAsync(stockDto);
            return CreatedAtAction(nameof(GetStock), new { id = stockDto.ID }, stockDto);
        }

    }

}
