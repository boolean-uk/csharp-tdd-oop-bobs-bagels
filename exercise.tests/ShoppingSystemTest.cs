using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using exercise.main;
using NUnit.Framework.Interfaces;

namespace exercise.tests
{
    public class ShoppingSystemTest
    {

        [TestCase("BGLO")]
        public void TestAddItemToCartAddsItemToCart(string SKU)
        {
            ShoppingSystem s = new ShoppingSystem();
            Guid randomID = Guid.NewGuid();
            ActionMessage itemIsAddedToCart = s.AddItemToCart(SKU, randomID);
            Assert.IsTrue(itemIsAddedToCart.Success); //AddItem returns true when item added
            Assert.That(s.Carts[randomID][0].SKU, Is.EqualTo(SKU)); //Item exist in cart
        }

        [TestCase("NotItem")]
        [TestCase("Unrecognized Item")]
        [TestCase("")]
        public void TestAddItemToCartDoesNotAddUnrecognizedItems(string SKU)
        {
            ShoppingSystem s = new ShoppingSystem();
            Guid randomID = Guid.NewGuid();
            ActionMessage itemIsAddedToCart = s.AddItemToCart(SKU, randomID);
            Assert.IsFalse(itemIsAddedToCart.Success);
            Assert.IsTrue(itemIsAddedToCart.Message.Equals("Item does not exist!"));
            Assert.IsFalse(s.Carts.Keys.Contains(randomID)); //Does not give basket when item is unrecgnized 
        }

        [TestCase("BGLO", "COFC", "FILH")]
        public void TestAddItemsToCartCanAddMultipleItems(string SKU1, string SKU2, string SKU3)
        {
            ShoppingSystem s = new ShoppingSystem();
            Guid randomID = Guid.NewGuid();
            ActionMessage item1IsAddedToCart = s.AddItemToCart(SKU1, randomID);
            ActionMessage item2IsAddedToCart = s.AddItemToCart(SKU2, randomID);
            ActionMessage item3IsAddedToCart = s.AddItemToCart(SKU3, randomID);


            Assert.IsTrue(item1IsAddedToCart.Success);
            Assert.IsTrue(item2IsAddedToCart.Success);
            Assert.IsTrue(item3IsAddedToCart.Success);
            Assert.IsTrue(s.Carts[randomID].Count == 3);
        }

        [Test]
        public void TestAddItemToCartCannotAddMoreIfFull()
        {
            ShoppingSystem s = new ShoppingSystem();
            Guid randomID = Guid.NewGuid();
            for (int i = 0; i <= s.CartSize; i++)
            {
                s.AddItemToCart("BGLO", randomID);
            }

            ActionMessage msg = s.AddItemToCart("BGLO", randomID);

            Assert.IsFalse(msg.Success);
            Assert.IsTrue(msg.Message == "Cart is full!");
        }

        [TestCase("BGLO")]
        public void TestAddItemToCartRemovesItemsFromInventory(string SKU)
        {
            ShoppingSystem s = new ShoppingSystem();
            Guid randomID = new Guid();
            int itemsBefore = s.GetInventory[SKU];
            s.AddItemToCart(SKU, randomID);
            int itemsAfter = s.GetInventory[SKU];

            Assert.IsTrue(itemsAfter == (itemsBefore - 1));
            
        }

        [TestCase("BGLO")]
        public void TestAddItemDoesNotAddIfInventoryEmpty(string SKU)
        {
            ShoppingSystem s = new ShoppingSystem();
            Guid randomID = new Guid();
            int numItems = s.GetInventory[SKU];
            for (int i = 0; i < numItems; i++)
            {
                s.AddItemToCart(SKU, randomID);
            }

            ActionMessage shouldFail = s.AddItemToCart(SKU, randomID);

            Assert.IsFalse(shouldFail.Success);
        }


        [TestCase("BGLO", "COFC")]
        public void TestRemoveItemFromCart(string SKU1, string SKU2)
        {
            ShoppingSystem s = new ShoppingSystem();
            Guid randomID = Guid.NewGuid();
            ActionMessage item1IsAddedToCart = s.AddItemToCart(SKU1, randomID);
            ActionMessage item2isAddedToCart = s.AddItemToCart(SKU2, randomID);
            ActionMessage itemIsRemoved = s.RemoveItemFromCart(SKU1, randomID);
            Assert.IsTrue(item1IsAddedToCart.Success);
            Assert.IsTrue(item2isAddedToCart.Success);
            Assert.IsTrue(itemIsRemoved.Success);
            Assert.IsTrue(s.Carts[randomID].Count == 1); //Verify that the cart only contains a single item
        }

        [TestCase("BGLO")]
        public void TestRemoveItemFromCartAddsItBackToInventory(string SKU)
        {
            ShoppingSystem s = new ShoppingSystem();
            Guid randomID = new Guid();
            int inventoryBefore = s.GetInventory[SKU];
            s.AddItemToCart(SKU, randomID);
            int inventoryAfterAdd = s.GetInventory[SKU];
            s.RemoveItemFromCart(SKU, randomID);
            int inventoryAfter = s.GetInventory[SKU];

            Assert.IsTrue(inventoryAfterAdd < inventoryBefore && inventoryAfter == inventoryBefore);
            
        }


        

        [TestCase(11)]
        [TestCase(20)]
        [TestCase(13)]
        public void TestChangeCapasityOfCart(int newSize) 
        {
            ShoppingSystem s = new ShoppingSystem();
            s.ChangeCapacityOfCart(newSize);

            Assert.That(newSize, Is.EqualTo(s.CartSize));   
        }

      

        [TestCase("BGLO", "BGLE", 0.98)]
        public void TestGetCartCost(string SKU1, string SKU2, double expected)
        {
            ShoppingSystem s = new ShoppingSystem();
            Guid randomID = new Guid();
            ActionMessage m1 = s.AddItemToCart(SKU1, randomID);
            ActionMessage m2 = s.AddItemToCart(SKU2, randomID);

            double cost = s.GetCartCost(randomID);
            Assert.IsTrue(m1.Success);
            Assert.IsTrue(m2.Success);
            Assert.That(cost, Is.EqualTo(expected));
        }

        [TestCase("BGLO", 0.49)]
        [TestCase("COFB", 0.99)]
        [TestCase("FILB", 0.12)]
        public void TestGetCost(string SKU, double expected)
        {
            ShoppingSystem s = new ShoppingSystem();
            Guid randomID = new Guid();

            double cost = s.GetCost(SKU);

            Assert.That(expected, Is.EqualTo(cost));
        }

    }
}
