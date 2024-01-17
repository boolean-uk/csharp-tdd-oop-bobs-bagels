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
        [TestCase("beep", false)]
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
        [TestCase("BGLO", "BGLO", 0)]
        [TestCase("BGLP", "test", 1)]
        [TestCase("BGLE", "BGLE", 0)]
        [TestCase("BGLS", "test", 1)]
        [TestCase("BGLD", "test", 0)]
        public void Test2(string sku, string sku2, int expected)
        {
            //  Arrange - set up test values
            _bakery.AddToBasket(sku);
            int result = _bakery.RemoveFromBasket(sku2);

            //  Act - use the fucntion we want to test

            //  Assert - check the results
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(14)]
        [TestCase(2)]
        [TestCase(22)]
        [TestCase(-10)]
        public void Test3(int cap)
        {
            //  Arrange - set up test values


            //  Act - use the fucntion we want to test

            //  Assert - check the results
            if (cap > 0)
            {
                Assert.That(_bakery.ChangeCapacity(cap), Is.EqualTo(cap));
            }
            else
            {
                Assert.That(_bakery.ChangeCapacity(cap), Is.GreaterThan(cap));
            }
        }

        [Test]
        [TestCase("BGLO", 0.49d)]
        [TestCase("BGLP", 0.39d)]
        [TestCase("BGLE", 0.49d)]
        public void Test4(string sku, double expected)
        {
            //  Arrange - set up test values


            //  Act - use the fucntion we want to test

            //  Assert - check the results
            Assert.That(_bakery.BagleCost(sku), Is.EqualTo(expected));
        }

        [Test]
        [TestCase("BGLO", "FILB", 0.61d)]
        [TestCase("BGLP", "FILC", 0.51d)]
        public void Test5(string skuB, string skuF, double expected)
        {
            //  Arrange - set up test values


            //  Act - use the fucntion we want to test
            _bakery.AddToBasket(skuB);
            //  Assert - check the results
            Assert.That(_bakery.AddFilling(skuB, skuF), Is.EqualTo(expected));
        }

        [Test]
        [TestCase("FILB", 0.12d)]
        [TestCase("FILC", 0.12d)]
        [TestCase("FILE", 0.12d)]
        public void Test6(string sku, double expected)
        {
            //  Arrange - set up test values


            //  Act - use the fucntion we want to test

            //  Assert - check the results
            Assert.That(_bakery.FillingCost(sku), Is.EqualTo(expected));
        }


        [Test]  //  Discount for bagles
        [TestCase(1, 0, 0, 0.39d)]
        [TestCase(6, 1, 0, 2.61d)]
        [TestCase(12, 1, 0, 4.11d)]
        [TestCase(7, 1, 0, 3d)]
        [TestCase(13, 1, 0, 4.5d)]
        [TestCase(16, 0, 0, 5.55d)]
        [TestCase(18, 0, 0, 6.48d)]
        public void Test7(int countB, int countF, int countC, double expected)
        {
            //  Arrange - set up test values
            _bakery.ChangeCapacity(20);
            for (int i = 0; i < countB; i++)
            {
                _bakery.AddToBasket("BGLP");
            }
            for (int i = 0; i < countF; i++)
            {
                _bakery.AddFilling("BGLP", "FILC");
            }


            //  Act - use the fucntion we want to test
            double result = _bakery.CheckOut();

            //  Assert - check the results
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]  //  Discount for bagles and coffee
        public void Test7b()
        {
            //  Arrange - set up test values
            _bakery.ChangeCapacity(30);
            _bakery.AddToBasket("BGLO");
            _bakery.AddToBasket("BGLO");
            for (int i = 0; i < 12; i++)
            {
                _bakery.AddToBasket("BGLP");
            }
            for (int i = 0; i < 6; i++)
            {
                _bakery.AddToBasket("BGLE");
            }
            _bakery.AddToBasket("COFB");
            _bakery.AddToBasket("COFB");
            _bakery.AddToBasket("COFB");


            //  Act - use the fucntion we want to test
            double result = _bakery.CheckOut();

            //  Assert - check the results
            Assert.That(result, Is.EqualTo(10.43));
        }
    }
}
