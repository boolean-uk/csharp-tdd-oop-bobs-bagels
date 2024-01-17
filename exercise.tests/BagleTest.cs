using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    [TestFixture]
    public class BagleTest
    {
        [Test]
        public void BagelProperties_AreSetCorrectly()
        {
            // Arrange
            Bagel bagel = new Bagel("BGLO", 0.49m, "Bagel", "Onion");

            // Assert
            Assert.AreEqual("BGLO", bagel.SKU);
            Assert.AreEqual(0.49m, bagel.Price);
            Assert.AreEqual("Bagel", bagel.Name);
            Assert.AreEqual("Onion", bagel.Variant);
        }
    }
}
