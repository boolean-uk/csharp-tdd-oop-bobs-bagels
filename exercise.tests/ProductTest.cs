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
        public void addFilling1()
        {
            Product testFilling1 = new("FILB", 0.12d, Product.pType.Filling, "Bacon");
            
            Assert.IsTrue(product.AddFilling(testFilling1));
            Assert.IsTrue(product.Filling.Any(t => t.SKU == "FILB"));
        }[Test]
        public void addFilling2()
        {
            Product testFilling2 = new("COFB", 0.12d, Product.pType.Coffee, "Black");
            
            Assert.IsFalse(product.AddFilling(testFilling2));
        }
        [Test]
        public void removeFilling1()
        {
            Product testFilling1 = new("FILB", 0.12d, Product.pType.Filling, "Bacon");
            product.AddFilling(testFilling1);
            Assert.IsTrue(product.RemoveFilling(testFilling1));
        }
        [Test]
        public void removeFilling2()
        {
            
            Product testFilling2 = new("FILE", 0.12d, Product.pType.Filling, "Egg");
            Assert.IsFalse(product.RemoveFilling(testFilling2));
        }
    }
}
