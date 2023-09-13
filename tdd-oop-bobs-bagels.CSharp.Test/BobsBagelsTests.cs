using NUnit.Framework;
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
    }
}
