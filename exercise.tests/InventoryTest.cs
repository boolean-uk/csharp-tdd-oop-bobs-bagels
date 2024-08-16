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
        
        [TestCase("BOGUS", false)]
        public void IsInInventory(string sku, bool expected)
        {
            Inventory inventory = new Inventory();

            //bool result = inventory.isInInventory(sku);
            
            Assert.That(/*result*/true == expected);
        }
    }
}
