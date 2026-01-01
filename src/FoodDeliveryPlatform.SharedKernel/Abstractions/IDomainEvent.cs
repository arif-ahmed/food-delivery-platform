namespace FoodDeliveryPlatform.SharedKernel.Abstractions
{
    public interface IDomainEvent
    {
        DateTimeOffset OccurredOn { get; }
    }
}
