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
        private Inventory inventory;
        private Basket basket;

        [SetUp]
        public void SetUp()
        {
            inventory = new Inventory();
            basket = new Basket(inventory);

            Bagel bagel = new Bagel("BGLO");
            Bagel bagel2 = new Bagel("BGLS");
            Filling fil = new Filling("FILE");
            
            basket.AddItem(bagel);
            basket.AddItem(bagel2);
            basket.AddItem(fil);
        }

        [TestCase("BGLP", true)]
        [TestCase("", false)]
        [TestCase("COFL", true)]
        public void AddedBagel(string bagelType, bool expected)
        {
            Bagel bagel = new Bagel(bagelType);
            bool haveAdded = basket.AddItem(bagel);

            Assert.That(expected, Is.EqualTo(haveAdded));
        }

        [TestCase("BGLO", true)]
        [TestCase("", false)]
        [TestCase("COFW", false)]
        public void RemovedBagel(string bagelType, bool expected)
        {
            bool haveAdded = basket.RemoveItem(bagelType);
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
            int oldCapacity = basket.GetCapacity();
            int newCapacity = basket.IncreaseCapacity(3);
            Assert.That(oldCapacity, Is.LessThan(newCapacity));
        }

        [Test]
        public void TooMuchCapacity()
        {
            int oldCapacity = basket.IncreaseCapacity(7);
            int newCapacity = basket.IncreaseCapacity(-1);
            Assert.That(oldCapacity, Is.EqualTo(newCapacity));
        }

        [TestCase("BGLO", true)]
        [TestCase("KBLO", false)]
        public void ItemDoesExist(string bagelType, bool expected)
        {
            bool exists = basket.ItemExists(bagelType);
            Assert.That(expected, Is.EqualTo(exists));
        }

        [TestCase("BGLO", 0.49f)]
        [TestCase("COFB", 0.99f)]
        public void CostOfBagelType(string bagelType, float expected)
        {
            float cost = inventory.CostOfBagel(bagelType);
            Assert.That(expected, Is.EqualTo(cost));
        }

        [Test]
        public void AllFillings()
        {
            string fillings = inventory.GetFillings();
            Assert.That("FILB, FILE, FILC, FILX, FILS, FILH", Is.EqualTo(fillings));
        }

        [Test]
        public void GetAllFillingCosts()
        {
            string fillings = inventory.GetFillingsCosts();
            Assert.That("FILB:0,12, FILE:0,12, FILC:0,12, FILX:0,12, FILS:0,12, FILH:0,12", Is.EqualTo(fillings));
        }

        [Test]
        public void GetAllItems()
        {
            Inventory inventory = new Inventory();
            string items = inventory.PrintInventory();
            Assert.That("BGLO, BGLP, BGLE, BGLS, COFB, COFW, COFC, COFL, FILB, FILE, FILC, FILX, FILS, FILH", Is.EqualTo(items));
        }

        [Test]
        public void GetDiscount()
        {
            Deal deal = new Deal();
            Bagel bagel4 = new Bagel("BGLO");
            Bagel bagel5 = new Bagel("BGLO");
            Bagel bagel6 = new Bagel("BGLO");
            Bagel bagel7 = new Bagel("BGLO");
            Bagel bagel8 = new Bagel("BGLO");

            basket.AddItem(bagel4);
            basket.AddItem(bagel5);
            basket.AddItem(bagel6);
            basket.AddItem(bagel7);
            basket.AddItem(bagel8);

            float price = deal.DiscountedTotalPrice(basket.GetBasket());
            Assert.That(2.98000002f, Is.EqualTo(price));
        }

        [Test]
        public void PrintReceipt()
        {
            Bagel bagel4 = new Bagel("BGLO");
            Bagel bagel5 = new Bagel("BGLO");
            Bagel bagel6 = new Bagel("BGLO");
            Bagel bagel7 = new Bagel("BGLO");
            Bagel bagel8 = new Bagel("BGLO");

            basket.AddItem(bagel4);
            basket.AddItem(bagel5);
            basket.AddItem(bagel6);
            basket.AddItem(bagel7);
            basket.AddItem(bagel8);

            Receipt receipt = new Receipt();
            string result = receipt.GetReceipt(basket.GetBasket());
            Console.WriteLine(result);
        }

        [Test]
        public void PrintDiscountedReceipt()
        {
            Bagel bagel4 = new Bagel("BGLO");
            Bagel bagel5 = new Bagel("BGLO");
            Bagel bagel6 = new Bagel("BGLO");
            Bagel bagel7 = new Bagel("BGLO");
            Bagel bagel8 = new Bagel("BGLO");

            basket.AddItem(bagel4);
            basket.AddItem(bagel5);
            basket.AddItem(bagel6);
            basket.AddItem(bagel7);
            basket.AddItem(bagel8);

            Receipt receipt = new Receipt();
            string result = receipt.DiscountedReceipt(basket.GetBasket());
            Console.WriteLine(result);
        }
    }
}