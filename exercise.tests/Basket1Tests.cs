using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using exercise.main;
using NUnit.Framework;

namespace exercise.tests
{
    public class Basket1Tests
    {
        [Test]
        public void AddToBasket_ProductInStockAndNotFull_ShouldReturnTrue() {
            // Arrange
            IInventory inventory = new Inventory1();
            Basket1 basket = new Basket1(inventory, 3);
            string sku = "BGLO";  // Adjust SKU based on your inventory data

            // Act
            bool result = basket.AddToBasketIfExists(sku, null, out IProduct product);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNotNull(product);
        }
        [Test]
        public void AddToBasket_InvalidProductSKU_ShouldThrowException() {
            // Arrange
            IInventory inventory = new Inventory1();
            Basket1 basket = new Basket1(inventory, 3);
            string invalidSku = "INVALID";  // Choose a SKU that does not exist in your inventory

            // Act & Assert
            Assert.Throws<Exception>(() => basket.AddToBasketIfExists(invalidSku, null, out IProduct product));
        }
        [Test]
        public void AddToBasket_ProductInStockAndNotFullWithFillings_ShouldReturnTrue() {
            // Arrange
            IInventory inventory = new Inventory1();
            Basket1 basket = new Basket1(inventory, 3);
            string sku = "BGLO";  // Adjust SKU based on your inventory data
            List<string> fillings = new List<string> { "FILB", "FILC" };  // Adjust fillings based on your inventory data

            // Act
            bool result = basket.AddToBasketIfExists(sku, fillings, out IProduct product);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNotNull(product);

            // Add additional assertions for fillings if needed
            // For example, if your product is fillable, you can check that the fillings were added
            if (product is IFillable fillableProduct)
            {
                Assert.AreEqual(2, fillableProduct._fillings.Count);
                // Add more specific assertions about fillings if needed
            }
        }
        [Test]
        public void AddToBasket_ProductInStockAndNotFullWithInvalidFillings_ShouldThrowException() {
            // Arrange
            IInventory inventory = new Inventory1();
            Basket1 basket = new Basket1(inventory, 3);
            string sku = "BGLO";  // Adjust SKU based on your inventory data
            List<string> fillings = new List<string> { "FILB", "INVALIDFILLING" };  // Adjust fillings based on your inventory data, include an invalid one

            // Act & Assert
            Assert.Throws<Exception>(() => basket.AddToBasketIfExists(sku, fillings, out _));
        }
        [Test]
        public void RemoveFromBasket_ProductExists_ShouldReturnTrue()
        {
            // Arrange
            IInventory inventory = new Inventory1();
            Basket1 basket = new Basket1(inventory, 3);
            string sku = "BGLO";  // Adjust SKU based on your inventory data
            basket.AddToBasketIfExists(sku, null, out _);

            // Act
            bool result = basket.RemoveFromBasket(sku);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveFromBasket_ProductDoesNotExist_ShouldThrowException()
        {
            // Arrange
            IInventory inventory = new Inventory1();
            Basket1 basket = new Basket1(inventory, 3);
            string sku = "NONEXISTENT";  // Use a SKU that doesn't exist in the basket

            // Act & Assert
            Assert.Throws<Exception>(() => basket.RemoveFromBasket(sku));
        }

        [Test]
        public void TotalCostOfBasket_EmptyBasket_ShouldReturnZero()
        {
            // Arrange
            IInventory inventory = new Inventory1();
            Basket1 basket = new Basket1(inventory, 3);

            // Act
            decimal totalCost = basket.TotalCostOfBasket();

            // Assert
            Assert.AreEqual(0, totalCost);
        }

        [Test]
        public void TotalCostOfBasket_WithProductsAndFillings_ShouldReturnCorrectTotalCost()
        {
            // Arrange
            IInventory inventory = new Inventory1();
            Basket1 basket = new Basket1(inventory, 3);
            string sku = "BGLO";  // Adjust SKU based on your inventory data
            List<string> fillings = new List<string> { "FILB", "FILC" };  // Adjust fillings based on your inventory data
            basket.AddToBasketIfExists(sku, fillings, out _);

            // Act
            decimal totalCost = basket.TotalCostOfBasket();

            // Assert
            decimal expectedCost = 0.49m + 0.12m + 0.12m;  // Bagel price + Bacon filling price + Cheese filling price
            Assert.AreEqual(expectedCost, totalCost);
        }
        
    }
}