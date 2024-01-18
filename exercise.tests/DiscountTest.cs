using exercise.main;
using exercise.main.Foods;
using exercise.main.Variants;

namespace exercise.tests
{
    [TestFixture]
    public class DiscountTest
    {
        private Customer _customer;

        [SetUp]
        public void SetUp()
        {
            Basket basket = new(100);
            _customer = new Customer(basket);
        }

        [Test]
        public void SixBagelsDiscountTest()
        {
            Bagel bagel = new(BagelVariant.Onion, new Filling(FillingVariant.Bacon));
            _customer.Order(bagel, 6);
            float sum = _customer.Basket.GetTotalPrice();
            Assert.That(sum, Is.EqualTo(2.49f + 6 * 0.12f));
        }

        [Test]
        public void TwelveBGLPDiscountTest()
        {
            _customer.Order(new Bagel(BagelVariant.Plain), 12);
            _customer.Order(new Coffee(CoffeeVariant.Latte));
            Assert.That(_customer.Basket.GetTotalPrice(), Is.EqualTo(3.99f + 1.29f));
        }

        [Test]
        public void TwelveBGLPDiscountTest2()
        {
            _customer.Order(new Bagel(BagelVariant.Plain), 12);
            _customer.Order(new Coffee(CoffeeVariant.Latte));
            _customer.Order(new Coffee(CoffeeVariant.Black), 2);
            Assert.That(_customer.Basket.GetTotalPrice(), Is.EqualTo(3.99f + 1.29f + .99f * 2));
        }

        [Test]
        public void ExampleOrdersTest()
        {
            _customer.Order(new Bagel(BagelVariant.Onion), 2);
            _customer.Order(new Bagel(BagelVariant.Plain), 12);
            _customer.Order(new Bagel(BagelVariant.Everything), 6);
            _customer.Order(new Coffee(CoffeeVariant.Black), 3);

            float totalPrice = _customer.Basket.GetTotalPrice();
            Assert.That(Math.Abs(totalPrice - 10.43f), Is.LessThanOrEqualTo(1e-2f));
        }

        [Test]
        public void ExampleOrderTest2()
        {
            _customer.Order(new Bagel(BagelVariant.Plain), 16);
            float totalPrice = _customer.Basket.GetTotalPrice();
            Assert.That(Math.Abs(totalPrice - 5.55), Is.LessThanOrEqualTo(1e-2f));
        }

        [Test]
        public void CalcualteDiscountTest()
        {
            _customer.Basket.Capacity = 40;
            _customer.Order(new Bagel(BagelVariant.Plain), 13);
            _customer.Order(new Bagel(BagelVariant.Onion), 13);

            float discount = PriceCalculator.CalculateDiscounts(_customer.Basket.GetContents());
            Assert.That(Math.Abs(discount - 0.69f - 0.9f), Is.LessThanOrEqualTo(1e-2));
        }

        [Test]
        public void CoffeAndBagelDiscountTest()
        {
            _customer.Order(new Bagel(BagelVariant.Sesame));
            _customer.Order(new Coffee(CoffeeVariant.Black));

            float discount = PriceCalculator.GetTotalPrice(_customer.Basket.GetContents());
            Assert.That(Math.Abs(discount - 1.25f), Is.LessThanOrEqualTo(1e-2));
        }
    }
}
