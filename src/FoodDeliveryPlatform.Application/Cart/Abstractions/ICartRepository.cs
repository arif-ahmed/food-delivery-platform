using FoodDeliveryPlatform.SharedKernel.Abstractions;
using FoodDeliveryPlatform.Domain.Carts;

namespace FoodDeliveryPlatform.Application.Cart.Abstractions
{
    public interface ICartRepository : IRepository<FoodDeliveryPlatform.Domain.Carts.Cart>
    {
    }
}
