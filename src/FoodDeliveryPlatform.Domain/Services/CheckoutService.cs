using FoodDeliveryPlatform.Domain.Carts;
using FoodDeliveryPlatform.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDeliveryPlatform.Domain.Services
{
    public class CheckoutService
    {
        public void Checkout(Cart cart, Order order)
        {
            //if (cart == null)
            //{
            //    throw new ArgumentNullException(nameof(cart));
            //}
            //if (order == null)
            //{
            //    throw new ArgumentNullException(nameof(order));
            //}

            //order.Items = new List<OrderItem>();
            //foreach (var cartItem in cart.Items)
            //{
            //    order.Items.Add(new OrderItem
            //    {
            //        ProductId = cartItem.ProductId,
            //        Quantity = cartItem.Quantity,
            //        Price = cartItem.Price
            //    });
            //}
            //order.TotalAmount = cart.CalculateTotal();
            //order.OrderDate = DateTime.UtcNow;

            //cart.Clear();
        }
    }
}
