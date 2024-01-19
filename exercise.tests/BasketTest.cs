using exercise.main;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    public class BasketTest

    {
        //User story 1
        [Test]
        public void ShouldAddBagelToBasket()
        {
            //Arrange
            Inventory inventory = new Inventory();
            Item bagel = inventory.GetItemBySKU("BGLE");
            Basket basket = new Basket();

            //Act
            basket.AddBagel(bagel);

            //Assert
            Assert.That(bagel.Variant, Is.EqualTo("Everything"));
        }

        //User story 2
        //Test case - Remove Bagel from basket
        [Test]

        public void ShouldRemoveBagelFromBasket()
        {
            //Arrange
            Inventory inventory = new Inventory();
            Item bagel = inventory.GetItemBySKU("BGLO");
            Basket basket = new Basket();

            //Act
            basket.AddBagel(bagel);
            bool result = basket.RemoveBagel(bagel.Sku);

            Assert.That(result, Is.True);
            Assert.IsEmpty(basket.BagelList);

        }

        //User story 3
        //This test case checks if the IsBasketFull method correctly indicates that the basket is full when attempting to add an item beyond its capacity.
        [Test]
        
        public void ShouldIndicateBasketIsFull()
        {
            // Arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket();
            Item bagel1 = inventory.GetItemBySKU("BGLO");
            Item bagel2 = inventory.GetItemBySKU("BGLP");
            Item bagel3 = inventory.GetItemBySKU("BGLE");
            basket.BasketCapacity = 2;
            // Act
            basket.AddBagel(bagel1);
            basket.AddBagel(bagel2);
            bool isBasketFullBefore = basket.IsBasketFull();
            bool isFull = basket.AddBagel(bagel3); // Adding one more item to exceed capacity

            // Assert
            Assert.IsFalse(isBasketFullBefore); // Basket should not be full before adding the third item
            Assert.IsTrue(isFull); // Basket should be full after adding the third item
        }



        //User story 4
        [Test]
        public void ShouldChangeBasketCapacity()
        {
            // Arrange
            Basket basket = new Basket();
            int newCapacity = 15;

            // Act
            bool capacityChanged = basket.ChangeBasketCapacity(newCapacity);

            // Assert
            Assert.IsTrue(capacityChanged); // Capacity should be successfully changed
            Assert.AreEqual(newCapacity, basket.BasketCapacity); // Basket capacity should now be the new value
        }



        //User story 5
        //Test case checks if the method returns false when attempting to remove an item that doesn't exist in the basket.
        [Test]
        public void ShouldNotRemoveNonexistentItem()
        {
            // Arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket();
            Item bagel1 = inventory.GetItemBySKU("BGLO");
            Item bagel2 = inventory.GetItemBySKU("BGLP");

            // Act
            basket.AddBagel(bagel1);
            basket.AddBagel(bagel2);
            bool removedNonexistentItem = basket.RemoveBagel("BGLE"); // Trying to remove a bagel that doesn't exist in the basket

            // Assert
            Assert.IsFalse(removedNonexistentItem); // Should return false as the item doesn't exist in the basket
        }


        //User story 6
        //This test case checks if the GetTotalCost method correctly calculates the total cost of bagels in the basket.
        [Test]
        public void ShouldCalculateTotalCostOfBagels()
        {
            //Arrange
            Inventory inventory = new Inventory();
            Item bagel1 = inventory.GetItemBySKU("BGLO");
            Item bagel2 = inventory.GetItemBySKU("BGLP");
            Basket basket = new Basket();

            //Act
            basket.AddBagel(bagel1);
            basket.AddBagel(bagel2);
            double totalCost = basket.GetTotalCost();

            //Assert
            Assert.That(totalCost, Is.EqualTo(bagel1.Price + bagel2.Price));

        }

        //User story 7
        //The purpose of this method is to retrieve the cost of a bagel from the inventory without adding it to the basket. 

        [Test]
        public void ShouldGetCostOfBagelWithoutAddingToBasket()
        {
            // Arrange
            Inventory inventory = new Inventory();
            Item bagel = inventory.GetItemBySKU("BGLE");
            Basket basket = new Basket();

            // Act
            double bagelCost = basket.GetBagelCost(bagel.Sku);

            // Assert
            Assert.That(bagelCost, Is.EqualTo(bagel.Price));
        }

        //User story 8
        // This test case checks if your get the chosen filling for the bagel
        [Test]
        public void ShouldGetChosenFillingForBagel()
        {
            // Arrange
            Inventory inventory = new Inventory();
            Item bagelWithFilling = inventory.GetItemBySKU("FILB"); 
            Basket basket = new Basket();

            // Act
            string chosenFilling = basket.GetChosenFilling(bagelWithFilling.Sku);

            // Assert
            Assert.That(chosenFilling, Is.EqualTo(bagelWithFilling.Variant));
        }



        //User story 9
        //This test case gets the cost of each filling
        [Test]
        public void ShouldGetCostOfEachFilling()
        {
            // Arrange
            Inventory inventory = new Inventory();
            Item filling = inventory.GetItemBySKU("FILX"); 
            Basket basket = new Basket();

            // Act
            double fillingCost = basket.GetCostOfEachFilling(filling.Sku);

            // Assert
            Assert.That(fillingCost, Is.EqualTo(filling.Price));
        }




        //User story 10
        //This test case makes sure that customers can only order items in stock
        [Test]
        public void ShouldNotAddOutOfStockItemToBasket()
        {
            // Arrange 
            Inventory inventory = new Inventory();
            Item outOfStockItem = new Item("INVALID", 99.99d, "Invalid Item", "Invalid Variant");
            Basket basket = new Basket();

            // Act
            bool addedToBasket = basket.AddBagel(outOfStockItem);

            // Assert
            Assert.That(addedToBasket, Is.False);
        }

        /*----------------------------------------------------------------EXTENSION 1 -------------------------------------------------------------------------------*/

        //This testcase cheks if special offer is working when we add multiple bagels
        [Test]
        public void SpecialOfferShouldWorkWhenAddingMulitpleBagels()
        {
            //Arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket();

            //Act
            Item bagel = inventory.GetItemBySKU("BGLE");
            int quantity = bagel.Offer.Quantity;
            double specialPrice = bagel.Offer.SpecialPrice;

            for (int i = 0; i < quantity; i++)
            {
                basket.AddBagel(bagel);
            }

            double totalCost = basket.GetTotalCost();

            // Assert
            Assert.AreEqual(specialPrice, totalCost);

        }
        //Test case checks if the customer can buy mix of items while the specialOffer still works
        [Test]
        public void ShouldCalculateTotalCostWithMixedBagelsAndSpecialOffer()
        {
            // Arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket();

            // Act
            Item bagelWithOffer = inventory.GetItemBySKU("BGLE");
            Item bagelWithoutOffer = inventory.GetItemBySKU("BGLP");

            int quantityWithOffer = bagelWithOffer.Offer.Quantity;
            double specialPrice = bagelWithOffer.Offer.SpecialPrice;

            // Adding bagels with special offer
            for (int i = 0; i < quantityWithOffer; i++)
            {
                basket.AddBagel(bagelWithOffer);
            }

            // Adding bagels without special offer
            basket.AddBagel(bagelWithoutOffer);

            double totalCost = basket.GetTotalCost();

            // Assert
            Assert.AreEqual(specialPrice + bagelWithoutOffer.Price, totalCost);
        }

        /*----------------------------------------------------------------EXTENSION 2 -------------------------------------------------------------------------------*/


    }
}
