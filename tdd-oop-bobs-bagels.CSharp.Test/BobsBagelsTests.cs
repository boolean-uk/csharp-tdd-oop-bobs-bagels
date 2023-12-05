using NUnit.Framework;
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

        [Test]
        public void Test_One() //Add a bagel to the basket
        {
            //arrange
            Basket basket = new Basket();

            //act
            basket.AddBagel("BGLS");

            //assert
            Assert.That(basket.Basket.Count > 0);
        }
    }


}
