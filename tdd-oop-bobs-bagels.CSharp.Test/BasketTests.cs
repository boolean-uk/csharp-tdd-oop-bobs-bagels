using csharp_tdd_oop_bobs_bagels.source;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Test
{
    public class BasketTests
    {
        [Test]
        public void AddProductToBasketTest()
        {
            Basket basket = new Basket();
            basket.SeedData();
            Product product = new Product() { Sku = "BGLO", Price = 0.49M, Name = "Bagel", Variant = "Onion" };
            User user = new User("Stavros", "Customer");

            bool result = basket.AddProduct(user, product);
            Assert.IsTrue(result);
            Assert.AreEqual(user.Products.Count, 1);
        }

        [Test]
        public void ChecksIfBasketOverfills()
        {
            Basket basket = new Basket();
            basket.SeedData();
            Product product1 = new Product() { Sku = "BGLO", Price = 0.49M, Name = "Bagel", Variant = "Onion" };
            Product product2 = new Product() { Sku = "BGLP", Price = 0.39M, Name = "Bagel", Variant = "Plain" };
            Product product3 = new Product() { Sku = "BGLE", Price = 0.49M, Name = "Bagel", Variant = "Everything" };
            Product product4 = new Product() { Sku = "BGLS", Price = 0.49M, Name = "Bagel", Variant = "Sesame" };
            Product product5 = new Product() { Sku = "COFB", Price = 0.99M, Name = "Coffee", Variant = "Black" };
            Product product6 = new Product() { Sku = "COFW", Price = 1.19M, Name = "Coffee", Variant = "White" };
            User user = new User("Stavros", "Customer");

            basket.AddProduct(user, product1);
            basket.AddProduct(user, product2);
            basket.AddProduct(user, product3);
            basket.AddProduct(user, product4);
            basket.AddProduct(user, product5);
            bool result = basket.AddProduct(user, product6);
            int count = user.Products.Count;

            Assert.IsFalse(result);
            Assert.AreEqual(user.Products.Count, count);

        }
        [Test]
        public void RemoveProductFromBasketTest()
        {
            Basket basket = new Basket();
            basket.SeedData();
            Product product = new Product() { Sku = "BGLO", Price = 0.49M, Name = "Bagel", Variant = "Onion" };
            User user = new User("Stavros", "Customer");
            basket.AddProduct(user, product);
            int count = user.Products.Count;

            bool result = basket.RemoveProduct(user, product);
            Assert.IsTrue(result);
            Assert.AreEqual(user.Products.Count, count - 1);
        }

        [Test]
        public void ChangeCapacityTest()
        {
            Basket basket = new Basket();
            basket.SeedData();
            User manager = new User("Nigel", "Manager");
            User customer = new User("Stavros", "Customer");
            Product product1 = new Product() { Sku = "BGLO", Price = 0.49M, Name = "Bagel", Variant = "Onion" };
            Product product2 = new Product() { Sku = "BGLP", Price = 0.39M, Name = "Bagel", Variant = "Plain" };

            basket.ChangeBasketsCapacity(manager, 1);
            
            basket.AddProduct(customer, product1);
            bool result = basket.AddProduct(customer, product2);
            Assert.IsFalse(result);
            Assert.AreEqual(customer.Products.Count, 1);
        }

        [Test]
        public void RemoveItemThatDoesntExistsTest()
        {
            Basket basket = new Basket();
            basket.SeedData();
            User user = new User("Stavros", "Customer");
            Product productThatDoesntExist = new Product() { Sku = "COFE", Price = 1.29M, Name = "Coffee", Variant = "Espresso" };
            Product product1 = new Product() { Sku = "BGLO", Price = 0.49M, Name = "Bagel", Variant = "Onion" };
            Product product2 = new Product() { Sku = "BGLP", Price = 0.39M, Name = "Bagel", Variant = "Plain" };

            basket.AddProduct(user, product1);
            basket.AddProduct(user, product2);

            int count = user.Products.Count;

            bool result = basket.RemoveProduct(user, productThatDoesntExist);
            Assert.IsFalse(result);
            Assert.AreEqual(count, user.Products.Count);
        }

        [Test]
        public void CalculateTotalPriceTest()
        {
            Basket basket = new Basket();
            basket.SeedData();
            User user = new User("Stavros", "Customer");
            Product product1 = new Product() { Sku = "BGLO", Price = 0.49M, Name = "Bagel", Variant = "Onion" };
            Product product2 = new Product() { Sku = "BGLP", Price = 0.39M, Name = "Bagel", Variant = "Plain" };

            basket.AddProduct(user, product1);
            basket.AddProduct(user, product2);

            Assert.AreEqual(basket.CalculateTotalCost(user), 0.88M);
        }

        [Test]
        public void ProductCostTest()
        {
            Basket basket = new Basket();
            basket.SeedData();
            User user = new User("Stavros", "Customer");
            string sku = "COFB";

            decimal price = basket.ProductCost(user, sku);

            Assert.AreEqual(price, 0.99M);
        }

        [Test]
        public void FillingCostTest()
        {
            Basket basket = new Basket();
            basket.SeedData();
            User user = new User("Stavros", "Customer");
            string filling = "Bacon";

            decimal price = basket.FillingCost(user, filling);

            Assert.AreEqual(price, 0.12M);
        }

        [Test]
        public void AddFillingTest()
        {
            Basket basket = new Basket();
            basket.SeedData();
            User user = new User("Stavros", "Customer");
            Product product1 = new Product() { Sku = "BGLO", Price = 0.49M, Name = "Bagel", Variant = "Onion" };
            Product product2 = new Product() { Sku = "BGLP", Price = 0.39M, Name = "Bagel", Variant = "Plain" };
            string sku = "BGLO";
            string filling = "Bacon";

            basket.AddProduct(user, product1);
            basket.AddProduct(user, product2);
            basket.AddFilling(user, sku, filling);

            Assert.AreEqual(basket.CalculateTotalCost(user), 1.00M);
        }
    }
}
