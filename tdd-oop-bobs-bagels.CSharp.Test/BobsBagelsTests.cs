using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tdd_oop_bobs_bagels.CSharp.Main;

namespace tdd_oop_bobs_bagels.CSharp.Test
{
    public class TestsForBasket
    { // deleted a lot of tests from previous bobs bagel
        private TestsForBasket _basket;

        [SetUp]
        public void Setup()
        {
            _basket = new Basket;
        }

        [Test]
        public void CanWeAddItemToTheBasket()
        {
            bool success = _basket.AddItem(new Bagel("BGLO", 0.49, "Bagel", "Onion"));
            Assert.IsTrue(success);
        }

        [Test]
        public void CanWeRemoveItemFromBasket()
        {
            var bagel = new Bagel(("BGLO", 0.49, "Bagel", "Onion");
            _basket.AddItem(bagel);
            bool removed = _basket.RemoveItem(bagel);
            Assert.IsTrue(removed);
        }


    } 
}