using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop.main
{
    public class Inventory
    {
        private List<Item> availableItems;

        public Inventory()
        {
            availableItems = new List<Item>
        {
            new Bagel("BGLO", 0.49, "Onion", new BagelOffer(6, 2.49)),
            new Bagel("BGLP", 0.39, "Plain", new BagelOffer(12, 3.99)),
            new Bagel("BGLE", 0.49, "Everything", new BagelOffer(6, 2.49)),
            new Coffee("COF", 0.99, "", ""),
            new Coffee("COFB", 1.19, "", ""),
            new Filling("FILB", 0.12),
            // Add other items as needed
        };
        }

        public bool IsItemInInventory(string sku)
        {
            return availableItems.Exists(item => item.SKU == sku);
        }
        public Item GetItemBySKU(string sku)
        {
            return availableItems.FirstOrDefault(item => item.SKU == sku);
        }
    }


    public class OrderManager
    {
        public void DisplayOrderSummary(Dictionary<string, int> orderItems, Inventory inventory)
        {
            double totalCost = 0;

            Console.WriteLine();
            Console.WriteLine("~~~ Bob's Bagels ~~~");
            Console.WriteLine();
            Console.WriteLine(DateTime.Now);
            Console.WriteLine();
            Console.WriteLine("-------------------");

            foreach (var entry in orderItems)
            {
                string sku = entry.Key;
                int quantity = entry.Value;

                Item item = inventory.GetItemBySKU(sku);

                if (item != null)
                {
                    double itemCost = item.CalculateCost(quantity);
                    totalCost += itemCost;
                    double itemSaving = item.CalculateSavings(quantity);
                    double saving = itemSaving - itemCost;
                    Console.WriteLine($"{quantity}x {item.SKU} = {itemCost:C}");

                    if (saving > 0)
                    {
                        Console.WriteLine($"{' ',10} (-{saving:F2})");
                    }
                }
                else
                {
                    Console.WriteLine($"Item with SKU '{sku}' not found in the inventory.");
                }
            }

            Console.WriteLine($"------------------");
            Console.WriteLine($" Total  {' ',5} {totalCost:C}");
            Console.WriteLine("------------------");
            Console.WriteLine("Thank you for your order");
        }
    }

}
