using FoodDeliveryPlatform.Application.Cart.Abstractions;
using FoodDeliveryPlatform.Application.Orders.Abstractions;
using FoodDeliveryPlatform.Domain.Carts;
using FoodDeliveryPlatform.Domain.Orders;
using FoodDeliveryPlatform.SharedKernel.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;

namespace FoodDeliveryPlatform.Api.Infrastructure
{
    public class InMemoryCartRepository : ICartRepository
    {
        private readonly ConcurrentDictionary<Guid, Cart> _store = new();

        public Task<Cart?> GetAsync(Guid customerId, CancellationToken cancellationToken = default)
        {
            _store.TryGetValue(customerId, out var cart);
            return Task.FromResult(cart);
        }

        public Task UpdateAsync(Cart cart, CancellationToken cancellationToken = default)
        {
            _store.AddOrUpdate(cart.CustomerId, cart, (key, oldValue) => cart);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid customerId, CancellationToken cancellationToken = default)
        {
            _store.TryRemove(customerId, out _);
            return Task.CompletedTask;
        }
    }

    public class InMemoryOrderRepository : IOrderRepository
    {
        private readonly ConcurrentDictionary<Guid, Order> _store = new();

        public Task AddAsync(Order entity, CancellationToken cancellationToken = default)
        {
            _store.TryAdd(entity.Id, entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Order entity, CancellationToken cancellationToken = default) => Task.CompletedTask;
        
        public Task<IReadOnlyCollection<Order>> GetAllAsync(CancellationToken cancellationToken = default) 
            => Task.FromResult<IReadOnlyCollection<Order>>(new List<Order>());
        
        public Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) 
            => Task.FromResult<Order?>(null);
        
        public Task UpdateAsync(Order entity, CancellationToken cancellationToken = default) => Task.CompletedTask;
    }

    public class MockServiceBus : IServiceBus
    {
        private readonly IServiceProvider _serviceProvider;

        public MockServiceBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : IDomainEvent
        {
            // Simple in-process dispatch for demonstration/testing
            using var scope = _serviceProvider.CreateScope();
            var handler = scope.ServiceProvider.GetService<IEventHandler<T>>();
            if (handler != null)
            {
                await handler.HandleAsync(@event, cancellationToken);
            }
        }
    }
}
