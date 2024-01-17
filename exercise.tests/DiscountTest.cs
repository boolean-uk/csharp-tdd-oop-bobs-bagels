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
        public void TwelveBGLPDiscountTest2()
        {
            for (int i = 0; i < 12; i++)
            {
                _customer.Order(new Bagel(BagelVariant.Plain));
            }
            _customer.Order(new Coffee(CoffeeVariant.Latte));
            _customer.Order(new Coffee(CoffeeVariant.Black));
            _customer.Order(new Coffee(CoffeeVariant.Black));
            Assert.That(_customer.Basket.GetTotalPrice(), Is.EqualTo(3.99f + 1.29f + .99f * 2));
        }

        [Test]
        public void ExampleOrdersTest()
        {
            _customer.Order(new Bagel(BagelVariant.Onion));
            _customer.Order(new Bagel(BagelVariant.Onion));
            for (int i = 0;i < 12;i++)
            {
                _customer.Order(new Bagel(BagelVariant.Plain));
            }
            for (int i = 0;i<6;i++)
            {
                _customer.Order(new Bagel(BagelVariant.Everything));
            }
            for (int i = 0;i<3;i++)
            {
                _customer.Order(new Coffee(CoffeeVariant.Black));
            }
            float totalPrice = _customer.Basket.GetTotalPrice();
            Assert.That(Math.Abs(totalPrice - 10.43f), Is.LessThanOrEqualTo(1e-2f));
        }

        [Test]
        public void ExampleOrderTest2()
        {
            for (int i = 0; i < 16; i++)
            {
                _customer.Order(new Bagel(BagelVariant.Plain));
            }
            float totalPrice = _customer.Basket.GetTotalPrice();
            Assert.That(Math.Abs(totalPrice - 5.55), Is.LessThanOrEqualTo(1e-2f));
        }

        [Test]
        public void CalcualteDiscountTest()
        {
            _customer.Basket.Capacity = 40;
            for (int i = 0; i < 13; i++)
            {
                _customer.Order(new Bagel(BagelVariant.Plain));
            }
            for (int i = 0; i < 13; i++)
            {
                _customer.Order(new Bagel(BagelVariant.Onion));
            }
            float discount = _customer.Basket.CalculateDiscounts(_customer.Basket.GetContents());
            Assert.That(Math.Abs(discount - 0.69f - 0.9f), Is.LessThanOrEqualTo(1e-2));
        }
    }
}
