using exercise.main.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    internal class Extension1Tests
    {
        Store _store = new();
        Basket _basket = new(15);

        Bagel _bagel, _plain;
        Item _coffee, _latte;
        Filling _filling;

        [SetUp]
        public void SetUp()
        {
            _store.Baskets.Add(_basket);

            _bagel = new Bagel("BGLE", 0.49, Name.Bagel, "Everything");
            _plain = new Bagel("BGLP", 0.39, Name.Bagel, "Plain");
            _coffee = new Item("COFB", 0.99, Name.Coffee, "Black");
            _latte = new Item("COFL", 1.29, Name.Coffee, "Latte");
            _filling = new Filling("FILE", 0.12, Name.Filling, "Egg");

        }

        private Basket _lastBasket() { return _store.Baskets.Last(); }
        private Item _lastItem() { return _lastBasket().Items.Last(); }


        [Test]
        public void DiscountCoffeeAndBagel()
        {
            _lastBasket().Add(_bagel);
            _lastBasket().Add(_coffee);
            Assert.That(_lastBasket().DiscountedCost(), Is.EqualTo(1.25));
        }

        [Test]
        public void Discount6Bagel()
        {
            _lastBasket().Items.AddRange(Enumerable.Repeat(_bagel,6));
            Assert.That(_lastBasket().DiscountedCost(), Is.EqualTo(2.49));
        }

        [Test]
        public void Discount6Plain()
        {
            _lastBasket().Items.AddRange(Enumerable.Repeat(_plain, 6));
            Assert.That(_lastBasket().DiscountedCost(), Is.EqualTo(2.34));
        }

        [Test]
        public void Discount12Plain()
        {
            _lastBasket().Items.AddRange(Enumerable.Repeat(_plain,12));
            Assert.That(_lastBasket().DiscountedCost(), Is.EqualTo(3.99));
        }

        [Test]
        public void Discount12Plain4Latte()
        {
            _lastBasket().Items.AddRange(Enumerable.Repeat(_plain, 12));
            _lastBasket().Items.AddRange(Enumerable.Repeat(_latte, 4));
            _lastBasket().BestDiscountValue();
            Assert.That(_lastBasket().DiscountedCost(), Is.EqualTo(8.12));
        }

    }
}
