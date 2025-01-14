using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main;

namespace exercise.tests
{
    internal class InventoryTest
    {
        [Test]
        public void TestGetAllProducts()
        {
            var inventory = new Inventory();

            Dictionary<string, Item> bagelInventory = inventory.GetBagelInventory();
            Dictionary<string, Item> coffeeInventory = inventory.GetCoffeeInventory();
            Dictionary<string, Item> fillingInventory = inventory.GetFillingInventory();

            Assert.IsNotNull(bagelInventory);
            Assert.IsNotNull(coffeeInventory);
            Assert.IsNotNull(fillingInventory);


            Assert.IsTrue(bagelInventory.ContainsKey("BGLO"));
            Assert.AreEqual("Bagel", bagelInventory["BGLO"].Name);
            Assert.AreEqual(0.49, bagelInventory["BGLO"].Price);
        }

    }
}
