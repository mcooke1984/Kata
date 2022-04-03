using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Checkout.Kata.Tests
{
    [TestClass]
    public class CheckoutTests
    {
        [TestMethod]
        public void CreateAnItem()
        {
            // Arrange
            Item item = new Item("A", 10);

            // Assert
            Assert.AreEqual(item.Sku, "A");
            Assert.AreEqual(item.Price, 10);
        }

        [TestMethod]
        public void AddItemsToTheBasket()
        {
            // Arrange
            Item itemB = new Item("B", 15);
            Item itemD = new Item("D", 55);

            // Act
            Basket basket = new Basket();
            basket.ItemsInBasket.Add(itemB, 11);
            basket.ItemsInBasket.Add(itemD, 22);

            // Assert
            foreach (var item in basket.ItemsInBasket)
            {
                if (item.Key.Sku == "B") {
                    Assert.AreEqual(item.Key.Price, 15);
                    Assert.AreEqual(item.Value, 11);
                }

                if (item.Key.Sku == "D")
                {
                    Assert.AreEqual(item.Key.Price, 55);
                    Assert.AreEqual(item.Value, 22);
                }
            }
        }

        [TestMethod]
        public void AddSingleItemsToBasketAndCheckOut()
        {
            // Arrange
            Item itemA = new Item("A", 10);
            Item itemB = new Item("B", 15);
            Item itemC = new Item("C", 40);
            Item itemD = new Item("D", 55);

            // Act
            Basket basket = new Basket();
            basket.ItemsInBasket.Add(itemA, 1);
            basket.ItemsInBasket.Add(itemB, 1);
            basket.ItemsInBasket.Add(itemC, 1);
            basket.ItemsInBasket.Add(itemD, 1);

            Checkout checkout = new Checkout();
            decimal total = checkout.CalculatePrice(basket.ItemsInBasket);

            // Assert
            Assert.AreEqual(total, 120);
        }

        [TestMethod]
        public void AddSmallAmountOfItemsToBasketAndCheckOut()
        {
            // Arrange
            Item itemA = new Item("A", 10);
            Item itemB = new Item("B", 15);
            Item itemC = new Item("C", 40);
            Item itemD = new Item("D", 55);

            // Act
            Basket basket = new Basket();
            basket.ItemsInBasket.Add(itemA, 1); // 1 * 10 = 10
            basket.ItemsInBasket.Add(itemB, 3); // 3 * 15 = 45 (Minus 5 in discount)
            basket.ItemsInBasket.Add(itemC, 1); // 1 * 40 = 40
            basket.ItemsInBasket.Add(itemD, 2); // 2 * 55 = 110 (Minus 27.5)

            Checkout checkout = new Checkout();
            decimal total = checkout.CalculatePrice(basket.ItemsInBasket);

            // Assert
            Assert.AreEqual(total, 172.50m);
        }

        [TestMethod]
        public void AddLargeAmountOfItemsToBasketAndCheckOut()
        {
            // Arrange
            Item itemA = new Item("A", 10);
            Item itemB = new Item("B", 15);
            Item itemC = new Item("C", 40);
            Item itemD = new Item("D", 55);

            // Act
            Basket basket = new Basket();
            basket.ItemsInBasket.Add(itemA, 100); // 100 * 10 = 1000
            basket.ItemsInBasket.Add(itemB, 100); // 100 * 15 = 1500 (Minus 165 in discount)
            basket.ItemsInBasket.Add(itemC, 100); // 100 * 40 = 4000
            basket.ItemsInBasket.Add(itemD, 100); // 100 * 55 = 5500 (Minus 1375 in discount)

            Checkout checkout = new Checkout();
            var total = checkout.CalculatePrice(basket.ItemsInBasket);

            // Assert
            Assert.AreEqual(total, 10460m);
        }

        [TestMethod]
        public void AddMultipleItemsToBasketAndCheckOut()
        {
            // Arrange
            Item item1 = new Item("A", 10);
            Item item2 = new Item("B", 15);
            Item item3 = new Item("C", 40);
            Item item4 = new Item("D", 55);

            Item item5 = new Item("A", 10);
            Item item6 = new Item("B", 15);
            Item item7 = new Item("C", 40);
            Item item8 = new Item("D", 55);

            // Act
            Basket basket = new Basket();
            basket.ItemsInBasket.Add(item1, 100); // 100 * 10 = 1000
            basket.ItemsInBasket.Add(item2, 100); // 100 * 15 = 1500 (Minus 165 in discount)
            basket.ItemsInBasket.Add(item3, 100); // 100 * 40 = 4000
            basket.ItemsInBasket.Add(item4, 100); // 100 * 55 = 5500 (Minus 1375 in discount)

            basket.ItemsInBasket.Add(item5, 100); // 100 * 10 = 1000
            basket.ItemsInBasket.Add(item6, 100); // 100 * 15 = 1500 (Minus 165 in discount)
            basket.ItemsInBasket.Add(item7, 100); // 100 * 40 = 4000
            basket.ItemsInBasket.Add(item8, 100); // 100 * 55 = 5500 (Minus 1375 in discount)

            Checkout checkout = new Checkout();
            var total = checkout.CalculatePrice(basket.ItemsInBasket);

            // Assert
            Assert.AreEqual(total, 20920m);
        }
    }
}
