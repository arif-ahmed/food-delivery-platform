using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        /**
            Method	Endpoint	Description	Domain Command Triggered
            POST	/carts	Create a new session/cart.	CreateCart
            GET	/carts/{cartId}	Retrieve current items and total.	GetCartDetails
            POST	/carts/{cartId}/items	Add a dish to the cart.	AddItemToCart
            PUT	/carts/{cartId}/items/{itemId}	Update quantity (e.g., +1 pizza).	UpdateItemQuantity
            DELETE	/carts/{cartId}/items/{itemId}	Remove an item.	RemoveItemFromCart
            POST	/carts/{cartId}/checkout	Transition from Cart to Order.	PlaceOrder (Starts the OTP flow)
        **/
        public CartsController()
        {
        }

        [HttpGet("{cartId}")]
        public IActionResult Get(Guid cartId) 
        {
            return Ok(cartId);
        }

        [HttpPost]
        public IActionResult Post() 
        {
            // Create a new cart

            return Ok();
        }

        [HttpPost("{cartId}/items")]
        public IActionResult AddItemToCart(Guid cartId, Guid itemId, int quantity) 
        {
            // Add item to cart
            return Ok();
        }

        [HttpPut("{cartId}/items/{itemId}")]
        public IActionResult UpdateItemQuantity(Guid cartId, Guid itemId, int quantity) 
        {
            // Update item quantity
            return Ok();
        }

        [HttpDelete]
        public IActionResult RemoveItemFromCart(Guid cartId, Guid itemId)
        {
            // Remove item from cart
            return NoContent();
        }
    }
}
