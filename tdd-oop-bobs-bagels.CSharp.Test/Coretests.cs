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
            ShopItem item1 = new ShopItem();
            item1.Name = "Onion";
            basket.AddItemToBasket(item1);
            Assert.AreEqual(basket.ShoppingBasket.Count, 1);
        }

        [Test]
        public void RemoveBagelTest() 
        {
            Basket basket = new Basket();
            ShopItem item1 = new ShopItem();
            item1.Name = "Regular";
            ShopItem item2 = new ShopItem();
            item2.Name = "Onion";
            basket.AddItemToBasket(item1);
            basket.AddItemToBasket(item2);
            int count = basket.ShoppingBasket.Count;
            bool removeResult = basket.RemoveItemFromBasket("Onion");

            Assert.IsTrue(removeResult);
            Assert.AreEqual(count -1, basket.ShoppingBasket.Count);

        }

        [Test]
        public void isBasketFullTest() 
        {
            Basket basket = new Basket();
            basket.TestData();
            ShopItem item1 = new ShopItem();
            item1.Name = "Coffee";
            ShopItem item2 = new ShopItem();
            item2.Name = "Cheese";
            basket.AddItemToBasket(item1);
            basket.AddItemToBasket(item2);

            Assert.AreEqual(basket.ShoppingBasket.Count, basket.ShoppingBasketMax);

        }

        [TestCase(7)]
        public void ChangeBasketMaxTest(int value)
        {
            Basket basket = new Basket(); 
            basket.TestData();
            basket.SetBasketMax(value);
            Assert.AreEqual(value, basket.ShoppingBasketMax);
            

        }
    }
}
