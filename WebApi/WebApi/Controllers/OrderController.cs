using WebApi.Models;
using WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly OrderService _orderService;

        public OrderController(OrderService orderService) =>
        _orderService = orderService;

        [HttpGet]
        public async Task<List<Order>> Get() =>
        await _orderService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Order>> Get(string id)
        {
            var order = await _orderService.GetAsync(id);

            if (order is null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Order newOrder)
        {
            await _orderService.CreateAsync(newOrder);

            return CreatedAtAction(nameof(Get), new { id = newOrder.OrderID }, newOrder);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Order updatedOrder)
        {
            var order = await _orderService.GetAsync(id);

            if (order is null)
            {
                return NotFound();
            }

            updatedOrder.OrderID = order.OrderID;

            await _orderService.UpdateAsync(id, updatedOrder);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var order = await _orderService.GetAsync(id);

            if (order is null)
            {
                return NotFound();
            }

            await _orderService.RemoveAsync(id);

            return NoContent();
        }

    }
}
