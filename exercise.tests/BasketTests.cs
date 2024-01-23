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
            Person user = new Person("TestPerson");
            Basket basket = user.GetBasket();

            // Act
            bool res = basket.AddItemToBasket(SKU);

            // Assert
            Assert.That(res, Is.EqualTo(shouldWork));
        }

        [Test]
        public void AddToBasketItemTest() 
        {
            // Arrange
            Person user = new Person("TestPerson");
            Basket basket = user.GetBasket();

            IProduct item1 = new Coffee("COFW", 1.19f);
            IProduct item2 = new Bagel("BGLP", 0.39f);
            IProduct item3 = new Bagel("AAAA", 0.39f);
            IProduct item4 = new Bagel("COFW", 0f);

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
            Person Bob = new Person("Bob", true);
            Basket basket1 = Bob.GetBasket();

            Person Alice = new Person("Alice");
            Basket basket2 = Alice.GetBasket();

            // Act
            int res1 = basket1.SetBasketSize(newSize); // Is admin so should return new size of basket.
            int res2 = basket2.SetBasketSize(newSize); // Is not admin so should return 0.

            // Assert
            Assert.That(res1, Is.EqualTo(newSize));
            Assert.That(res2, Is.EqualTo(0));

        }

        [Test]
        [TestCase(0,2, (0.49f+ 1.19f))]
        [TestCase(1,2, (0.39f+ 1.19f))]
        public void GetBasketPrizeTest(int add, int add2, float expectValue) 
        {
            // Arrange
            Person user = new Person("TestPerson");
            Basket basket = user.GetBasket();
            IProduct[] set = new IProduct[] { (new Bagel("BGLE", 0.49f)), new Bagel("BGLP", 0.39f), new Coffee("COFW", 1.19f)  };
            basket.AddItemToBasket(set[add]);
            basket.AddItemToBasket(set[add2]);


            // Act
            float res = basket.GetBasketPrice();

            // Assert
            Assert.That(res, Is.EqualTo(expectValue));
        }

        [Test]
        public void RemoveProductFromBasketTest() 
        {
            // Arrange
            Person user = new Person("TestPerson");
            Basket basket = user.GetBasket();
            
            IProduct product1 = new Coffee("COFW", 1.19f);
            IProduct product2 = new Coffee("COFL", 1.19f);

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
            Person user = new Person("TestPerson");
            Basket basket = user.GetBasket();
            // Default capacity = 13
            IProduct prod = new Coffee("COFW", 1.19f);
            int maxBasketSize = 13;
            for (int i = 0; i < maxBasketSize-1; i++) 
            { 
                basket.AddItemToBasket(prod); 
            }

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
