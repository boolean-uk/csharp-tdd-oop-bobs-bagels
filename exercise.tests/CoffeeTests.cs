using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    [TestFixture]
    public class CoffeeTests
    {
        [Test]
        public void CoffeeProperties_AreSetCorrectly()
        {
            // Arrange
            Product coffee = new Coffee("COFW");
            // Assert
            Assert.That(coffee.Variant, Is.EqualTo("White"));
            Assert.That(coffee.SKU, Is.EqualTo("COFW"));
            Assert.That(coffee.Price, Is.EqualTo(1.19));
        }
    }
}
