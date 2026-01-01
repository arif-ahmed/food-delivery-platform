
using FoodDeliveryPlatform.SharedKernel.Abstractions;

namespace FoodDeliveryPlatform.Application.Restaurant.Abstractions
{
    public interface IRestaurantRepository : IRepository<Domain.Restaurant.Restaurant>
    {
    }
}
