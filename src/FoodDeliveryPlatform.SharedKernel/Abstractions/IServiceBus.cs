namespace FoodDeliveryPlatform.SharedKernel.Abstractions
{
    public interface IServiceBus
    {
        Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : IDomainEvent;
    }
}
