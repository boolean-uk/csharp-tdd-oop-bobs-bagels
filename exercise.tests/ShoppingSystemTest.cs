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
            ActionMessage<bool> itemIsAddedToCart = s.AddItemToCart(SKU, randomID);
            Assert.IsTrue(itemIsAddedToCart.ReturnValue); //AddItem returns true when item added
            Assert.That(s.Carts[randomID][0].SKU, Is.EqualTo(SKU)); //Item exist in cart
        }

        [TestCase("NotItem")]
        [TestCase("Unrecognized Item")]
        [TestCase("")]
        public void TestAddItemToCartDoesNotAddUnrecognizedItems(string SKU)
        {
            ShoppingSystem s = new ShoppingSystem();
            Guid randomID = Guid.NewGuid();
            ActionMessage<bool> itemIsAddedToCart = s.AddItemToCart(SKU, randomID);
            Assert.IsFalse(itemIsAddedToCart.ReturnValue);
            Assert.IsTrue(itemIsAddedToCart.Message.Equals("Item does not exist!"));
            Assert.IsFalse(s.Carts.Keys.Contains(randomID)); //Does not give basket when item is unrecgnized 
        }

        [TestCase("BGLO", "COFC", "FILH")]
        public void TestAddItemsToCartCanAddMultipleItems(string SKU1, string SKU2, string SKU3)
        {
            ShoppingSystem s = new ShoppingSystem();
            Guid randomID = Guid.NewGuid();
            ActionMessage<bool> item1IsAddedToCart = s.AddItemToCart(SKU1, randomID);
            ActionMessage<bool> item2IsAddedToCart = s.AddItemToCart(SKU2, randomID);
            ActionMessage<bool> item3IsAddedToCart = s.AddItemToCart(SKU3, randomID);


            Assert.IsTrue(item1IsAddedToCart.ReturnValue);
            Assert.IsTrue(item2IsAddedToCart.ReturnValue);
            Assert.IsTrue(item3IsAddedToCart.ReturnValue);
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

            ActionMessage<bool> msg = s.AddItemToCart("BGLO", randomID);

            Assert.IsFalse(msg.ReturnValue);
            Assert.IsTrue(msg.Message == "Cart is full!");
        }

        [TestCase("BGLO")]
        public void TestAddItemToCartRemovesItemsFromInventory(string SKU)
        {
            ShoppingSystem s = new ShoppingSystem();
            Guid randomID = Guid.NewGuid();
            int itemsBefore = s.GetInventory[SKU];
            s.AddItemToCart(SKU, randomID);
            int itemsAfter = s.GetInventory[SKU];

            Assert.IsTrue(itemsAfter == (itemsBefore - 1));
            
        }

        [TestCase("BGLO")]
        public void TestAddItemDoesNotAddIfInventoryEmpty(string SKU)
        {
            ShoppingSystem s = new ShoppingSystem();
            Guid randomID = Guid.NewGuid();
            int numItems = s.GetInventory[SKU];
            for (int i = 0; i < numItems; i++)
            {
                s.AddItemToCart(SKU, randomID);
            }

            ActionMessage<bool> shouldFail = s.AddItemToCart(SKU, randomID);

            Assert.IsFalse(shouldFail.ReturnValue);
        }


        [TestCase("BGLO", "COFC")]
        public void TestRemoveItemFromCart(string SKU1, string SKU2)
        {
            ShoppingSystem s = new ShoppingSystem();
            Guid randomID = Guid.NewGuid();
            ActionMessage<bool> item1IsAddedToCart = s.AddItemToCart(SKU1, randomID);
            ActionMessage<bool> item2isAddedToCart = s.AddItemToCart(SKU2, randomID);
            ActionMessage<bool> itemIsRemoved = s.RemoveItemFromCart(SKU1, randomID);
            Assert.IsTrue(item1IsAddedToCart.ReturnValue);
            Assert.IsTrue(item2isAddedToCart.ReturnValue);
            Assert.IsTrue(itemIsRemoved.ReturnValue);
            Assert.IsTrue(s.Carts[randomID].Count == 1); //Verify that the cart only contains a single item
        }

        [TestCase("BGLO")]
        public void TestRemoveItemFromCartAddsItBackToInventory(string SKU)
        {
            ShoppingSystem s = new ShoppingSystem();
            Guid randomID = Guid.NewGuid();
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
            Guid randomID = Guid.NewGuid();
            ActionMessage<bool> m1 = s.AddItemToCart(SKU1, randomID);
            ActionMessage<bool> m2 = s.AddItemToCart(SKU2, randomID);

            double cost = s.CalculateCartCost(randomID).ReturnValue;
            Assert.IsTrue(m1.ReturnValue);
            Assert.IsTrue(m2.ReturnValue);
            Assert.That(cost, Is.EqualTo(expected));
        }

        [TestCase("BGLO", 0.49)]
        [TestCase("COFB", 0.99)]
        [TestCase("FILB", 0.12)]
        public void TestGetCost(string SKU, double expected)
        {
            ShoppingSystem s = new ShoppingSystem();
            Guid randomID = Guid.NewGuid();

            double cost = s.GetCost(SKU);

            Assert.That(expected, Is.EqualTo(cost));
        }

        
        [Test]
        public void TestNewDiscount()
        {
            ShoppingSystem s = new ShoppingSystem();
            
            Dictionary<string, int> discountItems = new Dictionary<string, int> 
            {{"BGLO", 1}, {"COFB", 1}, {"FILC", 1}};
            double discountPrice = 2;
            s.NewDiscount(discountItems, discountPrice);

           

            Assert.IsTrue(s.Discounts.Count == 1);
            Assert.IsTrue(s.Discounts[0].Price == discountPrice);
            Assert.That(s.Discounts[0].SKUCount, Is.SameAs(discountItems));
        }

        [Test]
        public void TestNewDiscountDoesNotWorkForUnrecognizedItems()
        {
            ShoppingSystem s = new ShoppingSystem();
            
            Dictionary<string, int> discountItems = new Dictionary<string, int> {{"BGLO", 1}, {"COFB", 1}, {"Not an item", 1}};
            double discountPrice = 2;
            s.NewDiscount(discountItems, discountPrice);

            Assert.IsTrue(s.Discounts.Count == 0);
            
        }

        [TestCase("BGLO", true)]
       
        public void TestFindDiscountFindsDiscountIfExist(string SKU, bool expected)
        {
            ShoppingSystem s = new ShoppingSystem();
            Guid randomID = Guid.NewGuid();

            Dictionary<string, int> discountItems = new Dictionary<string, int>
            {
                {SKU, 2}
            };

            s.NewDiscount(discountItems, 2);

            s.AddItemToCart(SKU, randomID);
            s.AddItemToCart(SKU, randomID);

            Discount discountFound = s.FindDiscount(s.Carts[randomID]);
            Assert.That(discountFound.SKUCount.Count > 0, Is.EqualTo(expected));
        }
        
        
        [TestCase("BGLO", 1)]
        [TestCase("COFB", 4)]
        [TestCase("FILB", 0.75)]
        public void TestCalcualteCostHandlesDiscounts(string SKU, double discountPrice)
        {
            ShoppingSystem s = new ShoppingSystem();
            Guid randomID = Guid.NewGuid();
            Dictionary<string, int> discountItems = new Dictionary<string, int> {{SKU, 2}, {"FILH", 1}};
            s.NewDiscount(discountItems, discountPrice);
            s.AddItemToCart(SKU, randomID);
            s.AddItemToCart(SKU, randomID);
            s.AddItemToCart(SKU, randomID); //Add one more item than the discount
            s.AddItemToCart("FILH", randomID);

            double expected_price = discountPrice + s.GetCost(SKU);
            double actualCost = s.CalculateCartCost(randomID).ReturnValue;

            Assert.IsTrue(actualCost == expected_price); 
        }

        

    }
}
