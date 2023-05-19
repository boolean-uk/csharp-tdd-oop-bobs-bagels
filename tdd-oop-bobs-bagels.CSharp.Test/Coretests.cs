using csharp_tdd_oop_bobs_bagels_Csharp_Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
            basket.AddItemToBasket(item1, 3);
            Assert.AreEqual(basket.ShoppingBasket.Count, 1);
        }

        [TestCase("BGLO")]
        [TestCase("Hello")]
        public void RemoveBagelTest(string SDK)
        {
            Basket basket = new Basket();
            ShopItem item1 = new ShopItem("BGLO", "Onion", 0.49m, "Bagel");
            ShopItem item2 = new ShopItem("BGLP", "Plain", 0.39m, "Bagel");

            basket.AddItemToBasket(item1, 1);
            basket.AddItemToBasket(item2, 1);
            int count = basket.ShoppingBasket.Count;
            bool removeResult = basket.RemoveItemFromBasket(SDK);
            int minuscount = 0;
            if (removeResult)
            {
                minuscount++;
            }


            Assert.AreEqual(count - minuscount, basket.ShoppingBasket.Count);

        }

        [Test]
        public void isBasketFullTest()
        {
            Basket basket = new Basket();
            basket.TestData();
            ShopItem item1 = new ShopItem("COFB", "Black", 0.49m, "Coffee");
            ShopItem item2 = new ShopItem("COFW", "White", 0.39m, "Coffee");

            basket.AddItemToBasket(item1, 1);
            basket.AddItemToBasket(item2, 1);

            Assert.AreEqual(basket.ShoppingBasket.Count, basket.ShoppingBasketMax);

        }

        [TestCase(7, true)]
        [TestCase(3, false)]
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

        [Test]
        public void IsFillingAdded()
        {
            Basket basket = new Basket();
            basket.TestData();
            ShopItem filling = new ShopItem("FILB", "Bacon", 0.12m, "Filling");
            ShopItem bagel = new ShopItem("BGLP", "Plain", 0.39m, "Bagel");
            basket.AddFilling(bagel, filling);
            Assert.AreEqual(filling, basket.ShoppingBasket.FirstOrDefault(i => i.SKU == bagel.SKU).Extras.FirstOrDefault(i => i.SKU == filling.SKU));

        }

        [TestCase(6, 2.49)]
        [TestCase(12, 4.98)]
        [TestCase(13, 5.47)]


        public void Discount6Test(int amount, decimal expected)
        {
            Basket basket = new Basket();
            ShopItem item1 = new ShopItem("BGLO", "Onion", 0.49m, "Bagel");
            basket.AddItemToBasket(item1, amount);

            Assert.AreEqual(expected, basket.CalculateTotal());


        }

        [Test]
        public void Discount2times6Test()
        {
            Basket basket = new Basket();
            ShopItem item1 = new ShopItem("BGLO", "Onion", 0.49m, "Bagel");
            basket.AddItemToBasket(item1, 6);
            ShopItem item2 = new ShopItem("BGLE", "Everything", 0.49m, "Bagel");
            basket.AddItemToBasket(item1, 6);

            Assert.AreEqual(4.98m, basket.CalculateTotal());


        }

        [Test]
        public void ExampleTest()
        {
            Basket basket = new Basket();
            ShopItem item1 = new ShopItem("BGLO", "Onion", 0.49m, "Bagel");
            basket.AddItemToBasket(item1, 2);
            ShopItem item2 = new ShopItem("BGLP", "Plain", 0.39m, "Bagel");
            basket.AddItemToBasket(item2, 12);
            ShopItem item3 = new ShopItem("BGLE", "Everything", 0.49m, "Bagel");
            basket.AddItemToBasket(item3, 6);
            ShopItem item4 = new ShopItem("COFB", "Black", 0.99m, "Coffee");
            basket.AddItemToBasket(item4, 3);


            Assert.AreEqual(10.43m, basket.CalculateTotal());


        }

    }
}
