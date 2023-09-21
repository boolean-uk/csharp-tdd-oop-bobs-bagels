using NUnit.Framework;
using tdd_oop_bobs_bagels.CSharp.Main;

namespace tdd_oop_bobs_bagels.CSharp.Test
{
    [TestFixture]
    public class TestsForBasket
    { // deleted a lot of tests from previous bobs bagel
        private Basket _basket;
        private Inventory _inventory;
        private List<Discount> _discounts;

        [SetUp]
        public void Setup()
        {
            _inventory = new Inventory();
            _discounts = new List<Discount>
            {
                new ComboDiscount(),
                new BulkDiscount()
            };
            _basket = new Basket(_inventory, _discounts);

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

        [Test]
        public void TestTotalSavingsForBasket()
        {
            _basket.AddItem(new Bagel("BGLO", 0.49M, "Bagel", "Onion"));
            _basket.AddItem(new Coffee("COFB", 0.99M, "Black"));
            decimal savingsExpected = 0.23M;
            decimal totalSavings = _basket.GetTotalSavings();
            Assert.AreEqual(savingsExpected, totalSavings);
        }
        [Test]
        public void TestClearingTheBasketUsingRemoveItem()
        {
            var bagel = new Bagel("BGLO", 0.49M, "Bagel", "Onion");
            var coffee = new Coffee("COFB", 0.99M, "Black");
            _basket.AddItem(bagel);
            _basket.AddItem(coffee);
            _basket.RemoveItem(bagel);
            _basket.RemoveItem(coffee);
            decimal totalPrice = _basket.GetTotalCost();
            Assert.AreEqual(0, totalPrice);
        }
        [Test]
        public void TestBasketCapacity()
        {
            for (int i = 0; i < 30; i++)
            {
                _basket.AddItem(new Bagel("BGLO", 0.49M, "Bagel", "Onion"));
            }

            bool success = _basket.AddItem(new Coffee("COFB", 0.99M, "Black"));
            Assert.IsTrue(success);
            Assert.IsFalse(_basket.IsBasketFull());
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
            Assert.AreEqual(0.12M, price);
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
        public void Setup()
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
        private Basket _basket;
        private Inventory _inventory;
        private List<Discount> _discounts;

        [SetUp]
        public void Setup()
        {
            _inventory = new Inventory();
            _discounts = new List<Discount>
    {
        new ComboDiscount(),
        new BulkDiscount()
    };
            _basket = new Basket(_inventory, _discounts);
        }
        [Test]
        public void IsTheBulkDiscountAppliedForSixBagels()
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
        public void IsTheBulkDiscountAppliedFor12PlainBagels()
        {
            for (int i = 0; i < 12; i++)
            {
                _basket.AddItem(new Bagel("BGLP", 0.39M, "Bagel", "Plain"));
            }
            decimal priceExpected = 3.99M;
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