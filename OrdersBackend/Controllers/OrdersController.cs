using Microsoft.AspNetCore.Mvc;
using OrdersBackend.BL.Dtos;
using OrdersBackend.BL.Interfaces;


namespace OrdersBackend.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly Serilog.ILogger _logger;

        public OrdersController(IOrderService orderService,
            Serilog.ILogger logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            return await _orderService.GetAllAsync();
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> AddOrder(OrderDto order)
        {
            try
            {
                _logger.Information("Add Order operation has started");

                var savedOrder = await _orderService.AddOrderAsync(order);

                _logger.Information("Add Order operation finished");

                return Ok(savedOrder);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error during Add Order controller execution");
                return StatusCode(500);
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(OrderDto updatedOrder)
        {
            try
            {
                _logger.Information("Update Order operation has started");

                var savedOrder = await _orderService.UpdateOrderAsync(updatedOrder);

                _logger.Information("Update Order operation finished");

                return Ok(savedOrder);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error during Update Order controller execution");
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                _logger.Information("Delete Order operation has started");

                await _orderService.DeleteOrderAsync(id);

                _logger.Information("Delete Order operation finished");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error during Delete Order controller execution");
                return StatusCode(500);
            }
        }
    }
}
