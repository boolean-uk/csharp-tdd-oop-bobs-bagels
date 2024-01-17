using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    internal class ReceiptTests
    {
        [Test]
        public void ReceiptTest()
        {
            Basket _basket = new Basket();
            _basket.AddItem("BGLP");
            _basket.AddItem("COFL");
            Receipt receipt = new Receipt(_basket);
            Assert.Pass();
        }
        [Test]
        public void Receipt2Test()
        {
            Basket _basket = new Basket();
            _basket.AddItem("BGLP");
            _basket.AddItem("BGLP");
            _basket.AddItem("BGLP");
            _basket.AddItem("COFL");
            Receipt receipt = new Receipt(_basket);
            Assert.Pass();
        }

        [Test]
        public void Receipt3Test()
        {
            Basket _basket = new Basket();
            _basket.AddItem("BGLP");
            _basket.AddItem("BGLP");
            _basket.AddItem("BGLP");
            _basket.AddItem("BGLP");
            _basket.AddItem("BGLP");
            _basket.AddFilling(_basket.Inventory[0].ID, "FILE");
            _basket.AddFilling(_basket.Inventory[0].ID, "FILX");
            _basket.AddFilling(_basket.Inventory[1].ID, "FILX");
            _basket.AddFilling(_basket.Inventory[2].ID, "FILX");
            _basket.AddItem("COFL");
            Receipt receipt = new Receipt(_basket);
            Assert.Pass();
        }

    }
}
