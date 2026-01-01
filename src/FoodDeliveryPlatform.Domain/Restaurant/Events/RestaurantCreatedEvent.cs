using FoodDeliveryPlatform.SharedKernel.Abstractions;

namespace FoodDeliveryPlatform.Domain.Restaurant.Events
{
    public record RestaurantCreatedEvent : IDomainEvent
    {
        public Guid RestaurantId { get; set; }
        public string RestaurantName { get; set; } = default!;
        public DateTimeOffset OccurredOn { get; } = DateTimeOffset.UtcNow;     
        
        public RestaurantCreatedEvent(Guid restaurantId, string restaurantName)
        {
            RestaurantId = restaurantId;
            RestaurantName = restaurantName;
        }
    }
}
