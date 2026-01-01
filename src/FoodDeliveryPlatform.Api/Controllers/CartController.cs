using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public CartController()
        {
        }

        [HttpGet("{id: guid}")]
        public IActionResult Get(Guid id) 
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post() 
        {
            return Ok();
        }
    }
}
