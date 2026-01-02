namespace FoodDeliveryPlatform.Domain.Carts
{
    public class Cart
    {
        private readonly List<CartItem> _items = new List<CartItem>();

        public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

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
