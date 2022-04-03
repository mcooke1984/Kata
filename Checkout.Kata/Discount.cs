using System.Collections.Generic;

namespace Checkout.Kata
{
    /// <summary>
    /// Used to apply discounts to the items in the shopping basket.
    /// </summary>
    public class Discount
    {
        /// <summary>
        /// Used to calculate discount when buying items in groups.
        /// </summary>
        /// <param name="itemsInBasket">Items in the basket.</param>
        /// <param name="sku">This is the item we are applying the discount to.</param>
        /// <param name="group">This value denotes how we are grouping in the promotion.</param>
        /// <param name="discountToBeTakenOff">This value indicates how much discount is being applied.</param>
        /// <param name="asPercentage">Are we applying the discount by percentage or not.</param>
        /// <returns>The discount to be removed from the total cost.</returns>
        public decimal DiscountByGroup(Dictionary<Item, int> itemsInBasket, string sku, int group, decimal discountToBeTakenOff, bool asPercentage)
        {
            int totalItemsToDiscount = 0;
            decimal runningTotal = 0;

            foreach (var item in itemsInBasket)
            {
                if (item.Key.Sku == sku)
                {
                    totalItemsToDiscount += item.Value;
                    runningTotal += item.Key.Price * item.Value;
                }
            }

            int totalGroupsToDiscount = totalItemsToDiscount / group;

            if (totalGroupsToDiscount == 0) { return 0; }

            if (asPercentage)
            {
                return (discountToBeTakenOff / 100) * runningTotal;
            }
            else
            {
                return totalGroupsToDiscount * discountToBeTakenOff;
            }
        }
    }
}
