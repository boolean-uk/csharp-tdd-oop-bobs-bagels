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

        [Test]
        public void TwelveBGLPDiscountTest()
        {
            for (int i = 0; i < 12; i++)
            {
                _customer.Order(new Bagel(BagelVariant.Plain));
            }
            _customer.Order(new Coffee(CoffeeVariant.Latte));
            Assert.That(_customer.Basket.GetTotalPrice(), Is.EqualTo(3.99f + 1.29f));
        }

        [Test]
        public void CoffeeAndBagelDiscountTest()
        {
            _customer.Order(new Bagel(BagelVariant.Sesame));
            _customer.Order(new Coffee(CoffeeVariant.Black));
            Assert.That(_customer.Basket.GetTotalPrice(), Is.EqualTo(1.25f));
        }
    }
}
