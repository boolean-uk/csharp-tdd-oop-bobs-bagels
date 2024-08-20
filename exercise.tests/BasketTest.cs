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

        public void checkIfItemAdded()
        {

            //arrange
            Basket basket = new Basket();
            Inventory inventory = new Inventory();
            string itemToAdd = "Bagel";
            string Variant = "Plain";



            //act
            basket.addItemToBasket(itemToAdd, Variant);
            Item item = basket.basketItems.FirstOrDefault(x => x.name == itemToAdd && x.variant == Variant);

            //Assert
            Assert.IsTrue(basket.basketItems.Contains(item));
        }



        [Test]
        public void checkIfItemRemoved()
        {

            //arrange
            Basket basket = new Basket();
            Inventory inventory = new Inventory();
            string itemToAdd = "Bagel";
            string Variant = "Plain";

            //act
            basket.removeItemFromBasket(itemToAdd, Variant);
            Item item = basket.basketItems.FirstOrDefault(x => x.name == itemToAdd && x.variant == Variant);

            //Assert
            Assert.IsFalse(basket.basketItems.Contains(item));
        }




        [Test]

        public void checkIfBasketCapacityChanged()
        {

            //arrange
            Basket basket = new Basket();
            Inventory inventory = new Inventory();
            int newCapacity = 10;

            //act
            basket.changeBasketCap(newCapacity);

            //Assert
            Assert.AreEqual(basket.maxCapacity, newCapacity);
        }
    

        [Test]

        public void checkIfSumCorrect()
        {

            //arrange
            Basket basket = new Basket();
            Inventory inventory = new Inventory();
            decimal expectedSum = basket.sum;

            //act
            decimal currentsum = basket.calcCurrentSum();

            //Assert
            Assert.AreEqual(expectedSum, currentsum);
        }

      

        [Test]
        public void checkIfPriceCorrect()
        {

            //arrange
            Basket basket = new Basket();
            Inventory inventory = new Inventory();
            double expectedPrice = 0.49;

            //act
            decimal currentPrice=basket.getItemCost("Bagel","Plain");

            //Assert
            Assert.AreEqual((expectedPrice), currentPrice);
        }

        [Test]
        public void checkIfExists()
        {


            //arrange
            Basket basket = new Basket();
            Inventory inventory = new Inventory();
            Item item = new Item("DDDD", 0.11m, "Salad", "Onion");

            //act
            basket.item_Exists(item);

            //Assert
            Assert.IsFalse(basket.item_Exists(item));
        }



        [Test]
        [TestCase(6, 2.49)]
        [TestCase(12,3.96)]
        public void checkIfDiscountApplied(int quantity, decimal expectedSum)
        {

            //arrange 
           Basket basket = new Basket();
           Inventory inventory = new Inventory();



            //act

            for (int i = 0; i < quantity; i++)
            {
                basket.addItemToBasket("Bagel", "Onion");
            }


            //Assert

            basket.DiscountReceipt();
            Assert.That(expectedSum, Is.EqualTo(basket.sum));

        }


        [Test]

        public void checkIfReceiptPrinted()
        {

        }
    }

}

