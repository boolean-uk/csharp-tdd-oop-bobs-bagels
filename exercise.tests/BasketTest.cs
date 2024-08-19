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
    }
}
