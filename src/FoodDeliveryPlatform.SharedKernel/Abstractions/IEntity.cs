namespace FoodDeliveryPlatform.SharedKernel.Abstractions
{
    public interface IEntity<out TId>
    {
        TId Id { get; }
    }
}
