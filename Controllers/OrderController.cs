using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unitofwork.Model;
using Unitofwork.Service;

namespace Unitofwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService) {
            _orderService = orderService;
        }

        [HttpPost("SaveOrder")]
        public async Task<IActionResult> SaveOrder(OrderRequest orderRequest)
        {
            try
            {
                var orderId = await _orderService.SaveOrderasync(orderRequest);
                return Ok(new { OrderId = orderId });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    } 
}
