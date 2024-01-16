using exercise.main;
using exercise.main.Class_Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    internal class BasketTest
    {
        private Basket _basket;
        public BasketTest()
        {
            _basket = new Basket();
        }


        [Test]
        public void Test1()
        {
            //  Arrange - set up test values
            Bagle bagle = new Bagle("bagle");
            bool result = _basket.Add(bagle);

            //  Act - use the fucntion we want to test

            //  Assert - check the results
            Assert.That(result == true);
        }

        [Test]
        public void Test2()
        {
            //  Arrange - set up test values
            Bagle bagle = new Bagle("bagle");
            _basket.Add(bagle);
            _basket.Add(bagle);
            _basket.Add(bagle);
            _basket.Add(bagle);
            bool result = _basket.Add(bagle);

            //  Act - use the fucntion we want to test

            //  Assert - check the results
            Assert.That(result == false);
        }

        [Test]
        public void Test3()
        {
            //  Arrange - set up test values
            Bagle bagle = new Bagle("bagle");
            _basket.Add(bagle);
            _basket.Add(bagle);
            _basket.Add(bagle);
            _basket.Add(bagle);

            int result = _basket.Remove("bagle");

            //  Act - use the fucntion we want to test

            //  Assert - check the results
            Assert.That(result < 4);
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public void Test4(int i)
        {
            //  Arrange - set up test values

            //  Act - use the fucntion we want to test
            int result = _basket.ChangeCapacity(i);
            //  Assert - check the results
            Assert.That(result == i);
        }

        [Test]
        public void Test5()
        {
            //  Arrange - set up test values
            Bagle bagle = new Bagle("bagle");
            _basket.Add(bagle);
            _basket.Add(bagle);
            _basket.Add(bagle);
            _basket.Add(bagle);

            int result = _basket.Remove("doughnut");

            //  Act - use the fucntion we want to test

            //  Assert - check the results
            Assert.That(result == 4);
        }
    }
}
