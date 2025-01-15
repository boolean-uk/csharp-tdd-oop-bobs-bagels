using System;
using System.Collections.Generic;
using NUnit.Framework;
using exercise.main.Baskets;
using exercise.main.Products;

namespace exercise.tests.Baskets
{
    [TestFixture]
    public class PricingEngineTest
    {
        private List<Product> _products;
        private PricingEngine _engine;

        [SetUp]
        public void SetUp()
        {
            _products = new List<Product>();
            _products.Add(new Bagel("BGLO", 0.45, "Bagel", "Onion"));
            _products.Add(new Bagel("BGLO", 0.45, "Bagel", "Onion"));
            _products.Add(new Bagel("BGLO", 0.45, "Bagel", "Onion"));
            _products.Add(new Bagel("BGLO", 0.45, "Bagel", "Onion"));
            _products.Add(new Bagel("BGLO", 0.45, "Bagel", "Onion"));

            _engine = new PricingEngine();
        }

        [Test]
        public void GroupProductsByType()
        {
            var groupedProducts = _engine.GroupProductsByType(_products);

            Assert.That(groupedProducts.ContainsKey(typeof(Bagel)), Is.True);
            Assert.That(groupedProducts[typeof(Bagel)], Is.EqualTo(5));
        }

        [Test]
        public void AddNonDiscountProducts_ShouldRemoveCorrectProducts()
        {
            var basket = new Dictionary<Type, int>
            {
                { typeof(Bagel), 3 }
            };

            double remainingPrice = _engine.AddNonDiscountProducts(_products, basket);

            Assert.That(remainingPrice, Is.EqualTo(0.45 * 3));
        }

        [Test]
        public void CanApplyDiscountTrue()
        {
            var basket = new Dictionary<Type, int>
            {
                { typeof(Bagel), 3 }
            };

            var discountQuantities = new Dictionary<Type, int>
            {
                { typeof(Bagel), 3 }
            };

            bool canApply = _engine.CanApplyDiscount(basket, discountQuantities);

            Assert.That(canApply, Is.True);
        }

        [Test]
        public void CanApplyDiscountIsFalse()
        {
            var basket = new Dictionary<Type, int>
            {
                { typeof(Bagel), 2 }
            };

            var discountQuantities = new Dictionary<Type, int>
            {
                { typeof(Bagel), 3 }
            };

            bool canApply = _engine.CanApplyDiscount(basket, discountQuantities);

            Assert.That(canApply, Is.False);
        }

        [Test]
        public void CalculatePriceNoDiscount()
        {
            double totalPrice = _engine.CalculatePrice(_products);

            Assert.That(totalPrice, Is.EqualTo(0.45 * 5)); // 5 Bagels, 0.45 each
        }

        [Test]
        public void RemoveDiscountedItemsFromBasket()
        {
            var basket = new Dictionary<Type, int>
            {
                { typeof(Bagel), 5 }
            };

            var productQuantities = new Dictionary<Type, int>
            {
                { typeof(Bagel), 3 }
            };

            _engine.removeDiscountedItems(basket, productQuantities);

            Assert.That(basket[typeof(Bagel)], Is.EqualTo(2));
        }

        [Test]
        public void ExampleOrder1()
        {
            _products.Clear();
            for (int i = 0; i < 12; i++)
            {
                _products.Add(new Bagel("BGLP", 0.39, "Bagel", "Plain"));
            }

            for (int i = 0; i < 6; i++)
            {
                _products.Add(new Bagel("BGLE", 0.49, "Bagel", "Everything"));
            }

            for (int i = 0; i < 2; i++)
            {
                _products.Add(new Bagel("BGLO", 0.49, "Bagel", "Onion"));
            }


            for (int i = 0; i < 3; i++)
            {
                _products.Add(new Coffee("COFB", 0.99, "Coffee", "Black"));
            }

            double totalPrice = _engine.CalculatePrice(_products);

            

            // I am assuming that bagel discount applies regardless ov variant or combinations of such
            // Only the number of bagels determines the discount.
            // Also any bagel not included in another discount can have a bagel&coffee discount
            // So the total cost will be 12 bagels for 3.99, 6 bagels for 2.49, 2x bagel&coffee for 1.25 and one cofffe for 0.99
            Assert.That(totalPrice, Is.EqualTo(3.99 + 2.49 + 1.25 + 1.25 + 0.99)); 
        }
    }
}
