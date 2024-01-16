﻿using exercise.main.Class_Items;
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
        [TestCase("BGLP", "FILC", 0.61d)]
        public void Test5(string skuB, string skuF, double expected)
        {
            //  Arrange - set up test values


            //  Act - use the fucntion we want to test
            _bakery.AddToBasket(skuB);
            //  Assert - check the results
            Assert.That(_bakery.AddFilling(skuF), Is.EqualTo(expected));
        }
    }
}
