using exercise.main.Class_Items;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    internal class BakeryTests
    {
        private Bakery _bakery;
        public BakeryTests()
        {

        }

        [SetUp]
        public void SetUp()
        {
            _bakery = new Bakery();
        }

        [Test]
        [TestCase("BGLO", true)]
        [TestCase("BGLP", true)]
        [TestCase("BGLE", true)]
        [TestCase("BGLD", false)]
        [TestCase("Test", false)]
        public void Test1(string sku, bool expected)
        {
            //  Arrange - set up test values

            //Bagle bagle = new Bagle("bagle");
            bool result = _bakery.AddToBasket(sku);

            //  Act - use the fucntion we want to test

            //  Assert - check the results
            Assert.That(result == expected);
        }

        [Test]
        [TestCase("BGLO", "BGLO", true)]
        [TestCase("BGLP", "BGLO", false)]
        [TestCase("BGLE", "BGLE", true)]
        [TestCase("BGLD", "BGLE", false)]
        public void Test2(string sku, string sku2, bool expected)
        {
            //  Arrange - set up test values

            //Bagle bagle = new Bagle("bagle");
            _bakery.AddToBasket(sku);
            bool result = _bakery.RemoveFromBasket(sku);

            //  Act - use the fucntion we want to test

            //  Assert - check the results
            Assert.That(result == expected);
        }
    }
}
