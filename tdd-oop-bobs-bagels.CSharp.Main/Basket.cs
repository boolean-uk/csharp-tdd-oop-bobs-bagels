using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Basket
    {
        private List<object> items;
        private int capacity;
        private readonly Inventory _inventory;

        public Basket(Inventory inventory, int initialCapacity = 12)      // LOST SO MUCH TIME BECAUSE I COPIED THE PREVIOUS EXERCISE AND DID NOT CHANGED TO CAPACITY FOR EXTENSION TESTING
        {
            items = new List<object>();
            capacity = initialCapacity;
            _inventory = inventory;
        }
        public bool AddItem(object item)
        {
            if (!_inventory.DoesTheItemExist(((dynamic)item).SKU)) return false;
            if (items.Count < capacity)
            {
                items.Add(item);
                return true;
            }
            return false;
        }
        public bool RemoveItem(object item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                return true;
            }
            return false;
        }
        public bool IsBasketFull() => items.Count == capacity;
        public void SetCapacity(int newCapacity)
        {
            capacity = newCapacity;
        }
        public int GetCapacity() => capacity;
        public bool ContainsItem(object item) => items.Contains(item);
        public decimal GetTotalCost()
        {
            Console.WriteLine($"Starting calculation for GetTotalCost. Current items count: {items.Count}");

            decimal total = 0M;
            int bagelCount = 0;
            decimal bagelsTotalPrice = 0M;  // Dynamically calculate the total price of all bagels
            decimal fillingsTotal = 0M;
            bool hasCoffee = false;
            Console.WriteLine($"Items in the Basket: {string.Join(", ", items.Select(i => i.GetType().Name))}");

            foreach (var item in items)
            {
                if (item is Bagel bagel)
                {
                    bagelCount++;
                    fillingsTotal += bagel.TotalFillingsCost();
                    bagelsTotalPrice += bagel.GetPrice();
                    Console.WriteLine($"Bagel Price: {bagel.GetPrice()}, Accumulating Total: {bagelsTotalPrice}");

                }
                else if (item is Coffee coffee)
                {
                    hasCoffee = true;
                    total += coffee.GetPrice();
                }
            }
            Console.WriteLine($"Total before applying any discounts: {total}");
            // applying all the discounts 
            Discount discountCalculator = new Discount();
            decimal bulkDiscount = discountCalculator.GetDiscountForBulk(bagelCount, bagelsTotalPrice);
            total += (bagelsTotalPrice - bulkDiscount + fillingsTotal); // Apply the discount
            if (hasCoffee && bagelCount > 0)
            {
                string coffeeSku = items.OfType<Coffee>().FirstOrDefault()?.SKU;
                string bagelSku = items.OfType<Bagel>().FirstOrDefault()?.SKU;

                if (coffeeSku != null && bagelSku != null)
                    total -= discountCalculator.GetDiscountForCombo(coffeeSku, bagelSku);
            }
            return total;
        }
    }

    public class Bagel
    {
        public string SKU { get; }
        public decimal Price { get; }
        public string Name { get; }
        public string Variant { get; }
        private List<Filling> fillings;
        public Bagel(string sku, decimal price, string name, string variant)
        {
            SKU = sku;
            Price = price;
            Name = name;
            Variant = variant;
            fillings = new List<Filling>();
        }
        public decimal GetPrice() => Price;
        public bool AddFilling(Filling filling)
        {
            if (!fillings.Contains(filling))
            {
                fillings.Add(filling);
                return true;
            }
            return false;
        }
        public bool RemoveFilling(Filling filling) => fillings.Remove(filling);
        public decimal TotalCostWithFilling() => Price + fillings.Sum(f => f.GetPrice());
        public decimal TotalFillingsCost()
        {
            return fillings.Sum(f => f.GetPrice());
        }

    }

    public class Filling
    {
        public string SKU { get; }
        public decimal Price { get; }
        public string Name { get; }
        public Filling(string sku, decimal price, string name)
        {
            SKU = sku;
            Price = price;
            Name = name;
        }
        public decimal GetPrice() => Price;
    }

    public class Coffee
    {
        public string SKU { get; }
        public decimal Price { get; }
        public string Variant { get; }
        public Coffee(string sku, decimal price, string variant)
        {
            SKU = sku;
            Price = price;
            Variant = variant;
        }
        public decimal GetPrice() => Price;
    }

    public class Inventory
    {
        private List<object> items;
        public Inventory()
        {
            items = new List<object>();
            StockInventory();
        }
        private void StockInventory()
        {
            items.Add(new Bagel("BGLO", 0.49M, "Bagel", "Onion"));
            items.Add(new Bagel("BGLP", 0.39M, "Bagel", "Plain"));
            items.Add(new Bagel("BGLE", 0.49M, "Bagel", "Everything"));
            items.Add(new Bagel("BGLS", 0.49M, "Bagel", "Sesame"));
            items.Add(new Coffee("COFB", 0.99M, "Black"));
            items.Add(new Coffee("COFW", 1.19M, "White"));
            items.Add(new Coffee("COFC", 1.29M, "Capuccino"));
            items.Add(new Coffee("COFL", 1.29M, "Latte"));
            items.Add(new Filling("FILB", 0.12M, "Bacon"));
            items.Add(new Filling("FILE", 0.12M, "Egg"));
            items.Add(new Filling("FILC", 0.12M, "Cheese"));
            items.Add(new Filling("FILX", 0.12M, "Cream Cheese"));
            items.Add(new Filling("FILS", 0.12M, "Smoked Salmon"));
            items.Add(new Filling("FILH", 0.12M, "Ham"));
        }
        public bool DoesTheItemExist(string sku)
        {
            return items.Any(item =>
                   (item is Bagel && ((Bagel)item).SKU == sku) ||
                   (item is Filling && ((Filling)item).SKU == sku) ||
                   (item is Coffee && ((Coffee)item).SKU == sku));
        }
        public decimal GetPriceOfItem(string sku)
        {
            var item = items.FirstOrDefault(i =>
                       (i is Bagel && ((Bagel)i).SKU == sku) ||
                       (i is Filling && ((Filling)i).SKU == sku) ||
                       (i is Coffee && ((Coffee)i).SKU == sku));

            if (item is Bagel)
                return ((Bagel)item).GetPrice();
            if (item is Filling)
                return ((Filling)item).GetPrice();
            if (item is Coffee)
                return ((Coffee)item).GetPrice();
            return 0M;
        }
    }

    public class Discount
    {
        public decimal GetDiscountForBulk(int itemCount, decimal totalBagelPrice)
        {
            Console.WriteLine($"Calculating bulk discount for {itemCount} items.");

            if (itemCount >= 12)
            {
                return totalBagelPrice - 3.99M;
            }
            else if (itemCount >= 6)
            {
                return totalBagelPrice - 2.49M;
            }
            else
            {
                return 0M;
            }
        }

        public decimal GetDiscountForCombo(string coffeeSku, string bagelSku)
        {
            Console.WriteLine($"Calculating combo discount for coffee SKU: {coffeeSku} and bagel SKU: {bagelSku}");

            Inventory inventory = new Inventory();
            decimal bagelPrice = inventory.GetPriceOfItem(bagelSku);
            decimal coffeePrice = inventory.GetPriceOfItem(coffeeSku);

            decimal comboDiscountAmount = (bagelPrice + coffeePrice) - 1.25M;

            Console.WriteLine($"Applying coffee with Bagel discount. Discount value: {comboDiscountAmount}");
            return comboDiscountAmount;
        }
    }
}