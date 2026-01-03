using FoodDeliveryPlatform.SharedKernel.Abstractions;

namespace FoodDeliveryPlatform.Application.Cart.Commands.ClearCart
{
    public class ClearCartCommand : ICommand
    {
        public Guid CustomerId { get; set; }
    }

    public class ClearCartHandler : ICommandHandler<ClearCartCommand>
    {
        private readonly Abstractions.ICartRepository _cartRepository;

        public ClearCartHandler(Abstractions.ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Result> HandleAsync(ClearCartCommand command, CancellationToken cancellationToken = default)
        {
            // Implementation pending
            return new Result(true);
        }
    }
}
