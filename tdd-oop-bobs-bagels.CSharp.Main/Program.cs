using tdd_oop_bobs_bagels.CSharp.Main;

namespace tdd_oop_bobs_bagels.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            var discounts = new List<Discount>
            {
                new ComboDiscount(),
                new BulkDiscount()
            };

            Basket basket = new Basket(inventory, discounts);

            //basket.AddItem(new Bagel("BGLO", 0.49M, "Bagel", "Onion"));
            //basket.AddItem(new Coffee("COFB", 0.99M, "Black"));
            basket.AddItem(new Bagel("BGLS", 0.49M, "Bagel", "Sesame"), 12); // Adding 12 plain bagels

            Receipt receipt = basket.GenerateReceipt();
            PrintReceipt(receipt);
        }

        static void PrintReceipt(Receipt receipt)
        {
            Console.WriteLine(receipt.GeneratePrint());
        }
    }
}