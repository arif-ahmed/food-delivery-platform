using FoodDeliveryPlatform.SharedKernel;

namespace FoodDeliveryPlatform.Domain.Restaurant
{
    public class MenuItem : Entity<Guid>
    {
        public MenuItem(Guid id) : base(id)
        {
        }
    }
}
