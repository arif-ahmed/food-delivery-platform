using FoodDeliveryPlatform.SharedKernel;

namespace FoodDeliveryPlatform.Domain.Restaurant
{
    public class Menu : Entity<Guid>
    {
        public Menu(Guid id) : base(id)
        {
        }
    }
}
