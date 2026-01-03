using FoodDeliveryPlatform.Application.Cart.Abstractions;
using FoodDeliveryPlatform.Domain.Orders.Events;
using FoodDeliveryPlatform.SharedKernel.Abstractions;

namespace FoodDeliveryPlatform.Application.Cart.EventHandlers
{
    public class ClearCartOnOrderCreatedHandler : IEventHandler<OrderCreatedEvent>
    {
        private readonly ICartRepository _cartRepository;

        public ClearCartOnOrderCreatedHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task HandleAsync(OrderCreatedEvent @event, CancellationToken cancellationToken = default)
        {
            await _cartRepository.DeleteAsync(@event.CustomerId, cancellationToken);
        }
    }
}
