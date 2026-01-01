namespace FoodDeliveryPlatform.SharedKernel.Abstractions
{
    /// <summary>
    /// Marker interface that identifies an entity as an aggregate root in the domain model.
    /// </summary>
    /// <remarks>
    /// In Domain-Driven Design (DDD), an aggregate root is the entry point to a consistency boundary.
    /// All access to other entities or value objects within the aggregate should go through the
    /// aggregate root. Implement this interface on entities that represent aggregate roots to make
    /// aggregate boundaries explicit and discoverable.
    /// </remarks>
    /// <summary>
    /// Marker interface that identifies an entity as an aggregate root in the domain model.
    /// </summary>
    /// <remarks>
    /// In Domain-Driven Design (DDD), an aggregate root is the entry point to a consistency boundary.
    /// All access to other entities or value objects within the aggregate should go through the
    /// aggregate root. Implement this interface on entities that represent aggregate roots to make
    /// aggregate boundaries explicit and discoverable.
    /// </remarks>
    public interface IAggregateRoot
    {

    }
}
