using FoodDeliveryPlatform.Domain.Carts;

namespace FoodDeliveryPlatform.Application.Cart.Abstractions
{
    public interface ICartRepository
    {
        Task<FoodDeliveryPlatform.Domain.Carts.Cart?> GetAsync(Guid customerId, CancellationToken cancellationToken = default);
        Task UpdateAsync(FoodDeliveryPlatform.Domain.Carts.Cart cart, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid customerId, CancellationToken cancellationToken = default);
    }
}
