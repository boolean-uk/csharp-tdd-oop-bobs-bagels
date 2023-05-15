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


        [TestCase("Plain Bagel")]
        public void AddBagelToBasket(string bagel)
        {
            //arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket(inventory);

            // act
            basket.AddBagel(bagel);

            //assert
            Assert.AreEqual(basket.Bagels.Count, 1);
        }



        //As a member of the public,
        //So I can change my order,
        //I'd like to remove a bagel from my basket.
        [TestCase("Cheese Bagel")]
        public void RemoveBagelFromBasket(string bagel)
        {

            //arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket(inventory);
            basket.AddBagel(bagel);

            //act
            bool result = basket.RemoveFromBasket(bagel);

            //assert
            Assert.IsTrue(result);
            Assert.AreEqual(basket.Bagels.Count, 0);
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

            string bagel1 = "Plain";
            string bagel2 = "Cheese";
            string bagel3 = "Salmon";
            string bagel4 = "Ham";
            string bagel5 = "Ham and Cheese";

            //act

            basket.AddBagel(bagel1);
            basket.AddBagel(bagel2);
            basket.AddBagel(bagel3);
            basket.AddBagel(bagel4);
            basket.AddBagel(bagel5);


            //assert

            Assert.AreEqual(basket.Bagels.Count, basket.BagelsMax);
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
            Assert.AreEqual(basket.BagelsMax, newCapacity);

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

    }
}

