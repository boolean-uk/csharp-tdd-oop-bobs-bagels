using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using exercise.main;

namespace exercise.tests
{
    public class BasketTest
    {
        private Basket basket;
        private List<Inventory> basketList;
        private List<Bagel> bagelList;
        private List<Inventory> inventoryList;

        private Bagel bagel; 
        private Filling filling;
        private Inventory inventoryItem;

        [SetUp]
        public void SetUp() // Arrange step for some of the tests
        {
            basketList = new List<Inventory>();
            bagelList = new List<Bagel>();
            inventoryList = new List<Inventory>
            {
                new Inventory("BGLO", 0.49, "Bagel", "Onion"),
                new Inventory("BGLP", 0.39, "Bagel", "Plain"),
                new Inventory("BGLE", 0.49, "Bagel", "Everything"),
                new Inventory("BGLS", 0.49, "Bagel", "Sesame"),
                new Inventory("COFB", 0.99, "Coffee", "Black"),
                new Inventory("COFW", 1.19, "Coffee", "White"),
                new Inventory("COFC", 1.29, "Coffee", "Cappuccino"),
                new Inventory("COFL", 1.29, "Coffee", "Latte"),
                new Inventory("FILB", 0.12, "Filling", "Bacon"),
                new Inventory("FILE", 0.12, "Filling", "Egg"),
                new Inventory("FILC", 0.12, "Filling", "Cheese"),
                new Inventory("FILX", 0.12, "Filling", "Cream Cheese"),
                new Inventory("FILS", 0.12, "Filling", "Smoked Salmon"),
                new Inventory("FILH", 0.12, "Filling", "Ham")
            };
            basket = new Basket(basketList, bagelList, inventoryList);
        }

        [Test]
        public void AddBagelVariantToBasket()
        {
            //Arrange
            bagel = new Bagel("Onion");

            //Act
            bool result = basket.AddBagelVariantToBasket(bagel);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveBagelVariantFromBasket()
        {
            //Arrange
            bagel = new Bagel("Plain");

            //Act
            basket.AddBagelVariantToBasket(bagel);

            bool result = basket.RemoveBagelVariantFromBasket(bagel);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void BagelBasketIsFull()
        {
            //Act
            for (int i = 0; i < 5; i++)
            {
                basket.GetBasketList().Add(new Inventory($"Item{i}", 0.5, "Item", $"Variant{i}"));
            }

            string result = basket.BagelBasketIsFull();

            //Assert
            Assert.That(result, Is.EqualTo("Basket is full!"));
        }

        [Test]
        public void ChangeBasketCapacity()
        {
            //Act
            string result = basket.ChangeBasketCapacity(10);

            //Assert
            Assert.That(result, Is.EqualTo("Basket capacity is changed."));
            Assert.AreEqual(10, basket.GetBasketSize());
        }

        [Test]
        public void CanRemoveItemInBasket()
        {
            //Arrange
            inventoryItem = new Inventory("BGLO", 0.49, "Bagel", "Onion");

            //Act
            basket.GetBasketList().Add(inventoryItem);

            string result = basket.CanRemoveItemInBasket(inventoryItem);

            //Assert
            Assert.That(result, Is.EqualTo("Item is in basket and can be removed."));
        }

        [Test]
        public void TotalCostOfItems()
        {
            //Arrange
            basket.GetBasketList().Add(new Inventory("BGLO", 0.49, "Bagel", "Onion"));
            basket.GetBasketList().Add(new Inventory("BGLP", 0.39, "Bagel", "Plain"));

            //Act
            double result = basket.TotalCostOfItems();

            //Assert
            Assert.That(result, Is.EqualTo(0.88));
        }

        [Test]
        public void ReturnCostOfBagel()
        {
            //Arrange
            bagel = new Bagel("Onion");

            //Act
            double result = basket.ReturnCostOfBagel(bagel);

            //Assert
            Assert.That(result, Is.EqualTo(0.49));
        }

        [Test]
        public void ChooseBagelFilling()
        {
            //Arrange
            filling = new Filling("FILB");

            //Act
            string result = basket.ChooseBagelFilling(filling);

            //Assert
            Assert.That(result, Is.EqualTo("Bacon"));
        }

        [Test]
        public void CostOfEachFilling()
        {
            //Arrange
            filling = new Filling("FILC");

            //Act
            double result = basket.CostOfEachFilling(filling);

            //Assert
            Assert.That(result, Is.EqualTo(0.12));
        }

        [Test]
        public void MustBeInInventory()
        {
            //Act
            bool result = basket.MustBeInInventory("BGLO");

            //Assert
            Assert.IsTrue(result, "The item should exist in the inventoryItem.");
        }
    }
}
