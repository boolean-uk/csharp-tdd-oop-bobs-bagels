using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    [TestFixture]
    internal class Extension1
    {
        Basket basket;
        Bagel onion, sesame;

        [SetUp]
        public void Setup()
        {
            basket = new Basket();
            basket.ChangeCapacity(30);

            // 5xBagel nonPlain (0.49), 2xlatte (1.29), 2xBlack (0.99)
            onion = new Bagel(BagelType.Onion);
            sesame = new Bagel(BagelType.Sesame);
            basket.Add(onion);
            basket.Add(sesame);
            basket.Add(new Bagel(BagelType.Everything));
            basket.Add(new Bagel(BagelType.Onion));
            basket.Add(new Bagel(BagelType.Sesame));
            basket.Add(new Coffee(CoffeeType.Latte));
            basket.Add(new Coffee(CoffeeType.Black));
            basket.Add(new Coffee(CoffeeType.Latte));
            basket.Add(new Coffee(CoffeeType.Black));
        }

        [Test]
        public void coffeAndBagelDiscount()
        {
            // 5xBagel nonPlain (0.49), 2xlatte (1.29), 2xBlack (0.99)
            // becomes 4xCoffe+Bagel (1.25d), 1xnonPlain (0.49d)
            Assert.That(basket.TotalCost(), Is.EqualTo( 4*1.25d + 0.49 ));
        }

        [Test]
        public void coffeAndDiscountedBagel()
        {
            // 1xBagel Plain (0.39d), 5xBagel nonPlain (0.49d), 2xlatte (1.29d), 2xBlack (0.99d)
            // becomes 6xBagel (3.99d) + 2xlatte(1.29d) + 2xBlack(0.99d) + filling (0.12d)
            Bagel plain = new Bagel(BagelType.Plain);
            basket.Add(plain);
            Assert.That(Math.Round(basket.TotalCost(), 2), 
                Is.EqualTo(Math.Round(2.49d + 2 * 1.29d + 2 * 0.99d, 2)));
        }

        [Test]
        public void coffeAndDiscountedBagelWithTopping() 
        {
            // 1xBagel Plain (0.39d), 5xBagel nonPlain (0.49d), 2xlatte (1.29d), 2xBlack (0.99d)
            // becomes 6xBagel (2.49d) + 2xlatte(1.29d) + 2xBlack(0.99d) + filling (0.12d)
            Bagel plain = new Bagel(BagelType.Plain);
            basket.Add(plain);
            plain.Add(new Filling(FillingType.Cheese));
            Assert.That(Math.Round(basket.TotalCost(), 2), Is.EqualTo( Math.Round(2.49d + 2*1.29d + 2*0.99d + 0.12d, 2)));
        }

        [Test]
        public void tvelveAndSixBagelsWithCoffee()
        {
            for ( int i = 0; i < 17; i++ )
            {
                basket.Add(new Bagel(BagelType.Everything));
            }
            // 1x12Bagels (3.99d) + 1x6Bagels (2.49) + 4xBagel+Coffee (1.25d)
            double sum = basket.TotalCost();
            Assert.That(Math.Round(basket.TotalCost(), 2), Is.EqualTo(Math.Round(3.99d + 2.49d + 4*1.25d, 2)));
        }
    }
}
