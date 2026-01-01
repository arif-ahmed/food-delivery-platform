
using FoodDeliveryPlatform.SharedKernel.Abstractions;

namespace FoodDeliveryPlatform.SharedKernel
{
    public abstract class Entity<TId> : IEntity<TId>
    {
        public TId Id { get; private set; }

        protected Entity(TId id)
        {
            Id = id;
        }
    }
}
