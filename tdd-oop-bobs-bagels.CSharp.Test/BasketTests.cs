using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using tdd_oop_bobs_bagels.CSharp.Main;

namespace tdd_oop_bobs_bagels.CSharp.Test
{
    [TestFixture]
    public class BasketTests
    {
        private Basket _basket;

        [SetUp]
        public void Setup()
        {
            var inventoryPrices = new Dictionary<string, double>
            {
                 { "BGLO", 0.49 },
                 { "BGLP", 0.39 },
                 { "BGLE", 0.49 },
                 { "BGLS", 0.49 },
                 { "COFB", 0.99 },
                 { "COFW", 1.19 },
                 { "COFC", 1.29 },
                 { "COFL", 1.29 },
                 { "FILB", 0.12 },
                 { "FILE", 0.12 },
                 { "FILC", 0.12 },
                 { "FILX", 0.12 },
                 { "FILS", 0.12 },
                 { "FILH", 0.12 }
             };

            _basket = new Basket(1, inventoryPrices);
        }

        [Test]
        public void BasketIsFull()
        {
            Bagel bagel1 = new Bagel("BGLO", "Cinnamon Raisin", 0.49);
            Bagel bagel2 = new Bagel("BGLE", "Everything", 0.49);

            _basket.AddBagel(bagel1);
            _basket.AddBagel(bagel2);

            bool isFull = _basket.IsFull();
            Assert.IsTrue(isFull);
        }

        [Test]
        public void ChangeBasketCapacity()
        {
            Bagel blueberryBagel = new Bagel("BGLB", "Blueberry", 0.49);
            Bagel asiagoBagel = new Bagel("BGLA", "Asiago", 0.49);
            Bagel onionBagel = new Bagel("BGLO", "Onion", 0.49);
            Bagel cheddarBagel = new Bagel("BGLC", "Cheddar", 0.49);

            _basket.AddBagel(blueberryBagel);
            _basket.AddBagel(asiagoBagel);
            _basket.AddBagel(onionBagel);

            int initialCapacity = _basket.SetCapacity();

            _basket.ChangeBasketCapacity(2);

            Assert.IsTrue(_basket.AddBagel(cheddarBagel)); 
            Assert.IsFalse(_basket.AddBagel(blueberryBagel)); 

            int newCapacity = _basket.SetCapacity();

            Assert.AreEqual(2, newCapacity);
        }

        [Test]
        public void AddBagel()
        {
            Bagel plainBagel = new Bagel("BGLO", "Plain", 0.49);

            bool isAdded = _basket.AddBagel(plainBagel);

            Assert.IsTrue(isAdded);
            Assert.AreEqual(1, _basket.GetBagelCount());
        }

        [Test]
        public void GetBagelCost()
        {
            Bagel plainBagel = new Bagel("BGLP", "Plain", 0.39);
            _basket.AddBagel(plainBagel); 

            double cost = _basket.GetBagelCost("Plain");

            Assert.AreEqual(0.39, cost);
        }

        [Test]
        public void AddFillingToBagel()
        {
            Bagel bagel = new Bagel("BGLO", "Plain", 0.49);
            _basket.AddBagel(bagel);
            string fillingSKU = "FILB"; 

            double fillingPrice = _basket.AddFillingToBagel(bagel, fillingSKU);

            Assert.AreEqual(0.12, fillingPrice); 
            Assert.AreEqual(1, _basket.GetBagelCount()); 
            Assert.AreEqual("Plain with Filling", bagel.Name); 
        }

        [Test]
        public void GetBagelCount()
        {
            int count = _basket.GetBagelCount();
            Assert.AreEqual(0, count);

            Bagel plainBagel = new Bagel("BGLP", "Plain", 0.39);
            _basket.AddBagel(plainBagel);

            count = _basket.GetBagelCount();
            Assert.AreEqual(1, count);
        }

        [Test]
        public void GetTotalCost()
        {
            Bagel plainBagel = new Bagel("BGLP", "Plain", 0.39);

            _basket.AddBagel(plainBagel);

            double totalCost = _basket.GetTotalCost();

            Assert.AreEqual(0.39, totalCost); 
        }

        [Test]
        public void CheckStock()
        {
            var inventoryPrices = new Dictionary<string, double>
            {
               { "BGLO", 0.49 },
            };

            _basket = new Basket(1, inventoryPrices); 

            bool inStock = _basket.CheckStock("BGLO");
            Assert.IsTrue(inStock);
        }

        [Test]
        public void RemoveBagel()
        {
            Bagel sesameBagel = new Bagel("BGSS", "Sesame", 0.49);

            _basket.AddBagel(sesameBagel);
            bool removed = _basket.RemoveBagel(sesameBagel);

            Assert.IsTrue(removed);
            Assert.AreEqual(0, _basket.GetBagelCount());
        }

        [Test]
        public void RemoveNonExistingBagel()
        {
            Bagel poppySeedBagel = new Bagel("BGPS", "Poppy Seed", 0.49);

            bool removed = _basket.RemoveBagel(poppySeedBagel);

            Assert.IsFalse(removed);
            Assert.AreEqual(0, _basket.GetBagelCount());
        }
    }
}
