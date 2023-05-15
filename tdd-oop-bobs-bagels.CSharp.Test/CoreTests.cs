using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tdd_oop_bobs_bagels.CSharp.Main;

namespace tdd_oop_bobs_bagels.CSharp.Test
{
    [TestFixture]
    public class BasketTests
    {
        //As a member of the public,
        //So I can order a bagel before work,
        //I'd like to add a specific type of bagel to my basket.


        [TestCase("BGLP")]
        public void AddBagelToBasket(string bagel)
        {
            //arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket(inventory);

            // act
            basket.AddItem(bagel);

            //assert
            Assert.AreEqual(basket.Items.Count, 1);
        }



        //As a member of the public,
        //So I can change my order,
        //I'd like to remove a bagel from my basket.
        [TestCase("BGLE")]
        public void RemoveBagelFromBasket(string bagel)
        {

            //arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket(inventory);
            basket.AddItem(bagel);

            //act
            bool result = basket.RemoveFromBasket(bagel);

            //assert
            Assert.IsTrue(result);
            Assert.AreEqual(basket.Items.Count, 0);
        }

        //As a member of the public,
        //So that I can not overfill my small bagel basket
        //I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
        [Test]
        public void FullBasketTest()
        {
            //arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket(inventory);

            string bagel1 = "BGLP";
            string bagel2 = "FILC";
            string bagel3 = "FILS";
            string bagel4 = "FILH";
            string bagel5 = "COFC";

            //act

            basket.AddItem(bagel1);
            basket.AddItem(bagel2);
            basket.AddItem(bagel3);
            basket.AddItem(bagel4);
            basket.AddItem(bagel5);


            //assert

            Assert.AreEqual(basket.Items.Count, basket.ItemsMax);
            Assert.IsTrue(basket.FullBasket);
        }


        //As a Bob's Bagels manager,
        //So that I can expand my business,
        //I’d like to change the capacity of baskets.

        [Test]
        public void ChangeBasketCapacityTast()
        {
            //arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket(inventory);
            int newCapacity = 8;

            //act
            basket.ChangeBasketCapacity(newCapacity);

            //assert
            Assert.AreEqual(basket.ItemsMax, newCapacity);

        }

        //As a member of the public
        //So that I can maintain my sanity
        //I'd like to know if I try to remove an item that doesn't exist in my basket.

        [TestCase("Glutenfree Bagel")]
        public void RemoveNotExistingBagelTest(string bagel)
        {
            //arranget
            Inventory inventory = new Inventory();
            Basket basket = new Basket(inventory);

            //act
            bool result = basket.RemoveFromBasket(bagel);

            //assert
            Assert.IsFalse(result);
        }


        //As a customer,
        //So I know how much money I need,
        //I'd like to know the total cost of items in my basket.
        [Test]
        public void TotalCost()
        {
            //arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket(inventory);
            var expectedCost = 0.49f + 1.29f;


            //act
            basket.AddItem("BGLE");
            basket.AddItem("COFL");

            //assert
            Assert.AreEqual(basket.totalCost(), expectedCost);
        }

        //As a customer,
        //So I know what the damage will be,
        //I'd like to know the cost of a bagel before I add it to my basket.
        [Test]
        public void ItemCost()
        {
            //arrange
            Inventory inventory = new Inventory();

            //act
            var item = inventory.getBySKU("COFC");

            //assert
            Assert.AreEqual(1.29f, item.Price);
        }

    }
}

