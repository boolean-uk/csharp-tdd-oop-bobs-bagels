using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    
    public class InventoryTest
    {
        
        [TestCase("BOGUS", "fake", false)]
        [TestCase("Bagel", "Everything", true)]
        [TestCase("Coffee", "Rainbow", false)]
        [TestCase("Filling", "Bacon", true)]
        [TestCase("Filling", "Smoked Salmon", true)]
        [TestCase("Bagel", "Plain", true)]
        [TestCase("A lie", "Ham", false)]
        [TestCase("Coffee", "Latte", true)]
        public void TestIsInInventory(string name, string variant, bool expected)
        {
            Inventory inventory = new Inventory();

            bool result = inventory.IsInInventory(name, variant);
            
            Assert.That(result == expected);
        }

        [TestCase("BOGUS", "fake", -1)]
        [TestCase("Bagel", "Everything", 0.49)]
        [TestCase("Coffee", "Rainbow", -1)]
        [TestCase("Filling", "Bacon", 0.12)]
        [TestCase("Filling", "Smoked Salmon", 0.12)]
        [TestCase("Bagel", "Plain", 0.39)]
        [TestCase("A lie", "Ham", -1)]
        [TestCase("Coffee", "Latte", 1.29)]
        public void TestGetPrice(string name, string variant, double expected)
        {
            Inventory inventory = new Inventory();
            double result = inventory.GetPrice(name, variant);
            
            Assert.That(result == expected);
        }

    }
}
