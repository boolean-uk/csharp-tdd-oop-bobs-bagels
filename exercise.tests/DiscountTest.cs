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
    public class DiscountTest
    {
        private Customer _customer;

        [SetUp]
        public void SetUp()
        {
            _customer = new Customer();
        }

        [Test]
        public void SixBagelsDiscountTest()
        {
            for (int i = 0; i < 6; i++)
            {
                Bagel bagel = new(BagelVariant.Onion, new Filling(FillingVariant.Bacon));
                _customer.Order(bagel);
            }
            float sum = _customer.Basket.GetTotalPrice();
            Assert.That(sum, Is.EqualTo(2.49f + 6 * 0.12f));
        }
    }
}
