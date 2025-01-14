using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public List<IProduct> items;

        public int capacity;
        public Basket()
        {
            items = new List<IProduct>();
            capacity = 5;
        }

        public string Add(IProduct item)
        {
            Inventory inventory = new Inventory();
            if (!inventory.ValidateItem(item))
            {
                return "invalid item";
            }

            if (this.capacity > items.Count)
            {
                items.Add(item);
                return $"{item.Sku} added to basket.";
            }
            return "Basket is full, item not added";
        }

        public IProduct Remove(string sku)
        {
            IProduct item = items.FirstOrDefault(i => i.Sku == sku);
            if (item != null)
            {
                items.Remove(item);
            }
            return item;
        }


        public int ChangeCap(int cap)
        {
            this.capacity = cap;
            return this.capacity;

        }

        public double Total()
        {
            double total = 0;
            foreach (IProduct item in items)
            {
                if (item is Bagel bagel && bagel.Filling != null)
                {
                    total += bagel.Filling.Price;
                }

                total += item.Price;
            }
            this.ApplyDiscount();
            return total;
        }
        public void ApplyDiscount()
        {
            var bagelCount = items
                .Where(item => item.Type == "Bagel")
                .ToList().Count;

            double discountedPrice12b = 0.3325;
            double discountedPrice6b = 0.415;

            int discounted12Count = 0;
            int discounted6Count = 0;

            foreach (IProduct item in this.items)
            {
                if (item is Bagel bagel)
                {
                    // Apply discount for 12 bagels if there are enough
                    if (discounted12Count < (bagelCount / 12) * 12)
                    {
                        bagel.Price = discountedPrice12b;
                        discounted12Count++;
                    }
                    // Apply discount for 6 bagels if there are enough
                    else if (discounted6Count < (bagelCount % 12) / 6 * 6)
                    {
                        bagel.Price = discountedPrice6b;
                        discounted6Count++;
                    }
                }
            }
        }

        public string GetReceipt()
        {
            string header = "\t~~~ Bob's Bagels ~~~ ";
            string separator = "\n---------------------------\n";
            string footer = "\tThank you for ordering \n\t   at Bob's Bagels!";
            StringBuilder sb = new StringBuilder();
            DateTime dt = DateTime.Now;

            Dictionary<string, double> itemCost = new Dictionary<string, double>();
            Dictionary<string, int> itemQuantity = new Dictionary<string, int>();

            sb
                .Append(header)
                .AppendLine(separator)
                .AppendLine(dt.ToString())
                .AppendLine(separator);

            foreach (IProduct item in this.items)
            {
                string key = $"{item.Type}: {item.Variant}";

                itemCost[key] = itemCost.GetValueOrDefault(key, 0.0) + item.Price;
                itemQuantity[key] = itemQuantity.GetValueOrDefault(key, 0) + 1;
            }

            double grandTotal = 0.0;
            foreach (var entry in itemCost)
            {
                string itemName = entry.Key;
                int quantity = itemQuantity[itemName];
                double totalCost = entry.Value;
                sb.AppendLine(string.Format("{0,-20} {1,-2} £{2:F2}", itemName, quantity, totalCost));
                grandTotal += totalCost;
            }

            sb
                .AppendLine(separator)
                .AppendLine(string.Format("Total: {0,22} £{1:F2}", "", grandTotal))
                .AppendLine(footer);

            return sb.ToString();
        }

    }
}
