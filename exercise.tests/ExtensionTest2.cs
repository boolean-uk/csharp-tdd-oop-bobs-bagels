
using exercise.main;
using Microsoft.VisualBasic;
using NUnit.Framework;

namespace exercise.tests
{
   
    public class ExtensionTest2
    {

        [Test]
        public void ShouldPrintReceipt()
        {
            //SetUp
            Basket basket = new Basket();
            basket.Capacity = 10;
            basket.IsPurchased = true;
            InventoryProducts bagelOnion = new InventoryProducts("BGLO", 0.49d, "Bagel", "Onion");
            InventoryProducts bagelSesame = new InventoryProducts("BGLS", 0.49d, "Bagel", "Sesame");
            InventoryProducts coffeeWhite = new InventoryProducts("COFW", 1.19d, "Coffee", "White");
            basket.Items.Add(bagelOnion);
            basket.Items.Add(bagelSesame);
            basket.Items.Add(coffeeWhite);
            basket.Items.Add(bagelSesame);

            //Execute
            Receipt receipt = basket.PrintReceipt();
            
            //Verify
            Assert.IsTrue(receipt.StoreName == "Bob's Bagels" );

            Assert.IsTrue(receipt.Products.Any(p => p.Variant == "Onion" && p.Name == "Bagel" && p.Price == 0.49d && p.Quantity == 1));
            Assert.IsTrue(receipt.Products.Any(p => p.Variant == "Sesame" && p.Name == "Bagel" && p.Price == 0.49d * 2 && p.Quantity == 2));  // Price is 0.49 * 2
            Assert.IsTrue(receipt.Products.Any(p => p.Variant == "White" && p.Name == "Coffee" && p.Price == 1.19d && p.Quantity == 1));


            Assert.IsTrue(receipt.TotalCost == basket.TotalCost());


        }


        [Test]
        public void ShouldListItems()
        {
            //SetUp
            Basket basket = new Basket();
            basket.Capacity = 10;
            basket.IsPurchased = true;
            InventoryProducts bagelOnion = new InventoryProducts("BGLO", 0.49d, "Bagel", "Onion");
            InventoryProducts bagelSesame = new InventoryProducts("BGLS", 0.49d, "Bagel", "Sesame");
            InventoryProducts coffeeWhite = new InventoryProducts("COFW",1.19d,  "Coffee","White");
            basket.Items.Add(bagelOnion);
           basket.Items.Add(bagelSesame);
            basket.Items.Add(coffeeWhite);
            basket.Items.Add(bagelSesame);

            //Execute
            List<Purchase> result = basket.ShouldListItems();

            //Verify
           Assert.IsTrue(result.Any(p => p.Variant == "Onion" && p.Name == "Bagel" && p.Price == 0.49d && p.Quantity == 1));
           Assert.IsTrue(result.Any(p => p.Variant == "Sesame" && p.Name == "Bagel" && p.Price == 0.49d*2 && p.Quantity == 2));  // Price is 0.49 * 2
           Assert.IsTrue(result.Any(p => p.Variant == "White" && p.Name == "Coffee" && p.Price == 1.19d && p.Quantity == 1));
        }

      

        [Test]
        public void ShouldGetStoreName()
        {
            //SetUp
            Basket basket = new Basket();
            
            
            //Execute
            string result = basket.Inventory.GetStoreName();

            //Verify
            Assert.That(result == "Bob's Bagels");
        }
    }
        
 }

