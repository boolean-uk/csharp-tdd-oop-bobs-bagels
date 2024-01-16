using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            basket.AddBagel("BGLO", 0.49f);
            basket.AddBagel("BGLO", 0.49f);
            basket.AddBagel("BGLS", 0.49f, "FILE", 0.12f);
            //basket.AddBagel("COFB", 0.99f);
        }

        [TestCase("BGLP", 0.39f, true)]
        [TestCase("", 0.55f, false)]
        [TestCase("COFL", 1.29f, true)]
        public void AddedBagel(string bagelType, float cost, bool expected)
        {
            bool haveAdded = basket.AddBagel(bagelType, cost);
            Assert.That(expected, Is.EqualTo(haveAdded));
        }

        [TestCase("BGLO", "", true)]
        [TestCase("", "FILC", false)]
        [TestCase("BGLS", "", false)]
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

        [TestCase("BGLO", "", true)]
        [TestCase("KBLO", "FILE", false)]
        public void ItemDoesExist(string bagelType, string fillingName, bool expected)
        {
            bool exists = basket.ItemExists(bagelType, fillingName);
            Assert.That(expected, Is.EqualTo(exists));
        }

        [TestCase("BGLO", 0.49f)]
        [TestCase("COFB", 0.99f)]
        public void CostOfBagelType(string bagelType, float cost)
        {
            Bagel bagel = new Bagel(bagelType, cost);
            float result = bagel.CostOfBagel(bagelType);
            Assert.That(cost, Is.EqualTo(result));
        }

        [Test]
        public void GetAllFillings()
        {
            Filling filling = new Filling();
            string allFillings = filling.AllFillings();

            Assert.That("Bacon, Egg, Cheese, Cream Cheese, Smoked Salmon, Ham", Is.EqualTo(allFillings));
        }

        [Test]
        public void GetAllFillingCosts()
        {
            Filling filling = new Filling();
            string allFillings = filling.FillingCosts();

            Assert.That("Bacon:0,12, Egg:0,12, Cheese:0,12, Cream Cheese:0,12, Smoked Salmon:0,12, Ham:0,12", Is.EqualTo(allFillings));
        }

        [Test]
        public void GetAllItems()
        {
            Inventory inventory = new Inventory();
            string items = inventory.PrintInventory();

            Assert.That("Bagels, Coffee, Fillings", Is.EqualTo(items));
        }

        [TestCase("BGO", false)]
        [TestCase("BGLP", true)]
        public void CheckDiscounts(string SKU, bool expected)
        {
            Deal deal = new Deal();
            bool result = deal.CheckDeal(SKU);

            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        public void GetDiscount()
        {
            Deal deal = new Deal();

            basket.AddBagel("BGLO", 0.49f);
            basket.AddBagel("BGLO", 0.49f);
            basket.AddBagel("BGLO", 0.49f);
            basket.AddBagel("BGLO", 0.49f);
            basket.AddBagel("BGLO", 0.49f);
            basket.AddBagel("BGLS", 0.49f, "FILE", 0.12f);

            float price = deal.DiscountPrice(basket);
            Assert.That(3.7099998f, Is.EqualTo(price));
        }

        [Test]
        public void GetReceipt()
        {
            Receipt receipt = new Receipt();

            bool result = receipt.PrintReceipt(basket);

            Assert.That(true, Is.EqualTo(result));
        }
    }
}