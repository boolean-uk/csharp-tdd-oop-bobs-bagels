using exercise.main;
using exercise.main.Foods;
using exercise.main.Variants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    [TestFixture]
    public class CustomerTest
    {
        private Customer _customer;

        [SetUp]
        public void SetUp()
        {
            _customer = new();
        }

        [Test]
        public void CustomerCanOrderFoodTest()
        {
            Bagel bagel = new(BagelVariant.Sesame);
            Filling filling = new(FillingVariant.Cream_Cheese);
            bagel.Filling = filling;
            _customer.Order(bagel);
            Assert.That(_customer.Basket.Count == 1, Is.True);
        }
    }
}
