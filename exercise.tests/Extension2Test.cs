using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main;

namespace exercise.tests
{
    public class Extension2Test
    {
        [Test]

        public void TestPrintingReceipt()
        {

            Basket basket = new Basket();

            basket.changecapacity(5);

            Item item1 = new Item("BGLO", 0.49, "Bagel", "Onion");
            Item item2 = new Item("BGLO", 0.49, "Bagel", "Onion");
            Item item3 = new Item("BGLP", 0.39, "Bagel", "Everything");

            basket.addItem(item1);
            basket.addItem(item2);
            basket.addItem(item3);

            string receipt = basket.printreceipt();

            Assert.That(receipt, Does.Contain("2024"));
            Assert.That(receipt, Does.Contain("Bob's Bagels"));
            Assert.That(receipt, Does.Contain("Total"));

        }
    }
}
