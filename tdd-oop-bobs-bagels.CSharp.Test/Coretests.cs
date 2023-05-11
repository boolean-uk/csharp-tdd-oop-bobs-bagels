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
            ShopItems item1 = new ShopItems();
            item1.Name = "Onion";
            basket.AddItemToBasket(item1);
            Assert.AreEqual(basket.ShoppingBasket.Count, 1);
        }
    }
}
