using System;
using System.Collections.Generic;
using tdd_oop_bobs_bagels.CSharp.Main;

namespace tdd_oop_bobs_bagels.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize
            Inventory inventory = new Inventory();
            List<Discount> discounts = new List<Discount>
            {
                new BulkDiscount(),
                new ComboDiscount(inventory)
            };

            // Create a basket with the inventory and discounts
            Basket basket = new Basket(inventory, discounts);

            // Scenario 1: Add 12 plain bagels and 3 black coffees
            var plainBagel = new Bagel("BGLP", 0.39M, "Bagel", "Plain");
            var coffeeBlack = new Coffee("COFB", 0.99M, "Black");
            var baconFilling = new Filling("FILB", 0.12M, "Bacon");

            basket.AddItem(plainBagel, 12);
            basket.AddItem(coffeeBlack, 3);
            plainBagel.AddFilling(baconFilling);

            PrintReceipt(basket.GenerateReceipt());

            // Clear basket for next scenario
            basket.Clear();

            // Scenario 2: Add 6 plain bagels and 2 black coffees
            basket.AddItem(plainBagel, 6);
            basket.AddItem(coffeeBlack, 2);

            PrintReceipt(basket.GenerateReceipt());

            // Clear basket for next scenario
            basket.Clear();

            // Scenario 3: Add 7 plain bagels and 1 black coffee
            basket.AddItem(plainBagel, 7);
            basket.AddItem(coffeeBlack, 1);

            PrintReceipt(basket.GenerateReceipt());

            Console.ReadLine(); // Wait for input before closing
        }

        static void PrintReceipt(Receipt receipt)
        {
            Console.WriteLine("\n-----------------------------------");
            Console.WriteLine(receipt.GeneratePrint());
            Console.WriteLine("-----------------------------------\n");
        }
    }
}