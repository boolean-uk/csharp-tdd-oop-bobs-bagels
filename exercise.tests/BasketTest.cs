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
        private Filling filling;
        private Bagel bagel;
        private Inventory inventory;

        [SetUp]
        public void SetUp() // Arrange step for all tests
        {
            basket = new Basket(); 
            filling = new Filling();
            bagel = new Bagel();
            inventory = new Inventory();
        }

        [Test]
        public void AddBagelVariantToBasket()
        {
            //Act
            Bagel bagel = new Bagel("Onion");
            bool result = basket.AddBagelVariantToBasket(bagel);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveBagelVariantFromBasket()
        {
            //Act
            Bagel bagel = new Bagel("Plain");
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
            //Act
            Inventory item = new Inventory("BGLO", 0.49, "Bagel", "Onion");
            basket.GetBasketList().Add(item);

            string result = basket.CanRemoveItemInBasket(item);

            //Assert
            Assert.That(result, Is.EqualTo("Item is in basket and can be removed."));
        }

        [Test]
        public void TotalCostOfItems()
        {
            //Act
            basket.GetBasketList().Add(new Inventory("BGLO", 0.49, "Bagel", "Onion"));
            basket.GetBasketList().Add(new Inventory("BGLP", 0.39, "Bagel", "Plain"));

            double result = basket.TotalCostOfItems();

            //Assert
            Assert.That(result, Is.EqualTo(0.88));
        }

        [Test]
        public void ReturnCostOfBagel()
        {
            //Act
            Bagel bagel = new Bagel("Onion");
            double result = basket.ReturnCostOfBagel(bagel);

            //Assert
            Assert.That(result, Is.EqualTo(0.49));
        }

        [Test]
        public void ChooseBagelFilling()
        {
            //Act
            Filling filling = new Filling("FILB");
            string result = basket.ChooseBagelFilling(filling);

            //Assert
            Assert.That(result, Is.EqualTo("Bacon"));
        }

        [Test]
        public void CostOfEachFilling()
        {
            //Act
            Filling filling = new Filling("FILC");
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
            Assert.IsTrue(result, "The item should exist in the inventory.");
        }
    }
}
