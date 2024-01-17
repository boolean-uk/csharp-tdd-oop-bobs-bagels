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
            Filling filling = new Filling("FILB", 0.12m, "Bacon");

            // Assert
            Assert.AreEqual("FILB", filling.SKU);
            Assert.AreEqual(0.12m, filling.Price);
            Assert.AreEqual("Bacon", filling.Name);
        }
    }
}
