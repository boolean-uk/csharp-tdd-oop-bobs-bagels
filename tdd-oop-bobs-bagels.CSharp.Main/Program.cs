using tdd_oop_bobs_bagels.CSharp.Main;

namespace tdd_oop_bobs_bagels.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize inventory and discounts
            Inventory inventory = new Inventory();
            var discounts = new List<Discount>
            {
                new ComboDiscount(),
                new BulkDiscount()
            };

            // Create a basket
            Basket basket = new Basket(inventory, discounts);

            // Add items to the basket
            basket.AddItem(new Bagel("BGLO", 0.49M, "Bagel", "Onion"));
            basket.AddItem(new Coffee("COFB", 0.99M, "Black"));
            //basket.AddItem(new Bagel("BGLP", 0.39M, "Bagel", "Plain"), 6); // Adding 6 plain bagels

            // Generate and print receipt
            Receipt receipt = basket.GenerateReceipt();
            PrintReceipt(receipt);
        }

        static void PrintReceipt(Receipt receipt)
        {
            Console.WriteLine(receipt.GeneratePrint());
        }
    }
}