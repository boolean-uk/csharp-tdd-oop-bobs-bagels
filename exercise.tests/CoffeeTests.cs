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
            Coffee coffee = new Coffee("COFB", 0.99m, "Coffee", "Black");

            // Assert
            Assert.AreEqual("COFB", coffee.SKU);
            Assert.AreEqual(0.99m, coffee.Price);
            Assert.AreEqual("Coffee", coffee.Name);
            Assert.AreEqual("Black", coffee.Type);
        }
    }
}
