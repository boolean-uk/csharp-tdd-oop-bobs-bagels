using csharp_tdd_oop_bobs_bagels_Csharp_Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Test
{
    [TestFixture]
    public class Coretests
    {
        [Test] 
        public void AddBagelTest()
        {
            Basket basket = new Basket();
            ShopItem item1 = new ShopItem("BGLO", "Onion", 0.49m, "Bagel");
            basket.AddItemToBasket(item1);
            Assert.AreEqual(basket.ShoppingBasket.Count, 1);
        }

        [TestCase("BGLO")]
        [TestCase("Hello")]
        public void RemoveBagelTest(string SDK) 
        {
            Basket basket = new Basket();
            ShopItem item1 = new ShopItem("BGLO", "Onion", 0.49m, "Bagel");
            ShopItem item2 = new ShopItem("BGLP", "Plain", 0.39m, "Bagel");

            basket.AddItemToBasket(item1);
            basket.AddItemToBasket(item2);
            int count = basket.ShoppingBasket.Count;
            bool removeResult = basket.RemoveItemFromBasket(SDK);
            int minuscount = 0;
            if (removeResult) 
            {
                minuscount++; 
            }

            
            Assert.AreEqual(count -minuscount, basket.ShoppingBasket.Count);

        }

        [Test]
        public void isBasketFullTest() 
        {
            Basket basket = new Basket();
            basket.TestData();
            ShopItem item1 = new ShopItem("COFB", "Black", 0.49m, "Coffee");
            ShopItem item2 = new ShopItem("COFW", "White", 0.39m, "Coffee");

            basket.AddItemToBasket(item1);
            basket.AddItemToBasket(item2);

            Assert.AreEqual(basket.ShoppingBasket.Count, basket.ShoppingBasketMax);

        }

        [TestCase(7, true)]
        [TestCase(4, false)]
        public void ChangeBasketMaxTest(int value, bool expected)
        {
            Basket basket = new Basket(); 
            basket.TestData();
            basket.SetBasketMax(value);
            Assert.AreEqual(value == basket.ShoppingBasketMax, expected);
            

        }

        [Test]
        public void CalculateTotalTest()
        {
            Basket basket = new Basket(); 
            basket.TestData();

            Assert.AreEqual(basket.CalculateTotal(), 1.86m);
        }
    }
}
