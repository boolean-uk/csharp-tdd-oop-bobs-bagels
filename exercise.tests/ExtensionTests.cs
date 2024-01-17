using exercise.main.Products;
using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Discounts;

namespace exercise.tests
{
    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        [TestCase(new string[] { "COFB", "BGLO" }, true)] // Coffee - Black
        [TestCase(new string[] { "COFL" }, true)] // Coffee - Latte
        [TestCase(new string[] { "BGLO", "FILE"}, true)] // Bagel with onion, egg filling
        [TestCase(new string[] { "BGLO", "FILE", "FILS" }, true)] // Bagel with onion, egg and salmon filling
        [TestCase(new string[] { "ABCD" }, false)] // Should be false
        [TestCase(new string[] { "ABCD", "EFGH" }, false)] // Should be false
        public void DiscountBulkBagelsTest(string[] SKU, bool shouldWork)
        {
            // Arrange
            DiscountManager discounter = new DiscountManager();
            Basket basket1 = new Basket(); // 6 bagels
            Basket basket2 = new Basket(); // 12 bagels
            Basket basket3 = new Basket(); // 7 bagels
            Product prod1 = ProductFactory.GenerateProduct(new string[] { "BGLO", "FILE" });
            Product prod2 = ProductFactory.GenerateProduct(new string[] { "BGLP", "FILX" });

            // 6 bagel discount. 6 for 2.49.
            basket1.AddItemToBasket(prod1);
            basket1.AddItemToBasket(prod1);
            basket1.AddItemToBasket(prod1);
            basket1.AddItemToBasket(prod1);
            basket1.AddItemToBasket(prod2);
            basket1.AddItemToBasket(prod2);

            // 12 bagel discount. 12 for 3.99
            basket2.AddItemToBasket(prod1);
            basket2.AddItemToBasket(prod1);
            basket2.AddItemToBasket(prod1);
            basket2.AddItemToBasket(prod1);
            basket2.AddItemToBasket(prod2);
            basket2.AddItemToBasket(prod2); 
            basket2.AddItemToBasket(prod1);
            basket2.AddItemToBasket(prod1);
            basket2.AddItemToBasket(prod1);
            basket2.AddItemToBasket(prod1);
            basket2.AddItemToBasket(prod2);
            basket2.AddItemToBasket(prod2);

            // 6 bagel discount. 6 for 2.49.
            basket3.AddItemToBasket(prod1);
            basket3.AddItemToBasket(prod1);
            basket3.AddItemToBasket(prod1);
            basket3.AddItemToBasket(prod1);
            basket3.AddItemToBasket(prod2);
            basket3.AddItemToBasket(prod2);
            basket3.AddItemToBasket(prod2);

            // Act
            List<Discount> discounts1 = new List<Discount>();
            float res1 = discounter.ApplyDiscounts(basket1, out discounts1);
            List<Discount> discounts2 = new List<Discount>();
            float res2 = discounter.ApplyDiscounts(basket2, out discounts2);
            List<Discount> discounts3 = new List<Discount>();
            float res3 = discounter.ApplyDiscounts(basket3, out discounts3);

            // Assert
            Assert.That(res1, Is.EqualTo(3.21f));
            
            Assert.That(res2, Is.EqualTo(5.43f));

            Assert.That(res3, Is.EqualTo(3.72f));
        }
    }
}

