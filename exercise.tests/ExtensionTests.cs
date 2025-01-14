using System;
using System.Collections.Generic;
using System.Text;
using exercise.main.Core;
using exercise.main.Extension;
using NUnit.Framework;

namespace exercise.tests
{
    public class ExtensionTests
    {
        private Basket basket;
        private List<Inventory> basketList;

        [SetUp]
        public void SetUp()
        {
            basketList = new List<Inventory>();
            basket = new Basket(basketList);
        }

        //Extension 1: Discount
        [Test]
        public void CalculateTotalCostWithDiscounts_ShouldApplyDiscountsCorrectly()
        {
            // Arrange
            basket.GetBasketList().Add(new Inventory("BGLO", 0.49, "Bagel", "Onion"));
            basket.GetBasketList().Add(new Inventory("BGLO", 0.49, "Bagel", "Onion"));
            basket.GetBasketList().Add(new Inventory("BGLO", 0.49, "Bagel", "Onion"));
            basket.GetBasketList().Add(new Inventory("BGLO", 0.49, "Bagel", "Onion"));
            basket.GetBasketList().Add(new Inventory("BGLO", 0.49, "Bagel", "Onion"));
            basket.GetBasketList().Add(new Inventory("BGLO", 0.49, "Bagel", "Onion"));

            // Act
            double totalCost = basket.CalculateTotalCostWithDiscounts();

            // Assert
            Assert.That(totalCost, Is.EqualTo(2.49));
        }

        //Extension 2: Receipt
        [Test]
        public void GenerateReceipt_ShouldReturnCorrectFormattedReceipt()
        {
            // Arrange
            var receipt = new Receipt();
            receipt.AddItem("Bagel Onion", 2, 0.98);
            receipt.AddItem("Bagel Plain", 1, 0.39);
            receipt.AddItem("Coffee Black", 1, 0.99);
            receipt.CalculateTotal();

            // Act
            string actualReceipt = receipt.GenerateReceipt();
            Console.WriteLine(actualReceipt);

            // Assert: Validate core receipt content
            Assert.Multiple(() =>
            {
                Assert.IsTrue(actualReceipt.Contains("Bagel Onion          2   £0.98"), "Bagel Onion line mismatch.");
                Assert.IsTrue(actualReceipt.Contains("Bagel Plain          1   £0.39"), "Bagel Plain line mismatch.");
                Assert.IsTrue(actualReceipt.Contains("Coffee Black         1   £0.99"), "Coffee Black line mismatch.");
                Assert.IsTrue(actualReceipt.Contains("Total                 £2.36"), "Total cost mismatch.");

                // Relax footer check
                string expectedFooterSnippet = "Thank you\n      for your order!";
                Assert.IsTrue(actualReceipt.Replace("\r\n", "\n").Contains(expectedFooterSnippet), "Footer mismatch.");
            });
        }

        //Extension 3: Discount Receipt
        [Test]
        public void GenerateReceiptWithDiscounts_ShouldIncludeSavings()
        {
            // Arrange
            for (int i = 0; i < 6; i++)
            {
                basket.GetBasketList().Add(new Inventory("BGLO", 0.49, "Bagel", "Onion"));
            }

            // Act
            var receipt = basket.GenerateReceiptWithDiscounts();
            string actualReceipt = receipt.GenerateReceipt();
            Console.WriteLine(actualReceipt);

            // Assert: Validate key receipt elements
            Assert.Multiple(() =>
            {
                Assert.IsTrue(actualReceipt.Contains("Bagel Onion          6   £2.49"), "Discounted Bagel line mismatch.");
                Assert.IsTrue(actualReceipt.Contains("                     (-£0.45)"), "Savings line mismatch.");
                Assert.IsTrue(actualReceipt.Contains("Total                 £2.49"), "Total cost mismatch.");

                // Relax footer check
                string expectedFooterSnippet = "Thank you\n      for your order!";
                Assert.IsTrue(actualReceipt.Replace("\r\n", "\n").Contains(expectedFooterSnippet), "Footer mismatch.");
            });
        }










    }
}
