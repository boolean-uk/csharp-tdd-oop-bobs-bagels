using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    public class ExtensionTest3
    { 
        [Test]
        public void shouldListItemsWithSavings()
        {
            //SetUp
            Basket basket = new Basket();
            basket.Capacity = 30;
            basket.IsPurchased = true;
            InventoryProducts bagelOnion = new InventoryProducts("BGLO", 0.49d, "Bagel", "Onion");
            InventoryProducts bagelSesame = new InventoryProducts("BGLS", 0.49d, "Bagel", "Sesame");
            InventoryProducts coffeeWhite = new InventoryProducts("COFW", 1.19d, "Coffee", "White");
            basket.AddToBasket(bagelOnion);
            basket.AddToBasket(coffeeWhite);
            for (int i = 0; i < 12; i++)
            {
                basket.AddToBasket(bagelSesame);
            }


            //Execute
            List<Purchase> result = basket.ListItems();

            //Verify
            Assert.IsTrue(result.Any(p => p.Variant == "Onion" && p.Name == "Bagel" && p.Price == 0.49d && p.Quantity == 1 && p.Saved == 0d));
            Assert.IsTrue(result.Any(p => p.Variant == "Sesame" && p.Name == "Bagel" && p.Price == 3.99d && p.Quantity == 12 && p.Saved == 1.89d));  // Discount
            Assert.IsTrue(result.Any(p => p.Variant == "White" && p.Name == "Coffee" && p.Price == 1.19d && p.Quantity == 1));

        }

      
    }
}
