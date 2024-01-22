using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static exercise.main.BasketManager;
using static exercise.main.Inventory;
using static exercise.main.ReceiptManager;

namespace exercise.tests
{
    [TestFixture]
    internal class Extension2Test
    {
        private ReceiptManager receiptManager;

        [SetUp]
        public void Setup()
        {
            receiptManager = new ReceiptManager();
        }

        [Test]
        public void BasketGetReceipt()
        {

            Basket basket = new Basket();
            Inventory inventory = new Inventory();

            basket.Add("BGLO");
            basket.Add("COFB");

            Receipt receipt = basket.Receipt();

            Assert.IsNotNull(receipt);
            Assert.That(receipt.Entries.Count, Is.EqualTo(2));
        }

        [Test]
        public void DisplayReceipt()
        {
            Order order = new Order();

            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            receiptManager.DisplayReceipt(order);

            string output = stringWriter.ToString();
            Assert.That(output, Is.Not.Empty);
        }
    }
}
