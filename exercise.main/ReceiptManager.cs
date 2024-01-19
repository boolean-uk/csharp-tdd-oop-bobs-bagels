using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static exercise.main.BasketManager;
using static exercise.main.OrderCostManager;
using static exercise.main.ReceiptManager;

namespace exercise.main
{
    public class ReceiptManager
    {
        //The order determines priority.
        private static readonly List<(string Name, int Quantity, double Price)> RunningDiscounts = new List<(string, int, double)>
        {
            ("Onion", 6, 2.49),
            ("Plain", 12, 3.99),
            ("Everything", 6, 2.49),
            ("Coffee & Bagel", 1, 1.25)
        };

        public class Receipt
        {
            public List<Entry> Entries { get; set; }
            public DateTime DateOfPurchase { get; set; }
            public double TotalCost { get; set; }

            public Receipt()
            {
                Entries = new List<Entry>();
                DateOfPurchase = DateTime.Now;
            }

            public class Entry
            {
                public string Name { get; private set; }
                public string Type { get; private set; }
                public int Quantity { get; set; }
                public double Price { get; set; }

                public Entry(string name, string type, int quantity, double price)
                {
                    Name = name;
                    Type = type;
                    Quantity = quantity;
                    Price = price;
                }
            }

            public void AddItemToEntry(string name, string type, int quantity, double priceOfOne)
            {
                Entry? entry = Entries.FirstOrDefault(entry => entry.Name == name);
                if (entry == null)
                {
                    Entries.Add(new Entry(name, type, 0, 0));
                }
                else
                {
                    entry.Quantity += quantity;
                    entry.Price = entry.Quantity * priceOfOne;
                }
            }

            public void AddDiscountToEntry(string name, string type, int quantity, double savingsOnOne)
            {
                Entry? entry = Entries.FirstOrDefault(entry => entry.Name == name);
                if (entry == null)
                {
                    Entries.Add(new Entry(name, type, 0, 0));
                }
                else
                {
                    entry.Quantity += quantity;
                    entry.Price = entry.Quantity * savingsOnOne;
                }
            }

            public void AddDiscounts(List<(string Name, int Quantity, double Price)> discounts)
            {
                AddBulkDiscount(discounts);

                var coffeeBagelDiscount = discounts.FirstOrDefault(d => d.Name == "Coffee & Bagel");
                if (coffeeBagelDiscount != default((string, int, double)))
                    AddCoffeeAndBagelDiscount(coffeeBagelDiscount);
            }

            private void AddBulkDiscount(List<(string Name, int Quantity, double Price)> discounts)
            {
                foreach (var discount in discounts)
                {
                    Entry? entry = Entries.FirstOrDefault(entry => entry.Name == discount.Name);

                    if (entry != null)
                    {
                        int howManyTimesItApplies = entry.Quantity / discount.Quantity;

                        if (howManyTimesItApplies > 0)
                        {
                            double SavingsForEachApplicationOfDiscounts = discount.Price - (entry.Price * howManyTimesItApplies);
                            Entries.Add(new Entry(discount.Name, "Discount", howManyTimesItApplies, SavingsForEachApplicationOfDiscounts));
                        }
                    }
                }
            }

            private void AddCoffeeAndBagelDiscount((string Name, int Quantity, double Price) discount)
            {
                if ((discount.Name == null && discount.Quantity == 0 && discount.Price == 0.0))
                {
                    List<Entry> coffeeEntries = Entries.Where(entry => entry.Type == "Coffee").ToList();

                    Entry? entry = coffeeEntries.FirstOrDefault(entry => entry.Name == discount.Name);
                    if (entry != null)
                    {
                        int howManyTimesDoesItApply = entry.Quantity / discount.Quantity;

                        if (howManyTimesDoesItApply > 0)
                        {
                            double discountPrice = howManyTimesDoesItApply * discount.Price;
                            Entries.Add(new Entry(discount.Name, "Discount", howManyTimesDoesItApply, discountPrice));
                        }
                    }
                }
            }
        }

        public Receipt CreateReceipt(Order order)
        {
            Receipt receipt = new Receipt();

            // Add bagels
            foreach (Bagel bagel in order.Bagels)
            {
                receipt.AddItemToEntry(bagel.Variant.Name, "Bagel", 1, bagel.Variant.Price);

                // Add bagel fillings
                foreach (Inventory.BagelFilling filling in bagel.Fillings)
                {
                    receipt.AddItemToEntry(filling.Name, "Filling", 1, filling.Price);
                }
            }

            // Count Coffees
            foreach (Coffee coffee in order.Coffees)
            {
                receipt.AddItemToEntry(coffee.Variant.Name, "Coffee", 1, coffee.Variant.Price);
            }

            receipt.AddDiscounts(RunningDiscounts);

            receipt.TotalCost = receipt.Entries.Sum(e => e.Price);
            return receipt;
        }

        public void DisplayReceipt(Order order)
        {
            Receipt receipt = CreateReceipt(order);

            StringBuilder receiptText = new StringBuilder();
            receiptText.AppendLine("~~~ Bob's Bagels ~~~".PadLeft(23));
            receiptText.AppendLine("");
            receiptText.AppendLine(receipt.DateOfPurchase.ToString("yyyy-MM-dd HH:mm:ss").PadLeft(23));
            receiptText.AppendLine("");
            receiptText.AppendLine("----------------------------");
            receiptText.AppendLine("");

            double totalSavings = 0;

            foreach (var entry in receipt.Entries.Where(e => e.Type != "Discount"))
            {
                string entryLine = $"{entry.Name} {entry.Type}";
                receiptText.Append(entryLine.PadRight(19));

                entryLine = $"{entry.Quantity}  £{entry.Price.ToString("0.00")}";
                receiptText.AppendLine(entryLine.PadRight(19));

                // Check and add corresponding discount entry
                var discountEntry = receipt.Entries.FirstOrDefault(e => e.Type == "Discount" && e.Name == entry.Name);
                if (discountEntry != null)
                {
                    totalSavings += discountEntry.Price;
                    string savingsLine = $"(-£{(-discountEntry.Price).ToString("0.00")})";
                    receiptText.AppendLine(savingsLine.PadLeft(28));
                }
            }

            receiptText.AppendLine("");
            receiptText.AppendLine("----------------------------");
            receiptText.AppendLine($"Total                 £{receipt.TotalCost.ToString("0.00")}".PadRight(30));

            // Display total savings if any
            if (totalSavings != 0)
            {
                receiptText.AppendLine("");
                receiptText.AppendLine($" You saved a total of £{(-totalSavings).ToString("0.00")}".PadRight(30));
                receiptText.AppendLine("       on this shop".PadRight(30));
            }

            receiptText.AppendLine();
            receiptText.AppendLine("        Thank you".PadLeft(18));
            receiptText.AppendLine("      for your order!".PadLeft(18));

            Console.WriteLine(receiptText.ToString());
        }

    }
}