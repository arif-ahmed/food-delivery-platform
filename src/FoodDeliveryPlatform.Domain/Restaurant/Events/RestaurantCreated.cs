using FoodDeliveryPlatform.SharedKernel.Abstractions;

namespace FoodDeliveryPlatform.Domain.Restaurant.Events
{
    public class RestaurantCreated : IDomainEvent
    {
        public string RestaurantName { get; set; } = default!;
        public DateTimeOffset OccurredOn { get; } = DateTimeOffset.UtcNow;
    }
}
