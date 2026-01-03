using FoodDeliveryPlatform.Application.Cart.Commands.AddItemToCart;
using FoodDeliveryPlatform.Application.Cart.Commands.ClearCart;
using FoodDeliveryPlatform.Application.Cart.Commands.RemoveItemFromCart;
using FoodDeliveryPlatform.Application.Cart.Queries.GetCart;
using FoodDeliveryPlatform.SharedKernel.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICommandHandler<AddItemToCartCommand> _addItemHandler;
        private readonly ICommandHandler<RemoveItemFromCartCommand> _removeItemHandler;
        private readonly ICommandHandler<ClearCartCommand> _clearCartHandler;
        private readonly IQueryHandler<GetCartQuery, Application.Cart.Dtos.CartDto?> _getCartHandler;

        public CartsController(
            ICommandHandler<AddItemToCartCommand> addItemHandler,
            ICommandHandler<RemoveItemFromCartCommand> removeItemHandler,
            ICommandHandler<ClearCartCommand> clearCartHandler,
            IQueryHandler<GetCartQuery, Application.Cart.Dtos.CartDto?> getCartHandler)
        {
            _addItemHandler = addItemHandler;
            _removeItemHandler = removeItemHandler;
            _clearCartHandler = clearCartHandler;
            _getCartHandler = getCartHandler;
        }

        [HttpGet("{cartId}")]
        public async Task<IActionResult> Get(Guid cartId, CancellationToken ct) 
        {
            var cart = await _getCartHandler.HandleAsync(new GetCartQuery(cartId), ct);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPost("{cartId}/items")]
        public async Task<IActionResult> AddItemToCart(Guid cartId, AddItemRequest request, CancellationToken ct) 
        {
            var command = new AddItemToCartCommand
            {
                CustomerId = cartId,
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                UnitPrice = request.UnitPrice,
                Quantity = request.Quantity
            };

            var result = await _addItemHandler.HandleAsync(command, ct);
            if (!result.IsSuccess) return BadRequest(result.Errors);

            return Ok();
        }

        [HttpDelete("{cartId}/items/{itemId}")]
        public async Task<IActionResult> RemoveItemFromCart(Guid cartId, Guid itemId, CancellationToken ct)
        {
            var command = new RemoveItemFromCartCommand
            {
                CustomerId = cartId,
                ProductId = itemId
            };

            var result = await _removeItemHandler.HandleAsync(command, ct);
            if (!result.IsSuccess) return BadRequest(result.Errors);

            return NoContent();
        }



        [HttpDelete("{cartId}")]
        public async Task<IActionResult> ClearCart(Guid cartId, CancellationToken ct)
        {
            var command = new ClearCartCommand { CustomerId = cartId };
            var result = await _clearCartHandler.HandleAsync(command, ct);
            
            if (!result.IsSuccess) return BadRequest(result.Errors);

            return NoContent();
        }

        public record AddItemRequest(Guid ProductId, string ProductName, decimal UnitPrice, int Quantity);
    }
}
