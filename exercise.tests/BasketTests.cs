using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main;
using static System.Formats.Asn1.AsnWriter;

namespace exercise.tests
{
    public class BasketTests
    {
        private Basket basket;

        [SetUp]
        public void SetUp()
        {
            basket = new Basket();
            basket.AddBagel("Cream", 20);
            basket.AddBagel("Cream", 30, "Cola");
            basket.AddBagel("Cheese", 15);
        }

        [TestCase("Peanut", 20, true)]
        [TestCase("", 30, false)]
        [TestCase("Cream", 37, true)]
        public void AddedBagel(string bagelType, int cost, bool expected)
        {
            bool haveAdded = basket.AddBagel(bagelType, cost);
            Assert.That(expected, Is.EqualTo(haveAdded));
        }

        [TestCase("Cream", "Cola", true)]
        [TestCase("", "Sweets", false)]
        [TestCase("Cheese", "", true)]
        public void RemovedBagel(string bagelType, string fillingName, bool expected)
        {
            bool haveAdded = basket.RemoveBagel(bagelType, fillingName);
            Assert.That(expected, Is.EqualTo(haveAdded));
        }

        [Test]
        public void IsBasketFull()
        {
            bool full = basket.BasketFull();
            Assert.That(false, Is.EqualTo(full));
        }

        [Test]
        public void IncreasedCapacity()
        {
            int oldCapacity = basket.IncreaseCapacity(7);
            int newCapacity = basket.IncreaseCapacity(8);
            Assert.That(oldCapacity, Is.LessThan(newCapacity));
        }

        [Test]
        public void TooMuchCapacity()
        {
            int oldCapacity = basket.IncreaseCapacity(7);
            int newCapacity = basket.IncreaseCapacity(-1);
            Assert.That(oldCapacity, Is.EqualTo(newCapacity));
        }

        [TestCase("Cream", true)]
        [TestCase("Jam", false)]
        [TestCase("Dressing", false)]
        public void ItemDoesExist(string bagelType, bool expected)
        {
            bool removed = basket.RemoveBagel(bagelType, "");
            Assert.That(expected, Is.EqualTo(removed));
        }

        [TestCase("Cream", 40)]
        [TestCase("Jam", 30)]
        [TestCase("Dressing", 5)]
        public void CostOfBagelType(string bagelType, int cost)
        {
            Bagel bagel = new Bagel(bagelType, cost);
            int result = bagel.CostOfBagel(bagelType);
            Assert.That(cost, Is.EqualTo(result));
        }

        [Test]
        public void GetAllFillings()
        {
            Filling filling = new Filling();
            string allFillings = filling.AllFillings();

            Assert.That("Cola, Mayonaise, Jelly", Is.EqualTo(allFillings));
        }

        [Test]
        public void GetAllFillingCosts()
        {
            Filling filling = new Filling();
            string allFillings = filling.FillingCosts();

            Assert.That("Cola:20, Mayonaise:30, Jelly:15", Is.EqualTo(allFillings));
        }

        [Test]
        public void GetAllItems()
        {
            Inventory inventory = new Inventory();
            string items = inventory.PrintInventory();

            Assert.That("Bagels, Fillings", Is.EqualTo(items));
        }
    }
}
