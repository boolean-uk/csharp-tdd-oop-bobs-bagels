using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tdd_oop_bobs_bagels.CSharp.Main;

namespace tdd_oop_bobs_bagels.CSharp.Test
{
    [TestFixture]
    public  class BagelTests
    {
        [Test]
        public void CheckifExistsToAdd()
        {
            //arrange
            Items item = new Items("BGLO", 0.49m, "Bagel", "Onion");
            BagelsShop bagelsShop = new BagelsShop();
            //act
            bool result = bagelsShop.addBagel(item, Roles.Shopper);
            //assert
            Assert.IsTrue(result);

        }
        [Test]
        public void CheckifExistsToRemove()
        {
            //arrange
            Items item = new Items("BGLO", 0.49m, "Bagel", "Onion");
            Items item1 = new Items("COFC", 1.29m, "Coffee", "Cappucino");


            BagelsShop bagelsShop = new BagelsShop();
            bagelsShop.addBagel(item, Roles.Shopper);
            bagelsShop.addBagel(item1, Roles.Shopper);
            //act
            bool result = bagelsShop.RemoveBagel(item1, Roles.Shopper);
            //assert
            Assert.IsTrue(result);

        }
    }
}
