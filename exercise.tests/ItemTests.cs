using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main;

namespace exercise.tests
{
    [TestFixture]
    public class ItemTests
    {
        [Test]
        public void TestAddFilling()
        {
            Bagel bagel = new Bagel("BGLO", 0.49d, "Bagel", "Onion");
            Filling filling = new Filling("FILE", 0.12d, "Filling", "Egg");


            bool addedFilling = bagel.AddFilling(filling);

            Assert.That(addedFilling, Is.True);
            Assert.That(bagel.Fillings.Count(), Is.EqualTo(1));
        }

        [Test]
        public void TestRemoveFilling()
        {
            Bagel bagel = new Bagel("BGLO", 0.49d, "Bagel", "Onion");
            Filling filling = new Filling("FILE", 0.12d, "Filling", "Egg");


            bagel.AddFilling(filling);
            bagel.RemoveFilling(filling);

            Assert.That(bagel.Fillings.Count() == 0);

        }

        [Test]
        public void TestCheckItemCost()
        {
            Item coffee = new Coffee("COFB", 0.99d, "Bagel", "Black");
            Item bagel = new Bagel("BGLO", 0.49d, "Bagel", "Onion");
            Item filling = new Filling("FILE", 0.12d, "Filling", "Egg");

            Assert.That(coffee.CheckItemCost(), Is.EqualTo(0.99d));
            Assert.That(bagel.CheckItemCost(), Is.EqualTo(0.49d));
            Assert.That(filling.CheckItemCost(), Is.EqualTo(0.12d));
        }
    }
}
