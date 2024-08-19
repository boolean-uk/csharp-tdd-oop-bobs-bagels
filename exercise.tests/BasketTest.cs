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

            basket.addItem(item1);
            basket.addItem(item2);
            basket.addItem(item3);

            basket.max_capasity = 2;

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
            int newcapasity = 5;
            
            bool expected = basket.changecapacity(newcapasity);

            //assert
            Assert.That(expected, Is.True);
            Assert.That(basket.max_capasity == 5);


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
            Assert.IsFalse(notexisting);

        }
    }
}
