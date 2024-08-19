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
        public void ShouldAddToBasket()
        {
            //SetUp
            Basket basket = new Basket();
            basket.Capacity = 10;
            InventoryProducts bagelOnion = new InventoryProducts("BGLO", 0.49d, "Bagel", "Onion");
            InventoryProducts bagelSesame = new InventoryProducts("BGLS", 0.49d, "Bagel", "Sesame");

            //Execute
            basket.AddToBasket(bagelOnion);
           
            //Verify
            Assert.IsTrue(basket.Items.Contains(bagelOnion));
        }  
        
    
        
        [Test]
        public void ShouldRemoveFromBasket()
        {
            //SetUp
            Basket basket = new Basket();
            basket.Capacity = 10;
            InventoryProducts bagelOnion = new InventoryProducts("BGLO", 0.49d, "Bagel", "Onion");
            InventoryProducts bagelSesame = new InventoryProducts("BGLS", 0.49d, "Bagel", "Sesame");

            //Execute
            basket.Items.Add(bagelSesame);
            basket.Items.Add(bagelOnion);
            basket.RemoveFromBasket(bagelOnion);


            //Verify
            Assert.IsFalse(basket.Items.Contains(bagelOnion));
        }  
        
        [Test]
        public void ShouldChooseFilling()
        {
            //SetUp
            Basket basket = new Basket();
            basket.Capacity = 10;
            InventoryProducts eggFilling = new InventoryProducts("FILE", 0.12d, "Filling", "Egg");

            //Execute
            basket.ChooseFilling(eggFilling);

            //Verify
            Assert.IsTrue(basket.Items.Contains(eggFilling));
        } 
        
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
        public void ShouldChangeBasketcapacity()
        {
            //SetUp
            Basket basket = new Basket();
            basket.Capacity = 10;


            //Execute
            basket.IsManager = true;
            basket.ChangeBasketCapacity(30);

            //Verify
            Assert.IsTrue(basket.Capacity == 30);
        }  

        [Test]
        public void ShouldNotChangeBasketcapacity()
        {
            //SetUp
            Basket basket = new Basket();
            Inventory inventory1 = new Inventory();
            basket.Capacity = 10;


            //Execute
            basket.IsManager = false;
            basket.ChangeBasketCapacity(30);

            //Verify
            Assert.IsTrue(basket.Capacity == 10);
        }      
        
        [Test]
        public void ShouldShowList()
        {
            //SetUp
            Inventory inventory = new Inventory();
           

            //Execute
            List<InventoryProducts> result = inventory.ShowList();

            //Verify
            Assert.That(result == inventory.Products);
        }
    }
}
