using FoodDeliveryPlatform.SharedKernel;
using FoodDeliveryPlatform.SharedKernel.Abstractions;

namespace FoodDeliveryPlatform.Domain.Carts
{
    public class Cart : Entity<Guid>, IAggregateRoot
    {
        private readonly List<CartItem> _items = new List<CartItem>();

        public Guid CustomerId { get; private set; }

        public Cart(Guid id, Guid customerId) : base(id)
        {
            CustomerId = customerId;
        }

        public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

        public static Cart Create(Guid customerId)
        {
            return new Cart(Guid.CreateVersion7(), customerId);
        }

        public void AddCartItem(Guid productId, int quantity)
        {
            _items.Add(new CartItem(productId, quantity));
        }

        public void UpdateQuantity(Guid productId, int newQuantity)
        {
            var item = _items.Find(i => i.ProductId == productId);
            if (item != null)
            {
                item.Quantity = newQuantity;
            }
        }

        public void RemoveCartItem(Guid productId)
        {
            _items.RemoveAll(i => i.ProductId == productId);
        }

        public void ApplyCoupon(string couponCode)
        {
            // Implementation for applying coupon
        }

        public void Clear() 
        {
            _items.Clear();
        }

        public int CalculateTotalAmount(Func<Guid, int, int> priceCalculator)
        {
            int totalAmount = 0;
            foreach (var item in _items)
            {
                totalAmount += priceCalculator(item.ProductId, item.Quantity);
            }

            return totalAmount;
        }

    }
}
