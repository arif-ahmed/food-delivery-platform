using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDeliveryPlatform.Domain.Orders
{
    public class Order
    {
    }

    public class OrderItem     
    {
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
