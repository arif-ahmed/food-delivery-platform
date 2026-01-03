using FoodDeliveryPlatform.SharedKernel.Abstractions;

namespace FoodDeliveryPlatform.Application.Cart.Commands.RemoveItemFromCart
{
    public class RemoveItemFromCartCommand : ICommand
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
    }

    public class RemoveItemFromCartHandler : ICommandHandler<RemoveItemFromCartCommand>
    {
        private readonly Abstractions.ICartRepository _cartRepository;

        public RemoveItemFromCartHandler(Abstractions.ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Result> HandleAsync(RemoveItemFromCartCommand command, CancellationToken cancellationToken = default)
        {
            // Implementation pending
            return new Result(true);
        }
    }
}
