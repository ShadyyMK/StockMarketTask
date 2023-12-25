namespace StockMarket.WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StockMarket.ApplicationService.DTOs;
    using StockMarket.ApplicationService.Services.Interfaces;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderCreateOrUpdateDto orderDto)
        {
            var orderId = await _orderService.PlaceOrderAsync(orderDto);
            return CreatedAtAction(nameof(GetOrder), new { id = orderId }, orderDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderCreateOrUpdateDto orderDto)
        {
            try
            {
                await _orderService.UpdateOrderAsync(id, orderDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}
