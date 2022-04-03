using System.Collections.Generic;

namespace Checkout.Kata
{
    /// <summary>
    /// Used to calculate the total price of items in the shopping basket.
    /// </summary>
    /// <param name="itemsInBasket">The items in the basket.</param>
    /// <returns>The total price including any discount from promotions.</returns>    
    public class Checkout
    {
        public decimal CalculatePrice(Dictionary<Item, int> itemsInBasket)
        {
            decimal total = 0;

            foreach (KeyValuePair<Item, int> item in itemsInBasket)
            {
                total += item.Key.Price * item.Value;
            }

            Discount discount = new Discount();

            // TODO put the discounts in a database table/config file.
            // Due to time these values (B, 3, 5) etc are static.
            // In the example given '3 for 40' we can say for every 3 instances of item B we can take 5 off.
            total -= discount.DiscountByGroup(itemsInBasket, "B", 3, 5, false);

            // Similar for applying a percentage discount, pass the item, the grouping and percentage discount.
            total -= discount.DiscountByGroup(itemsInBasket, "D", 2, 25, true);

            return total;
        }
    }
}
