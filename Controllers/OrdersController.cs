using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderCraftPro.Services.Interfaces;

namespace OrderCraftPro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            try
            {
                var orders = _orderService.GetAllOrders();
                
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(Guid id)
        {
            try
            {
                var order = _orderService.GetOrder(id);
                
                if (order == null) return NotFound($"Order with ID {id} not found");
                
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
