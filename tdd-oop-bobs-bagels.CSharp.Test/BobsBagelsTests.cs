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
    public class TestsForBasket
    { // deleted a lot of tests from previous bobs bagel
        
        [TestFixture]
        private Basket _basket;

        [SetUp]
        public void Setup()
        {
            _basket = new Basket;
        }

        [Test]
        public void CanWeAddItemToTheBasket()
        {
            bool success = _basket.AddItem(new Bagel("BGLO", 0.49, "Bagel", "Onion"));
            Assert.IsTrue(success);
        }

        [Test]
        public void CanWeRemoveItemFromBasket()
        {
            var bagel = new Bagel(("BGLO", 0.49, "Bagel", "Onion");
            _basket.AddItem(bagel);
            bool removed = _basket.RemoveItem(bagel);
            Assert.IsTrue(removed);
        }
    }

    [TestFixture]
    public class TestsForBagels
    {
        private Bagel _bagel;
        [SetUp]
        public void Setup()
        {
            _bagel = new Bagel("BGLO", 0.49, "Bagel", "Onion");
        }
        [Test]
        public void CanWeGetTheBagelPrice()
        {
            double price = -_bagel.GetPrice();
            Assert.AreEqual(0.49, price);
        }
        [Test]
        public void CanWeAddFillingToTheBagel()
        {
            bool succes = _bagel.AddFilling(new Filling("FILB", 0.12, "Bacon"));
            Assert.IsTrue(succes);
        }
    }

    [TestFixture]
    public class TestsForFilling
    {
        private Filling _filling;
        [SetUp]
        public void Setup()
        {
            _filling = new Filling("FILB", 0.12, "Bacon");
        }
        [Test]
        public void CanWeGetTheFillingPrice()
        {
            double price _filling.GetPrice();
            Assert.AreEqual(0.12, price);
        }
    }


}