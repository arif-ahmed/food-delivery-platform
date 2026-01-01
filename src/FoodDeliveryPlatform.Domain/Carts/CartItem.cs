using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDeliveryPlatform.Domain.Carts
{
    public class CartItem
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public CartItem(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
