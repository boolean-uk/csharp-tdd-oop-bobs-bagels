using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public List<Item> myBasket = new List<Item>();

        public int BasketSize { get; set; } = 5; // default basket capacity

        public List<InventoryItem> inventory = new List<InventoryItem>
        {
            new InventoryItem { Product = "BGLO", Price = 0.49, Name = "Bagel", Variant = "Onion" },
            new InventoryItem { Product = "BGLP", Price = 0.39, Name = "Bagel", Variant = "Plain" },
            new InventoryItem { Product = "BGLE", Price = 0.49, Name = "Bagel", Variant = "Everything" },
            new InventoryItem { Product = "BGLS", Price = 0.49, Name = "Bagel", Variant = "Sesame" },
            new InventoryItem { Product = "COFB", Price = 0.99, Name = "Coffee", Variant = "Black" },
            new InventoryItem { Product = "COFW", Price = 1.19, Name = "Coffee", Variant = "White" },
            new InventoryItem { Product = "COFC", Price = 1.29, Name = "Coffee", Variant = "Capuccino" },
            new InventoryItem { Product = "COFL", Price = 1.29, Name = "Coffee", Variant = "Latte" },
            new InventoryItem { Product = "FILB", Price = 0.12, Name = "Filling", Variant = "Bacon" },
            new InventoryItem { Product = "FILE", Price = 0.12, Name = "Filling", Variant = "Egg" },
            new InventoryItem { Product = "FILC", Price = 0.12, Name = "Filling", Variant = "Cheese" },
            new InventoryItem { Product = "FILX", Price = 0.12, Name = "Filling", Variant = "Cream Cheese" },
            new InventoryItem { Product = "FILS", Price = 0.12, Name = "Filling", Variant = "Smoked Salmon" },
            new InventoryItem { Product = "FILH", Price = 0.12, Name = "Filling", Variant = "Ham" }
        };

        public bool AddItem(Item item)
        {
            myBasket.Add(item);
            return true;
        }

        public bool RemoveItem(Item item)
        {
            myBasket.Remove(item);
            return true;
        }

        public bool FullBasket(List<Item> items)
        {
            bool isFull = false;
            if (items.Count < BasketSize)
            {
                Console.WriteLine("Your basket is not full!");
                isFull = false;
            }
            else if (items.Count >= BasketSize)
            {
                Console.WriteLine("Your basket is full!");
                isFull = true;
            }
            return isFull;
        }
        public int BasketCapacity(int newCap)
        {
            return BasketSize = newCap;
        }

        public bool SchrodingersItem(Item item)
        {
            bool hypotheticalItem = true;
            if (!myBasket.Contains(item))
            {
                hypotheticalItem = false;
                Console.WriteLine($"{item} does not exist and can NOT be removed from basket");
            }
            else
            {
                hypotheticalItem = true;
                Console.WriteLine($"{item} exists and can be removed from basket");
            }
            return hypotheticalItem;
        }

        public double Total(List<Item> items)
        {
            double sum = 0;
            foreach (var item in items)
            {
                sum = sum + item.Price;
            }
            return sum;
        }

        public double Price(string item)
        {
            double sum = 0;
            var prices = new Dictionary<string, double>
            {
                { "Onion", 0.49 },
                { "Plain", 0.39 },
                { "Everything", 0.49 },
                { "Sesame", 0.49 },
                { "Black", 0.99 },
                { "White", 1.19 },
                { "Cappuccino", 1.29 },
                { "Latte", 1.29 },
                { "Bacon", 0.12 },
                { "Egg", 0.12 },
                { "Cheese", 0.12 },
                { "Cream Cheese", 0.12 },
                { "Ham", 0.12 }
            };
            
            if (prices.ContainsKey(item))
            {
                sum = prices[item];
            }
            return sum;
        }
        public Item ChangeFilling(Item filling, string product, double price, string name, string variant)
        {
            filling.Product = product;
            filling.Price = price;
            filling.Name = name;
            filling.Variant = variant;

            return filling;
        }

        public Boolean InInventory(Item item, List<InventoryItem> inventory)
        {
            bool isStocked = false;
            if (inventory.Any(x => x.Product == item.Product) && inventory.Any(x => x.Variant == item.Variant))
            {
                isStocked = true;
            }
            else { isStocked = false; }

            return isStocked;
        }

        // Extension 2
        public double Receipt(List<Item> myBasket)
        {
            Console.WriteLine($"          ~~ Bob's Bagels ~~");
            Console.WriteLine();
            Console.WriteLine($"          {DateTime.Now.ToString()}");
            Console.WriteLine();
            Console.WriteLine("{0,10}      {1,10}      {2,10}",
                 "Product", "Qty", "Price");
            foreach (Item item in myBasket)
            {
                Console.WriteLine("{0,10}      {1,10}      {2,10}",
                    item.Variant, 1, 
                    $"€{item.Price}"
                    );
            }
            Console.WriteLine(new string('-', 40));
            double receiptSum = 0;
            myBasket.ForEach(b => {  receiptSum += b.Price; 
            });
            Console.WriteLine($"Total:                               €{receiptSum}");

            return receiptSum;
        }
    }
}
