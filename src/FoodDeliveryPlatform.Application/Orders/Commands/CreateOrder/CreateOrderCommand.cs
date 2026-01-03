using FoodDeliveryPlatform.SharedKernel.Abstractions;
using FoodDeliveryPlatform.Application.Cart.Abstractions;
using FoodDeliveryPlatform.Application.Orders.Abstractions;
using FoodDeliveryPlatform.Domain.Orders;
using FoodDeliveryPlatform.Domain.Orders.Events;

namespace FoodDeliveryPlatform.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : ICommand
    {
        public Guid CustomerId { get; set; }
    }

    public class CreateOrderHandler : ICommandHandler<CreateOrderCommand>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IServiceBus _serviceBus;

        public CreateOrderHandler(ICartRepository cartRepository, IOrderRepository orderRepository, IServiceBus serviceBus)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
            _serviceBus = serviceBus;
        }

        public async Task<Result> HandleAsync(CreateOrderCommand command, CancellationToken cancellationToken = default)
        {
            // 1. Get Cart
            var cart = await _cartRepository.GetAsync(command.CustomerId, cancellationToken);
            if (cart is null || !cart.Items.Any())
            {
                return new Result(false, new[] { "Cart is empty or not found." });
            }

            // 2. Create Order Domain Object
            var orderItems = cart.Items.Select(i => new OrderItem(i.ProductId, i.ProductName, i.UnitPrice, i.Quantity)).ToList();
            var order = Order.Create(command.CustomerId, orderItems);

            // 3. Persist Order
            await _orderRepository.AddAsync(order, cancellationToken);

            // 4. Publish Event
            var orderCreatedEvent = new OrderCreatedEvent(order.Id, order.CustomerId, order.TotalAmount);
            await _serviceBus.PublishAsync(orderCreatedEvent, cancellationToken);

            // 5. Clear Cart (Removed to adhere to SRP - now handled by ClearCartOnOrderCreatedHandler)
            // await _cartRepository.DeleteAsync(command.CustomerId, cancellationToken);


            return new Result(true);
        }
    }
}
