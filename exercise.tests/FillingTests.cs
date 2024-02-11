using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    [TestFixture]
     public class FillingTests
    {
        [Test]
        public void FillingProperties_AreSetCorrectly()
        {
            // Arrange
            Product filling = new Filling("FILB");
            //Assert
            Assert.That(filling.Variant, Is.EqualTo("Bacon"));
            Assert.That(filling.Price, Is.EqualTo(0.12));
            Assert.That(filling.SKU, Is.EqualTo("FILB"));
        }
    }
}
