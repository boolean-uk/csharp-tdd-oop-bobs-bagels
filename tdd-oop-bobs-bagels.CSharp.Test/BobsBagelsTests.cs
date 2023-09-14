using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using tdd_oop_bobs_bagels.CSharp.Main;

namespace tdd_oop_bobs_bagels.CSharp.Test
{
    [TestFixture]
    public class TestsForBasket
    { // deleted a lot of tests from previous bobs bagel
        private Basket _basket;
        private Inventory _inventory;

        [SetUp]
        public void Setup()
        {
            _inventory = new Inventory();
            _basket = new Basket(_inventory);

        }

        [Test]
        public void CanWeAddItemToTheBasket()
        {
            bool success = _basket.AddItem(new Bagel("BGLO", 0.49M, "Bagel", "Onion"));
            Assert.IsTrue(success);
        }

        [Test]
        public void CanWeRemoveItemFromBasket()
        {
            var bagel = new Bagel("BGLO", 0.49M, "Bagel", "Onion");
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
            _bagel = new Bagel("BGLO", 0.49M, "Bagel", "Onion");
        }
        [Test]
        public void CanWeGetTheBagelPrice()
        {
            decimal price = _bagel.GetPrice();
            Assert.AreEqual(0.49M, price);
        }
        [Test]
        public void CanWeAddFillingToTheBagel()
        {
            bool succes = _bagel.AddFilling(new Filling("FILB", 0.12M, "Bacon"));
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
            _filling = new Filling("FILB", 0.12M, "Bacon");
        }
        [Test]
        public void CanWeGetTheFillingPrice()
        {
            decimal price = _filling.GetPrice();
            Assert.AreEqual(0.12, price);
        }
    }

    [TestFixture]
    public class TestsForCoffee
    {
        private Coffee _coffee;
        [SetUp]
        public void Setup()
        {
            _coffee = new Coffee("COFB", 0.99M, "Black");
        }
        [Test]
        public void CanWeGetTheCoffeePrice()
        {
            decimal price = _coffee.GetPrice();
            Assert.AreEqual(0.99, price);
        }
    }

    [TestFixture]
    public class TestsForInventory
    {
        private Inventory _inventory;
        [SetUp]
        public void Setup ()
        {
            _inventory = new Inventory();
        }
        [Test]
        public void CanWeCheckIfTheItemExists()
        {
            bool exists = _inventory.DoesTheItemExist("BGLO");
            Assert.IsTrue(exists);
        }
        [Test]
        public void CanWeGetThePriceOfAnItemInInventory()
        {
            decimal price = _inventory.GetPriceOfItem("BGLO");
            Assert.AreEqual(0.49M, price);
        }
    }

    [TestFixture]
    public class TestsForDiscounts
    {
        private Inventory _inventory;
        private Basket _basket;
        [SetUp]
        public void Setup()
        {
            _inventory = new Inventory();
            _basket = new Basket(_inventory);
        }
        [Test]
        public void IsTheBulkDiscountApplied() // 6 for discount
        {
            for (int i = 0; i < 6; i++)
            {
                _basket.AddItem(new Bagel("BGLO", 0.49M, "Bagel", "Onion"));
            }
            decimal priceExpected = 2.49M;
            decimal totalPrice = _basket.GetTotalCost();
            Assert.AreEqual(priceExpected, totalPrice);
        }
        [Test]
        public void TestForComboCoffeeAndBagel() // combo coffee with a bagel discount
        {
            _basket.AddItem(new Bagel("BGLO", 0.49M, "Bagel", "Onion"));
            _basket.AddItem(new Coffee("COFB", 0.99M, "Black"));
            decimal priceExpected = 1.25M;
            decimal totalPriceExpected = _basket.GetTotalCost(); 
            Assert.AreEqual(priceExpected, totalPriceExpected);
        }
    }


}