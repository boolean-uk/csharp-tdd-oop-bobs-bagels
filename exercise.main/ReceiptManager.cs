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
        public class Receipt
        {
            public List<Entry> Entries { get; set; }
            public DateTime DateOfPurchase { get; set; }
            public double TotalCost { get; set; }

            public Receipt()
            {
                Entries = new List<Entry>();
                DateTime DateOfPurchase = DateTime.Now;
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

            public void AddDiscounts(List<(string Name, int Quantity, double Price)> discounts)
            {
                // Apply bagel discounts
                foreach (var discount in discounts)
                {
                    List<Entry> bagelEntries = Entries.All(entry => entry.Type == "Bagel");

                    Entry? entry = bagelEntries.FirstOrDefault(entry => entry.Name == discount.Name);
                    if (entry != null) {   
                        int howManyTimesDoesItApply = entry.Quantity / discount.Quantity;

                        if (howManyTimesDoesItApply > 0)
                        {
                            double discountPrice = howManyTimesDoesItApply * discount.Price;
                            Entries.Add(new Entry(discount.Name, "Discount", howManyTimesDoesItApply, -discountPrice));
                        }
                    }
                }

                // Apply 'Coffee & Bagel' discounts
                var coffeeBagelDiscount = discounts.FirstOrDefault(d => d.Name == "Coffee & Bagel");
                if ((coffeeBagelDiscount.Name == null && coffeeBagelDiscount.Quantity == 0 && coffeeBagelDiscount.Price == 0.0))
                {
                    List<Entry> coffeeEntries = Entries.All(entry => entry.Type == "Coffee");

                    Entry? entry = coffeeEntries.FirstOrDefault(entry => entry.Name == coffeeBagelDiscount.Name);
                    if (entry != null)
                    {
                        int howManyTimesDoesItApply = entry.Quantity / coffeeBagelDiscount.Quantity;

                        if (howManyTimesDoesItApply > 0)
                        {
                            double discountPrice = howManyTimesDoesItApply * coffeeBagelDiscount.Price;
                            Entries.Add(new Entry(coffeeBagelDiscount.Name, "Discount", howManyTimesDoesItApply, discountPrice));
                        }
                    }
                }
            }
        }

        //The order determines priority.
        private static readonly List<(string Name, int Quantity, double Price)> RunningDiscounts = new List<(string, int, double)>
        {
            ("Onion", 6, 2.49),
            ("Plain", 12, 3.99),
            ("Everything", 6, 2.49),
            ("Coffee & Bagel", 1, 1.25)
        };

        public Receipt GetReceipt(Order order)
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
            throw new NotImplementedException();
        }
    }
}
