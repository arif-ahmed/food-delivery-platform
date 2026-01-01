using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDeliveryPlatform.Domain.Carts
{
    public class Cart
    {
        private readonly List<CartItem> _items = new List<CartItem>();

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

    }
}
