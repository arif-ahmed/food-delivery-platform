namespace FoodDeliveryPlatform.SharedKernel.Abstractions
{
    /// <summary>
    /// Marker interface that represents a command in the CQRS (Command Query Responsibility Segregation) pattern.
    /// </summary>
    /// <remarks>
    /// Implement this interface for operations that change application state (for example, creating or updating
    /// entities). The interface is intentionally empty and is used to categorize request types for command handling,
    /// validation, or dispatching infrastructure.
    /// </remarks>
    public interface ICommand
    {

    }
}
