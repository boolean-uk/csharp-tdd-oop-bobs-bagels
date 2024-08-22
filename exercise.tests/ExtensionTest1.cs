using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    public class ExtensionTest1
    {
        [Test]
        public void shouldShowDiscountList()
        {
            //SetUp
            Inventory inventory = new Inventory();


            //Execute
            List<Discount> result = inventory.ShowDiscountList();

            //Verify
            Assert.IsTrue(result.Any(p => p.SKU == "BGLO" && p.Name == "Bagel" && p.Variant == "Onion" && p.Price == 0.49d && p.SpecialOffers == $"6 for {Discount.SixBagels}" ));
            Assert.IsTrue(result.Any(p => p.SKU == "BGLP" && p.Name == "Bagel" && p.Variant == "Plain" && p.Price == 0.39d && p.SpecialOffers == $"6 for {Discount.SixBagels}"));
            Assert.IsTrue(result.Any(p => p.SKU == "BGLE" && p.Name == "Bagel" && p.Variant == "Everything" && p.Price == 0.49d && p.SpecialOffers == $"6 for {Discount.SixBagels}"));
            Assert.IsTrue(result.Any(p => p.SKU == "BGLS" && p.Name == "Bagel" && p.Variant == "Sesame" && p.Price == 0.49d && p.SpecialOffers == $"6 for {Discount.SixBagels}"));
            Assert.IsTrue(result.Any(p => p.SKU == "BGLO" && p.Name == "Bagel" && p.Variant == "Onion" && p.Price == 0.49d && p.SpecialOffers == $"12 for {Discount.TwelveBagels}"));
            Assert.IsTrue(result.Any(p => p.SKU == "BGLP" && p.Name == "Bagel" && p.Variant == "Plain" && p.Price == 0.39d && p.SpecialOffers == $"12 for {Discount.TwelveBagels}"));
            Assert.IsTrue(result.Any(p => p.SKU == "BGLE" && p.Name == "Bagel" && p.Variant == "Everything" && p.Price == 0.49d && p.SpecialOffers == $"12 for {Discount.TwelveBagels}"));
            Assert.IsTrue(result.Any(p => p.SKU == "BGLS" && p.Name == "Bagel" && p.Variant == "Sesame" && p.Price == 0.49d && p.SpecialOffers == $"12 for {Discount.TwelveBagels}"));
            Assert.IsTrue(result.Any(p => p.SKU == "COFB" && p.Name == "Coffee" && p.Variant == "Black" && p.Price == 0.99d && p.SpecialOffers == $"Coffe and Bagel for {Discount.CoffeeAndBagel}"));

        }

        [Test]
        public void shouldGetItemBySKU()
        {
            //Setup
            Inventory inventory = new Inventory();
            InventoryProducts bagelOnion = new InventoryProducts("BGLO", 0.49d, "Bagel", "Onion");
            InventoryProducts bagelSesame = new InventoryProducts("BGLS", 0.49d, "Bagel", "Sesame");

            //Execute
            InventoryProducts result = inventory.GetItemBySKU("BGLO");
            InventoryProducts result2 = inventory.GetItemBySKU("BGLS");
           
            //Verify
           Assert.IsTrue(result.SKU == bagelOnion.SKU && result.Name == bagelOnion.Name && result.Variant == bagelOnion.Variant && result.Price == bagelOnion.Price);
            Assert.IsTrue(result2.SKU == bagelSesame.SKU && result2.Name == bagelSesame.Name && result2.Variant == bagelSesame.Variant && result2.Price == bagelSesame.Price);

        }

        
        

                 
        [Test]
        public void shouldListItemsWithDiscounts()
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
            basket.Items.Add(bagelSesame);
            basket.Items.Add(bagelSesame);
            basket.Items.Add(bagelSesame);
            basket.Items.Add(bagelSesame);


            //Execute
            List<Purchase> result = basket.ListItems();

            //Verify
            Assert.IsTrue(result.Any(p => p.Variant == "Onion" && p.Name == "Bagel" && p.Price == 0.49d && p.Quantity == 1));
            Assert.IsTrue(result.Any(p => p.Variant == "Sesame" && p.Name == "Bagel" && p.Price == 2.49d && p.Quantity == 6));  // Discount
            Assert.IsTrue(result.Any(p => p.Variant == "White" && p.Name == "Coffee" && p.Price == 1.19d && p.Quantity == 1));

        }
    }
}
