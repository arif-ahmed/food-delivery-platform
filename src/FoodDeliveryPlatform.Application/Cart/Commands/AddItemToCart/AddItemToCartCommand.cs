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
            var cart = await _cartRepository.GetAsync(command.CustomerId, cancellationToken);
            
            if (cart is null)
            {
                cart = FoodDeliveryPlatform.Domain.Carts.Cart.Create(command.CustomerId);
            }

            // Ideally use Domain Logic here, e.g., cart.AddItem(...)
            // cart.AddItem(command.ProductId, command.Quantity);

            await _cartRepository.UpdateAsync(cart, cancellationToken);

            return new Result(true);
        }
    }
}
