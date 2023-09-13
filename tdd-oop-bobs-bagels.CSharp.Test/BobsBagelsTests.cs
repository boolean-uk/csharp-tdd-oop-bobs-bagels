﻿using NUnit.Framework;
using tdd_oop_bobs_bagels.CSharp.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Test
{
    [TestFixture]
    public class BobsBagelsTests
    {
        private BobsBagelsApp arrange()
        {
            BobsBagelsApp basket = new BobsBagelsApp();
            basket.AddBagel("plain");
            basket.AddBagel("everything");
            basket.AddBagel("onion");
            return basket;
        }

        // 1. add a specific type of bagel to my basket
        [Test]
        public void AddABagelToBasketTest()
        {
            BobsBagelsApp basket = new BobsBagelsApp();
            Assert.IsTrue(basket.AddBagel("plain"));
        }

        // 10. only be able to order things that we stock in our inventory
        [Test]
        public void AddANonExistingBagelTypeToBasketTest()
        {
            BobsBagelsApp basket = new BobsBagelsApp();
            Assert.IsFalse(basket.AddBagel("chocolate chip"));
        }

        // 2. remove a bagel from my basket
        [Test]
        public void RemoveABagelFromBasketTest()
        {
            BobsBagelsApp basket = arrange();

            Assert.IsTrue(basket.RemoveBagel("onion"));

            Assert.IsTrue(basket.BagelsNum == 2);
        }

        // 3. know when my basket is full when I try adding an item beyond my basket capacity
        [Test]
        public void Add4BagelsToBasketTest()
        {
            BobsBagelsApp basket = arrange();

            Assert.IsFalse(basket.AddBagel("sesame"));
        }

        // 4. change the capacity of baskets (As a Bob's Bagels manager)
        [Test]
        public void ChangeCapacityOfBasketTest()
        {
            BobsBagelsApp basket = arrange();
            
            Assert.IsTrue(basket.ChangeCapacity(4, true));

            Assert.IsTrue(basket.BasketCapacity == 4);
            Assert.IsTrue(basket.AddBagel("sesame"));
        }

        // 4. change the capacity of baskets (As a Bob's Bagels manager)
        [Test]
        public void DontChangeCapacityOfBasketTest()
        {
            BobsBagelsApp basket = arrange();
            Assert.IsTrue(basket.ChangeCapacity(3, true));
            
            Assert.IsFalse(basket.ChangeCapacity(12, false));

            Assert.IsTrue(basket.BasketCapacity == 3);
            Assert.IsFalse(basket.AddBagel("sesame"));
        }

        // 5. know if I try to remove an item that doesn't exist in my basket
        [Test]
        public void RemoveANonExistingBagelFromBasketTest()
        {
            BobsBagelsApp basket = arrange();

            Assert.IsFalse(basket.RemoveBagel("salt"));
        }

        // 6. know the total cost of items in my basket
        [Test]
        public void GetTotalCostTest()
        {
            BobsBagelsApp basket = arrange();

            Assert.IsTrue(basket.GetTotalCost() == 1.37);
        }

        // 6. know the total cost of items in my basket
        [Test]
        public void GetTotalCostOfEmptyBasketTest()
        {
            BobsBagelsApp basket = new BobsBagelsApp();

            Assert.IsTrue(basket.GetTotalCost() == 0.0);
        }

        // 7. know the cost of a bagel before I add it to my basket
        [TestCase("onion", 0.49)]
        [TestCase("plain", 0.39)]
        [TestCase("everything", 0.49)]
        [TestCase("sesame", 0.49)]
        public void GetBagelCostTest(string bagelType, double cost)
        {
            BobsBagelsApp basket = new BobsBagelsApp();

            Assert.IsTrue(basket.GetBagelCost(bagelType) == cost);
            Assert.IsTrue(basket.AddBagel(bagelType));
        }

        // 10. only be able to order things that we stock in our inventory
        [TestCase("salt")]
        [TestCase("chocolate chip")]
        public void GetCostOfNonExistingBagelTypeTest(string bagelType)
        {
            BobsBagelsApp basket = new BobsBagelsApp();

            Assert.IsTrue(Double.IsNaN(basket.GetBagelCost(bagelType)));
        }

        // 8. choose fillings for my bagel
        [Test]
        public void AddABagelWithFillingsToBasketTest()
        {
            BobsBagelsApp basket = new BobsBagelsApp();
            List<string> fillingTypes = new List<string> {"cream cheese", "cheese", "ham"};

            Assert.IsTrue(basket.AddBagelWithFillings("plain", fillingTypes));
        }

        // 10. only be able to order things that we stock in our inventory
        [Test]
        public void DontAddABagelWithNonExistingFillingsToBasketTest()
        {
            BobsBagelsApp basket = new BobsBagelsApp();
            List<string> fillingTypes1 = new List<string> {"strawberry", "nutella"};
            List<string> fillingTypes2 = new List<string> {"ham", "cheese", "tomato"};

            Assert.IsFalse(basket.AddBagelWithFillings("plain", fillingTypes1));
            Assert.IsFalse(basket.AddBagelWithFillings("plain", fillingTypes2));
        }

        // 9. know the cost of each filling before I add it to my bagel order
        [TestCase("bacon", 0.12)]
        [TestCase("egg", 0.12)]
        [TestCase("cheese", 0.12)]
        [TestCase("cream cheese", 0.12)]
        [TestCase("smoked salmon", 0.12)]
        [TestCase("ham", 0.12)]
        public void GetFillingCostTest(string fillingType, double cost)
        {
            BobsBagelsApp basket = new BobsBagelsApp();

            Assert.IsTrue(basket.GetFillingCost(fillingType) == cost);
            Assert.IsTrue(basket.AddBagelWithFillings("everything", new List<string> {fillingType}));
        }

        // 10. only be able to order things that we stock in our inventory
        [TestCase("salt")]
        [TestCase("chocolate chip")]
        public void GetCostOfNonExistingFillingTypeTest(string fillingType)
        {
            BobsBagelsApp basket = new BobsBagelsApp();

            Assert.IsTrue(Double.IsNaN(basket.GetFillingCost(fillingType)));
        }

        // 6. know the total cost of items in my basket
        [Test]
        public void GetTotalCostOfBasketWithBagelsWithFillingsTest()
        {
            BobsBagelsApp basket = new BobsBagelsApp();
            basket.AddBagel("everything");
            basket.AddBagelWithFillings("plain", new List<string> {"cream cheese", "ham", "cheese"});
            basket.AddBagelWithFillings("onion", new List<string> {"cream egg", "bacon", "cheese"});
            double expectedCost = 2.09;

            Assert.IsTrue(basket.GetTotalCost() == expectedCost);
        }

    }
}
