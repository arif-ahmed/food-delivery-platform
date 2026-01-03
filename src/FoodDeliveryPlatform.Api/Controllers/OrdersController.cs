using FoodDeliveryPlatform.Application.Orders.Commands.CreateOrder;
using FoodDeliveryPlatform.SharedKernel.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ICommandHandler<CreateOrderCommand> _createOrderHandler;

        public OrdersController(ICommandHandler<CreateOrderCommand> createOrderHandler)
        {
            _createOrderHandler = createOrderHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest request, CancellationToken ct)
        {
            var command = new CreateOrderCommand { CustomerId = request.CartId };
            var result = await _createOrderHandler.HandleAsync(command, ct);

            if (!result.IsSuccess) return BadRequest(result.Errors);

            // 201 Created is ideal, but we need the OrderId. 
            // result could be enhanced to return the OrderId, but strictly following CQS Command doesn't return value.
            // For now, returning 200 OK or 201 Created without Location header is acceptable given strict CQS.
            return Ok();
        }

        public record CreateOrderRequest(Guid CartId);
    }
}
