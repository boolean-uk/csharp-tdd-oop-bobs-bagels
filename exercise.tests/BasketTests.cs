using exercise.main;
using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    [TestFixture]
    public class BasketTests
    {
        [Test]
        [TestCase(new string[] { "COFB" }, true)] // Coffee - Black
        [TestCase(new string[] { "COFL" }, true)] // Coffee - Latte
        [TestCase(new string[] { "BGLO", "FILE" }, true)] // Bagel with onion, egg filling
        [TestCase(new string[] { "BGLO", "FILE", "FILS" }, true)] // Bagel with onion, egg and salmon filling
        [TestCase(new string[] { "ABCD"}, false)] // Should be false
        [TestCase(new string[] { "ABCD", "EFGH" }, false)] // Should be false
        public void AddToBasketSKUTest(string[] SKU, bool shouldWork) 
        {
            // Arrange
            Basket basket = new Basket();

            // Act
            bool res = basket.AddItemToBasket(SKU);

            // Assert
            Assert.That(res, Is.EqualTo(shouldWork));
        }

        [Test]
        public void AddToBasketItemTest() 
        {
            // Arrange
            Basket basket = new Basket();
            Product item1 = new Coffee("COFW", 1.19f);
            Product item2 = new Bagel("BGLP", 0.39f);
            Product item3 = new Bagel("AAAA", 0.39f);
            Product item4 = new Bagel("COFW", 0f);

            // Act
            bool res1 = basket.AddItemToBasket(item1);
            bool res2 = basket.AddItemToBasket(item2);
            bool res3 = basket.AddItemToBasket(item3);
            bool res4 = basket.AddItemToBasket(item4);

            // Assert
            Assert.That(res1, Is.True);
            Assert.That(res2, Is.True);
            Assert.That(res3, Is.False);
            Assert.That(res4, Is.False);

        }

        [Test]
        [TestCase(7)]
        [TestCase(10)]
        [TestCase(3)]
        public void SetBasketSizeTest(int newSize) 
        {
            // Arrange
            Basket basket = new Basket();

            // Act
            int res = basket.SetBasketSize(newSize);

            // Assert
            Assert.That(res, Is.EqualTo(newSize));

        }

        [Test]
        public void RemoveProductFromBasketTest() 
        {
            // Arrange
            Basket basket = new Basket();
            
            Product product1 = new Coffee("COFW", 1.19f);
            Product product2 = new Coffee("COFL", 1.19f);

            string[] strings1 = new string[] { "BGLO", "FILE" };
            string[] strings2 = new string[] { "BGLP", "FILE" };

            basket.AddItemToBasket(product1);
            basket.AddItemToBasket(strings1);

            // Act
            bool res1 = basket.RemoveProductFromBasket(product1);
            bool res2 = basket.RemoveProductFromBasket(product2);
            bool res3 = basket.RemoveProductFromBasket(strings1);
            bool res4 = basket.RemoveProductFromBasket(strings2);

            // Assert
            Assert.That(res1, Is.True);
            Assert.That(res2, Is.False);
            Assert.That(res3, Is.True);
            Assert.That(res4, Is.False);

        }

        [Test]
        public void IsFullTest() 
        {
            // Arrange
            Basket basket = new Basket();
            // Default capacity = 5
            Product prod = new Coffee("COFW", 1.19f);
            basket.AddItemToBasket(prod);
            basket.AddItemToBasket(prod);
            basket.AddItemToBasket(prod);
            basket.AddItemToBasket(prod);

            // Act
            bool res1 = basket.IsFull();
            basket.AddItemToBasket(prod);
            bool res2 = basket.IsFull();

            // Assert
            Assert.That(res1, Is.False);
            Assert.That(res2, Is.True);

        }
    }
}
