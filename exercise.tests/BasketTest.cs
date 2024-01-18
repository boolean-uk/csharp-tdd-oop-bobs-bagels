﻿using exercise.main.Foods;
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
        public Basket basket;

        [SetUp]
        public void SetUp() 
        {
            basket = new();
        }

        [Test]
        public void AddFoodItemsToBasket()
        {
            Bagel bagel = new(BagelVariant.Onion);
            Coffee coffe = new(CoffeeVariant.Black);
            Assert.DoesNotThrow(() => basket.Add(bagel));
            Assert.DoesNotThrow(() => basket.Add(coffe));
            Assert.That(basket.GetContents().Contains(bagel));
        }

        [Test]
        public void GetTotalPriceOfItemsInBasket()
        {
            Filling filling = new(FillingVariant.Ham);
            Bagel bagel = new(BagelVariant.Onion, filling);
            Coffee coffee = new(CoffeeVariant.Black);


            basket.Add(bagel);
            basket.Add(coffee);

            Assert.That(basket.GetTotalPrice(), Is.EqualTo(0.12f + 1.25f));
        }

        [Test]
        public void CanChangeBasketCapacity()
        {
            basket.Capacity = 1;
            Assert.DoesNotThrow(() => basket.Add(new Coffee(CoffeeVariant.Black)));
            Assert.Throws<Exception>(() => basket.Add(new Bagel(BagelVariant.Onion)));
        }

        [Test]
        public void ThrowsExceptionWhenRemovingNonExistingItem()
        {
            Assert.Throws<Exception>(() => basket.Remove(new Bagel(BagelVariant.Plain)));
        }
    }
}
