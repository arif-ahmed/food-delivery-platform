using FoodDeliveryPlatform.SharedKernel.Abstractions;
using FoodDeliveryPlatform.Application.Cart.Dtos;

namespace FoodDeliveryPlatform.Application.Cart.Queries.GetCart
{
    public class GetCartQuery : IQuery<CartDto?>
    {
        public Guid CustomerId { get; set; }
        
        public GetCartQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }

    public class GetCartHandler : IQueryHandler<GetCartQuery, CartDto?>
    {
        private readonly Abstractions.ICartRepository _cartRepository;

        public GetCartHandler(Abstractions.ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartDto?> HandleAsync(GetCartQuery query, CancellationToken cancellationToken = default)
        {
            var cart = await _cartRepository.GetByIdAsync(query.CustomerId, cancellationToken);
            if (cart == null) return null;

            // Simple mapping - in real app use AutoMapper or Manual mapping method
            return new CartDto
            {
                Id = cart.Id,
                CustomerId = cart.Id, // Assuming CartId == CustomerId or mapped
                TotalPrice = 0, // Calculate from items
                Items = new List<CartItemDto>() // Map items
            };
        }
    }
}
