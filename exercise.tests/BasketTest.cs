using exercise.main.Foods;
using exercise.main.Variants;
using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    [TestFixture]
    public class BasketTest
    {
        [Test]
        public void AddFoodItemsToBasket()
        {
            Basket basket = new();
            Bagel bagel = new(BagelVariant.Onion);
            Coffee coffe = new(CoffeeVariant.Black);
            Assert.DoesNotThrow(() => basket.Add(bagel));
            Assert.DoesNotThrow(() => basket.Add(coffe));
            Assert.That(basket.GetContents().Contains(bagel));
        }

        [Test]
        public void GetTotalPriceOfItemsInBasket()
        {
            Basket basket = new();
            Bagel bagel = new(BagelVariant.Onion);
            Coffee coffee = new(CoffeeVariant.Black);
            Filling filling = new(FillingVariant.Ham);
            bagel.Filling = filling;

            basket.Add(bagel);
            basket.Add(coffee);

            Assert.That(basket.GetTotalPrice(), Is.EqualTo(0.12f + 0.99f + 0.49f));
        }
    }
}
