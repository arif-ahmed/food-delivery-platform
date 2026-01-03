using FoodDeliveryPlatform.SharedKernel.Abstractions;

namespace FoodDeliveryPlatform.Application.Orders.Abstractions
{
    public interface IOrderRepository : IRepository<Domain.Orders.Order>
    {
    }
}
