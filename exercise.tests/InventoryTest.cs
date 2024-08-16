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
        public void IsInInventory(string name, string variant, bool expected)
        {
            Inventory inventory = new Inventory();

            bool result = inventory.IsInInventory(name, variant);
            
            Assert.That(result == expected);
        }
    }
}
