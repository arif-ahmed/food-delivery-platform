using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDeliveryPlatform.Domain.Restaurant.ValueObjects
{
    public sealed record Money(decimal Amount, string Currency)
    {
        public static Money Of(decimal amount, string currency)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot be negative.");
            if (string.IsNullOrWhiteSpace(currency)) throw new ArgumentException("Currency is required.", nameof(currency));
            return new Money(decimal.Round(amount, 2), currency.ToUpperInvariant());
        }
    }
}
