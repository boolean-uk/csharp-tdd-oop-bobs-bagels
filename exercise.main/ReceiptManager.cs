using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static exercise.main.BasketManager;
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
                public int Quantity { get; set; }
                public double Price { get; set; }

                public Entry(string name, int quantity, double price)
                {
                    Name = name;
                    Quantity = quantity;
                    Price = price;
                }
            }

            public void AddItemToEntry(string name, double price)
            {
                if (!Entries.Any(entry => entry.Name == name))
                {
                    Entries.Add(new Receipt.Entry(name, 0, 0));
                }
                Entries.FirstOrDefault(entry => entry.Name == name).Quantity++;
                Entries.FirstOrDefault(entry => entry.Name == name).Price += price;
            }
        }

        public Receipt GetReceipt(Order order)
        {
            Receipt receipt = new Receipt();

            // Add bagels
            foreach (Bagel bagel in order.Bagels)
            {
                receipt.AddItemToEntry(bagel.Variant.Name, bagel.Variant.Price);

                // Add bagel fillings
                foreach (Inventory.BagelFilling filling in bagel.Fillings)
                {
                    receipt.AddItemToEntry(filling.Name, filling.Price);
                }
            }

            // Count Coffees
            foreach (Coffee coffee in order.Coffees)
            {
                receipt.AddItemToEntry(coffee.Variant.Name, coffee.Variant.Price);
            }

            receipt.TotalCost = receipt.Entries.Sum(e => e.Price);
            return receipt;
        }

        public void DisplayReceipt(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
