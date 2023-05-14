using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tdd_oop_bobs_bagels.CSharp.Main;

namespace tdd_oop_bobs_bagels.CSharp.Test
{
    [TestFixture]
    public  class BagelTests
    {
        [Test]
        public void CheckifExistsToAdd()
        {
            //arrange
            Items item = new Items("BGLO", 0.49m, "Bagel", "Onion");
            BagelsShop bagelsShop = new BagelsShop();
            //act
            bool result = bagelsShop.addBagel(item, Roles.Shopper);
            //assert
            Assert.IsTrue(result);

        }
        [Test]
        public void CheckifExistsToRemove()
        {
            //arrange
            Items item = new Items("BGLO", 0.49m, "Bagel", "Onion");
            Items item1 = new Items("COFC", 1.29m, "Coffee", "Cappucino");


            BagelsShop bagelsShop = new BagelsShop();
            bagelsShop.addBagel(item, Roles.Shopper);
            bagelsShop.addBagel(item1, Roles.Shopper);
            //act
            bool result = bagelsShop.RemoveBagel(item1, Roles.Shopper);
            //assert
            Assert.IsTrue(result);

        }

        [TestCase(10)]
        public void CapacityChangedTest(int newCapacity)
        {
            BagelsShop bagelsShop = new BagelsShop();
          
            int result = bagelsShop.ChangeCapacity(Roles.Manager, newCapacity);


            Assert.AreEqual(result, newCapacity);
           
        }

        [Test]
        public void CanAddFillings()
        {
            //arrange
            Items item = new Items("BGLO", 0.49m, "Bagel", "Onion");
            Items item2 = new Items("FILH", 0.12m, "Filling", "Ham");
            BagelsShop bagelsShop = new BagelsShop();
            //act
            bagelsShop.addBagel(item, Roles.Shopper);
            bool result =  bagelsShop.AddFillings(item2, Roles.Shopper);
            // some debug Console.WriteLine(bagelsShop.ProductsInBasket);


            //assert
            Assert.IsTrue(result); 

        }
        [Test]
        public void CheckIndividualCost() {
            Items item = new Items("BGLO", 0.49m, "Bagel", "Onion");
            BagelsShop bagelsShop = new BagelsShop();


            decimal result = bagelsShop.IndividualCost(item, Roles.Shopper);
           //some debug Console.WriteLine(result);

            Assert.NotZero(result);

        }
        [Test]
        public void CheckTotalCost()
        {
            Items item = new Items("BGLO", 0.49m, "Bagel", "Onion");
            Items item2 = new Items("FILH", 0.12m, "Filling", "Ham");

            BagelsShop bagelsShop = new BagelsShop();
            bagelsShop.addBagel(item, Roles.Shopper);
            bagelsShop.AddFillings(item2 , Roles.Shopper);

            decimal result = bagelsShop.TotalCost(Roles.Shopper);
            foreach(var k in bagelsShop.Products)
            {
                Console.WriteLine(k.Key.Sku);
            } 
            Console.WriteLine(result);

            Assert.NotZero(result);

        }

    }
}
