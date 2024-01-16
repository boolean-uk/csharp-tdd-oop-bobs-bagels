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
            Bagel bagel = new Bagel("Cream", 20);
            Bagel bagel2 = new Bagel("Cheese", 30);
            Bagel bagel3 = new Bagel("Jelly", 15);

            basket = new Basket();
            basket.AddBagel(bagel);
            basket.AddBagel(bagel2);
            basket.AddBagel(bagel3);
        }

        [TestCase("Peanut", 20, true)]
        [TestCase("", 30, false)]
        [TestCase("Cream", 37, true)]
        public void AddedBagel(string bagelType, int cost, bool expected)
        {
            Bagel bagel = new Bagel(bagelType, cost);
            bool haveAdded = basket.AddBagel(bagel);
            Assert.That(expected, Is.EqualTo(haveAdded));
        }

        [TestCase("Cream", true)]
        [TestCase("", false)]
        [TestCase("Cheese", true)]
        public void RemovedBagel(string bagelType, bool expected)
        {
            bool haveAdded = basket.RemoveBagel(bagelType);
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
            bool removed = basket.RemoveBagel(bagelType);
            Assert.That(expected, Is.EqualTo(removed));
        }
    }
}
