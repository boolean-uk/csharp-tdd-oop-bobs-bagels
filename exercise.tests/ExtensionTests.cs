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
        public void DiscountBulkBagelsTest()
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

            // 6 bagel discount. 6 for 2.49. 7 bagels total
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
            Assert.That(discounts1[0].Name, Is.EqualTo("6 bagels"));
            Assert.That(discounts1[0].DiscountPrice, Is.EqualTo(2.49f));

            Assert.That(res2, Is.EqualTo(5.43f));
            Assert.That(discounts2[0].Name, Is.EqualTo("12 bagels"));
            Assert.That(discounts2[0].DiscountPrice, Is.EqualTo(3.99f));

            Assert.That(res3, Is.EqualTo(3.72f));
            Assert.That(discounts3[0].Name, Is.EqualTo("6 bagels"));
            Assert.That(discounts3[0].DiscountPrice, Is.EqualTo(2.49f));
        }

        [Test]
        public void DiscountBulkBagelAndCoffeeTest()
        {
            // Arrange
            DiscountManager discounter = new DiscountManager();
            Basket basket1 = new Basket(); // 6 bagels
            Basket basket2 = new Basket(); // 7 bagels 1 coffee
            Basket basket3 = new Basket(); // 1 bagel 1 coffee
            Product prod1 = ProductFactory.GenerateProduct(new string[] { "BGLO", "FILE" }); // The bagel
            Product prod2 = ProductFactory.GenerateProduct(new string[] { "COFB" }); // The coffee

            // 6 bagel discount. 6 for 2.49. 6 bagels 1 coffee total
            basket1.AddItemToBasket(prod1);
            basket1.AddItemToBasket(prod1);
            basket1.AddItemToBasket(prod1);
            basket1.AddItemToBasket(prod1);
            basket1.AddItemToBasket(prod1);
            basket1.AddItemToBasket(prod1);
            basket1.AddItemToBasket(prod2);


            // 6 bagel discount and coffee+bagel discount. 6 for 2.49. 7 bagels 1 coffee total
            basket2.AddItemToBasket(prod1);
            basket2.AddItemToBasket(prod1);
            basket2.AddItemToBasket(prod1);
            basket2.AddItemToBasket(prod1);
            basket2.AddItemToBasket(prod1);
            basket2.AddItemToBasket(prod1);
            basket2.AddItemToBasket(prod1);
            basket2.AddItemToBasket(prod2);

            basket3.AddItemToBasket(prod1);
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
            Assert.That(discounts1[0].Name, Is.EqualTo("6 bagels"));
            Assert.That(discounts1[0].DiscountPrice, Is.EqualTo(2.49f));

            Assert.That(res2, Is.EqualTo(5.43f));
            Assert.That(discounts2[0].Name, Is.EqualTo("6 bagels"));
            Assert.That(discounts2[0].DiscountPrice, Is.EqualTo(2.49f));
            Assert.That(discounts2[1].Name, Is.EqualTo("coffee and bagel"));
            Assert.That(discounts2[1].DiscountPrice, Is.EqualTo(1.25f));

            Assert.That(res3, Is.EqualTo(5.43f));
            Assert.That(discounts3[0].Name, Is.EqualTo("coffee and bagel"));
            Assert.That(discounts3[0].DiscountPrice, Is.EqualTo(1.25f));
        }


    [Test]
    public void DiscountDoubleBulkBagelsTest()
    {
        // Arrange
        DiscountManager discounter = new DiscountManager();
        Basket basket = new Basket(); // 12 bagels
        basket.SetBasketSize(30);
        Product prod1 = ProductFactory.GenerateProduct(new string[] { "BGLO", "FILE" });
        Product prod2 = ProductFactory.GenerateProduct(new string[] { "BGLP", "FILX" });

        // 12 bagel discount. 12 for 3.99
        basket.AddItemToBasket(prod1);
        basket.AddItemToBasket(prod1);
        basket.AddItemToBasket(prod1);
        basket.AddItemToBasket(prod1);
        basket.AddItemToBasket(prod1);
        basket.AddItemToBasket(prod1);
        basket.AddItemToBasket(prod1);
        basket.AddItemToBasket(prod1);
        basket.AddItemToBasket(prod1);
        basket.AddItemToBasket(prod1);
        basket.AddItemToBasket(prod1);
        basket.AddItemToBasket(prod1);

        // 12 bagel discount. 12 for 3.99
        basket.AddItemToBasket(prod2);
        basket.AddItemToBasket(prod2);
        basket.AddItemToBasket(prod2);
        basket.AddItemToBasket(prod2);
        basket.AddItemToBasket(prod2);
        basket.AddItemToBasket(prod2);
        basket.AddItemToBasket(prod2);
        basket.AddItemToBasket(prod2);
        basket.AddItemToBasket(prod2);
        basket.AddItemToBasket(prod2);
        basket.AddItemToBasket(prod2);
        basket.AddItemToBasket(prod2);

        // Act
        List<Discount> discounts = new List<Discount>();
        float res = discounter.ApplyDiscounts(basket, out discounts);


        // Assert
        Assert.That(res, Is.EqualTo(10.86f));
        Assert.That(discounts[0].Name, Is.EqualTo("12 bagels"));
        Assert.That(discounts[0].DiscountPrice, Is.EqualTo(3.99f));
        Assert.That(discounts[1].Name, Is.EqualTo("12 bagels"));
        Assert.That(discounts[1].DiscountPrice, Is.EqualTo(3.99f));

        }
    }
}

