using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Runtime.CompilerServices;
using NUnit.Framework.Interfaces;

namespace exercise.tests
{
    [TestFixture]
    public class Tests
    {

        Basket basket;
        private Item item1;
        private Item item2;
        private Item item3;
        private Item item4;
        private Item item5;
        private Item item6;
        private Item item7; 
        private Item item8;

        [SetUp]

        public void SetUp()

        {
            // Arrange for all tests

            basket = new Basket(20);
            item1 = new Item("BGLO", 0.49M, "Bagel", "Onion");
            item2 = new Item("BGLP", 0.39M, "Bagel", "Plain");
            item3 = new Item("BGLE", 0.49M, "Bagel", "Everything");
            item4 = new Item("BGLS", 0.49M, "Bagel", "Sesame");
            item5 = new Item("BGLS", 0.49M, "Bagel", "Sesame");
            item6 = new Item("BGLS", 0.49M, "Bagel", "Sesame");
            item7 = new Item("FILS", 0.12M, "Filling", "Smoked Salmon");
            item8 = new Item("COFB", 0.99M, "Coffee", "Black");

            basket.AddItem(item1);
            basket.AddItem(item2);
          
           // Console.WriteLine("heihei");
        }

        [Test]
        public void AddAndRemoveItem()
        {
            //2 requirements - Adding and removing items from basket

            //Act
            basket.ChangeCapacityForBaskets(3);
            string addedMessage = basket.AddItem(item3);
            bool removed = basket.RemoveItem(item1);
            basket.AddItem(item2);
            string basketFull = basket.AddItem(item4);
            //string NotInInventory = basket.AddItem(new Item("BGLC", 0.50M, "Bagel", "Chicken"));

            //Assert

            Assert.That(addedMessage, Is.EqualTo("The item was successfully added"));
            Assert.IsTrue(removed);
            Assert.That(basketFull, Is.EqualTo("Cannot add the item because the basket is full"));
            //Assert.That(NotInInventory, Is.EqualTo("This item does not exist in the inventory"));
        }

        [Test]

        public void CheckIfInInventory()
        {
            //Requirement - Can`t order items not in inventory 

            //Act

            string nonExistingSku = "NOTVALID";
            bool result = basket.CheckIfInInventory(nonExistingSku);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void ChangeCapacity()
        {
            //Act
            int changedCapacity = basket.ChangeCapacityForBaskets(15);

            //Assert
            Assert.That(changedCapacity, Is.EqualTo(15));
        }


        [Test]
        public void CostBagel()
        {


            //Act
            decimal cost = basket.BagelCost(item1);

            //Assert
            Assert.That(cost, Is.EqualTo( 0.49M));
        }

        [Test]
        public void CostFilling()
        {

            //Act
            decimal cost = basket.CheckFillingPrice(item7);

            //Assert
            Assert.That(cost, Is.EqualTo(0.12M));
        
        }

        [Test]
        public void CanRemoveItemFromBasket()
        {
            //Act 
            string message = basket.CanRemoveItemFromBasket(item1);
            string error_message = basket.CanRemoveItemFromBasket(item4);

            //Assert
            Assert.That(message, Is.EqualTo("Item can be removed"));
            Assert.That(error_message, Is.EqualTo("Item is not in the basket, and therefore can`t be removed"));


        }


        [Test]
        public void CheckForDiscount()
        {
            //Arrange
            basket.AddItem(item1);
            basket.AddItem(item1); //Adding 5 Bagel Onion to have 6 for the discount
            basket.AddItem(item1);
            basket.AddItem(item1);
            basket.AddItem(item1);
            basket.AddItem(item2); //Adding plain bagel      
            basket.AddItem(item8); //Adding Coffee to get the pairing discount with plain bagel

            //Act
            decimal totalPrice = basket.CalculateTotalPriceWithDiscount();
            basket.GenerateReceipt();
            basket.PrintBasketList();


            //Discount should be: 
            //6 Onion Bagel 2,49 
            // Plain Bagel x 1 = 0.39 
            // Everything Bagel x 1 = 0.49
            // Black coffee + Plain Bagel = 1.25
            // 2.49 + 0.78 + 1.25 = 4.62

            //Assert
            decimal expectedPriceWithDiscounts = 2.49M + 0.39M  + 1.25M;    
            Assert.That(totalPrice, Is.EqualTo(expectedPriceWithDiscounts));
        }

        [Test]
        public void CheckForPlainBagelDiscount()
        {
            //Arrange
            basket.AddItem(item2);
            basket.AddItem(item2); 
            basket.AddItem(item2);
            basket.AddItem(item2);
            basket.AddItem(item2);
            basket.AddItem(item2);      
            basket.AddItem(item2); 
            basket.AddItem(item2);
            basket.AddItem(item2);  
            basket.AddItem(item2);
            basket.AddItem(item2);

            //Act
            decimal totalPrice = basket.CalculateTotalPriceWithDiscount();
            basket.GenerateReceipt();
            basket.PrintBasketList();


            //Price should be: 
            
            // Plain Bagel x 12 = 3.99 
            // Bagel Onion x 1  = 0.49
            

            //Assert
            decimal expectedPriceWithDiscounts = 3.99M + 0.49M;
            Assert.That(totalPrice, Is.EqualTo(expectedPriceWithDiscounts));
        }

        [Test]
        public void CountItemsInBasket()
       
            //Act
        {   
            basket.AddItem(item4);
            basket.AddItem(item5);
            basket.AddItem(item6);
            int count = basket.CountItemsBySku("BGLS");

            //Assert
            Assert.That(count, Is.EqualTo(3));
        }


        [Test]

        public void CheckForReceipt()
        {
            //Assert
            Assert.That( basket.GenerateReceipt, Is.Not.EqualTo(null));
        }

        

    }
}

            