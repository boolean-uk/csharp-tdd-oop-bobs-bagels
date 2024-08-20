using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main;

namespace exercise.tests
{
    public class BasketTest
    {
        [Test]
        public void TestAddingBagel()
        {
            
            //arrange

            Inventory inventory = new Inventory();

            Item item1 = inventory.GetItembySku("BGLO");

            Basket basket = new Basket();

            //act

            basket.addItem(item1);

            //arrange

            Assert.That(basket.Item.Contains(item1));


        }
        [Test]

        public void TestRemoveBagel()
        {

            //arrange

            Inventory inventory = new Inventory();

            Item item1 = inventory.GetItembySku("BGLP");

            Basket basket = new Basket();

            //act

            basket.removeItem(item1);

            //assert

            Assert.IsFalse(basket.Item.Contains(item1));
        }
        [Test]

        public void TestIsFull()
        {
            //arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket();

            //act
            Item item1 = inventory.GetItembySku("BGLE");
            Item item2 = inventory.GetItembySku("BGLS");
            Item item3 = inventory.GetItembySku("COFB");
            Item item4 = inventory.GetItembySku("FILB");

            
            basket.addItem(item1);
            basket.addItem(item2);
            basket.addItem(item3);
            basket.addItem(item4);

            basket.max_capasity = 3;

            bool expected = basket.isFull();

            //assert
            Assert.That(expected, Is.True);
        }
        [Test]
        public void TestChangingCapacity()
        {
            //arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket();

            //act
            int newcapasity = 10;
            
            bool expected = basket.changecapacity(newcapasity);

            //assert
            Assert.That(expected, Is.True);
            Assert.That(basket.max_capasity == 10);


        }
        [Test]
        public void TestRemovingNotExistingItem()
        {
            //arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket();

            //act
            Item item1 = inventory.GetItembySku("FILH");
            Item item2 = inventory.GetItembySku("FILS");
            basket.addItem(item1);
            bool notexisting = basket.removeItem(item2);

            //assert
            Assert.IsFalse(basket.Item.Contains(item2));

        }
        [Test]

        public void TestTotalCostOfItems()
        {
            //arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket();

            //act
            Item item1 = inventory.GetItembySku("BGLO");
            Item item2 = inventory.GetItembySku("BGLP");

            basket.changecapacity(4);

            basket.addItem(item1);
            basket.addItem(item2);
            
            
            double expected = 0.88d;
            double totalcost = basket.getTotalCost();
            
            //assert
            Assert.IsTrue(expected == totalcost);
            
        }
        [Test]
        
        public void TestCostOfBagel()
        {
            //arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket();

            Item item1 = inventory.GetItembySku("BGLO");
            

            //act
            double bagelprice = basket.getBagelPrice(item1.Sku);
            double expected = 0.49d;

            //assert
            Assert.That(bagelprice == expected);
        }
    }
}
