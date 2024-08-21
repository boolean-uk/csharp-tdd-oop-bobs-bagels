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
       
        [Test]
        public void ShouldReturnBagelPrice()
        {
        
            //SetUp
            Inventory inventory = new Inventory();


            //Execute
            double result = inventory.BagelPrice("Plain");

            //Verify
            Assert.IsTrue(result == 0.39d);
        }  
        
        [Test]
        public void ShouldReturnFillingPrice()
        {
            //SetUp
            Inventory inventory = new Inventory();


            //Execute
            double result = inventory.FillingPrice("Egg");

            //Verify
            Assert.IsTrue(result == 0.12d);
        }  
        
        
        [Test]
        public void ShouldShowList()
        {
            //SetUp
            Inventory inventory = new Inventory();
           

            //Execute
            List<InventoryProducts> result = inventory.ShowList();

            //Verify
            Assert.IsTrue(result.Any(p => p.SKU == "BGLO" && p.Price == 0.49d && p.Name == "Bagel" && p.Variant=="Onion" ));
            Assert.That(result == inventory.Products);
        }
    }
}
