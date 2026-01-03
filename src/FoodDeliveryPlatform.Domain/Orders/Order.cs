using FoodDeliveryPlatform.SharedKernel;
using FoodDeliveryPlatform.SharedKernel.Abstractions;

namespace FoodDeliveryPlatform.Domain.Orders
{
    public class Order : Entity<Guid>, IAggregateRoot
    {
        public Guid CustomerId { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public decimal TotalAmount { get; private set; }
        
        private readonly List<OrderItem> _orderItems = new();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public Order(Guid id, Guid customerId, DateTime createdAt, OrderStatus status) : base(id)
        {
            CustomerId = customerId;
            CreatedAt = createdAt;
            Status = status;
        }

        public static Order Create(Guid customerId, List<OrderItem> items)
        {
            var order = new Order(Guid.CreateVersion7(), customerId, DateTime.UtcNow, OrderStatus.Pending);
            order._orderItems.AddRange(items);
            order.CalculateTotal();
            return order;
        }

        private void CalculateTotal()
        {
            TotalAmount = _orderItems.Sum(x => x.Price * x.Quantity);
        }
    }

    public class OrderItem
    {
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public OrderItem(Guid productId, string productName, decimal price, int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }
    }

    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Preparing,
        OutForDelivery,
        Delivered,
        Cancelled
    }
}
