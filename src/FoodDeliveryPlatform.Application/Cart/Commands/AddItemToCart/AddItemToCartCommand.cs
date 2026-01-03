using FoodDeliveryPlatform.SharedKernel.Abstractions;

namespace FoodDeliveryPlatform.Application.Cart.Commands.AddItemToCart
{
    public class AddItemToCartCommand : ICommand
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class AddItemToCartHandler : ICommandHandler<AddItemToCartCommand>
    {
        private readonly Abstractions.ICartRepository _cartRepository;

        public AddItemToCartHandler(Abstractions.ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Result> HandleAsync(AddItemToCartCommand command, CancellationToken cancellationToken = default)
        {
            // Implementation pending
            return new Result(true);
        }
    }
}
