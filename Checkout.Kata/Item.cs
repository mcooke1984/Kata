using System;

namespace Checkout.Kata
{
    /// <summary>
    /// Item to be added to the shopping basket.
    /// </summary>
    /// <param name="sku">Name of the item.</param>
    /// <param name="price">The price of the item.</param>
    public class Item
    {
        public Item()
        {
        }

        public Item(string sku, decimal price)
        {
            Price = price;
            Sku = sku;
            Id = Guid.NewGuid();
        }

        public readonly string Sku;
        public readonly decimal Price;
        private Guid Id;
    }
}
