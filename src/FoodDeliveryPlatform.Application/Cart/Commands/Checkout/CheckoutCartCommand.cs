using FoodDeliveryPlatform.SharedKernel.Abstractions;

namespace FoodDeliveryPlatform.Application.Cart.Commands.Checkout
{
    public class CheckoutCartCommand : ICommand
    {
        public Guid CustomerId { get; set; }
    }

    public class CheckoutCartHandler : ICommandHandler<CheckoutCartCommand>
    {
        private readonly Abstractions.ICartRepository _cartRepository;
        // In a real scenario, you'd likely depend on IOrderService or similar here

        public CheckoutCartHandler(Abstractions.ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Result> HandleAsync(CheckoutCartCommand command, CancellationToken cancellationToken = default)
        {
            var cart = await _cartRepository.GetAsync(command.CustomerId, cancellationToken);
            if (cart is null)
            {
                return new Result(false, new[] { "Cart is empty or not found." });
            }

            // TODO: Raise integration event (e.g. CartCheckedOut) or call Order Service
            // For now, we just clear the cart
            
            await _cartRepository.DeleteAsync(command.CustomerId, cancellationToken);

            return new Result(true);
        }
    }
}
