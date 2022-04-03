using System.Collections.Generic;

namespace Checkout.Kata
{
    /// <summary>
    /// Used to hold items in the shopping basket, pass in an item together with its quantity.
    /// </summary>
    public class Basket
    {
        public Dictionary<Item, int> ItemsInBasket = new Dictionary<Item, int>();
    }
}
