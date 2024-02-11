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
            Bagel bagel = new Bagel("BEGLO");

            // Assert
            Assert.That(bagel.Variant, Is.EqualTo("Onion"));
            Assert.That(bagel.Price, Is.EqualTo(0.49));
            Assert.That(bagel.SKU, Is.EqualTo("BGLO"));
        }
    }
}
