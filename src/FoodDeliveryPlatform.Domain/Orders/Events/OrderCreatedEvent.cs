using FoodDeliveryPlatform.SharedKernel.Abstractions;

namespace FoodDeliveryPlatform.Domain.Orders.Events
{
    public record OrderCreatedEvent(Guid OrderId, Guid CustomerId, decimal TotalAmount) : IDomainEvent
    {
        public DateTimeOffset OccurredOn { get; } = DateTimeOffset.UtcNow;
    }
}
