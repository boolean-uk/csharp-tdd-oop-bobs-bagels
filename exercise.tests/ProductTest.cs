using exercise.main.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    public class ProductTest
    {
        private Product product;
        [SetUp]
        public void SetUp()
        {
            product = new Product("BGLO", 0.49d, Product.pType.Bagel, "Onion");
        }
        [Test]
        public void addFilling()
        {
            Product testFilling1 = new Product("FILB", 0.12d, Product.pType.Filling, "Bacon");
            Product testFilling2 = new Product("COFB", 0.12d, Product.pType.Coffee, "Black");
            
            Assert.IsTrue(product.AddFilling(testFilling1));
            Assert.IsFalse(product.AddFilling(testFilling2));
            Assert.IsTrue(product.Filling.Any(t => t.SKU == "FILB"));
        }
        [Test]
        public void removeFilling()
        {
            Product testFilling1 = new Product("FILB", 0.12d, Product.pType.Filling, "Bacon");
            product.AddFilling(testFilling1);
            Product testFilling2 = new Product("FILE", 0.12d, Product.pType.Filling, "Egg");
            Assert.IsTrue(product.RemoveFilling(testFilling1));
            Assert.IsFalse(product.RemoveFilling(testFilling2));
        }
    }
}
