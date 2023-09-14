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

        public Basket(Inventory inventory, int initialCapacity = 5)
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
        public double GetTotalCost()
        {
            double total = 0;
            int bagelCount = 0;
            bool hasCoffee = false;

            foreach (var item in items)
            {
                if (item is Bagel bagel)
                {
                    bagelCount++;
                }
            }

            // Adjusting the price per bagel based on bulk discounts
            double adjustedBagelPrice = 0.49; // Default bagel price
            if (bagelCount >= 12)
            {
                adjustedBagelPrice = 3.99 / 12; // Discounted price per bagel
            }
            else if (bagelCount >= 6)
            {
                adjustedBagelPrice = 2.49 / 6; // Discounted price per bagel
            }

            // Calculate the total cost
            foreach (var item in items)
            {
                if (item is Bagel bagel)
                {
                    total += adjustedBagelPrice + bagel.TotalCostWithFilling() - bagel.Price; // Bagel price + Fillings
                }
                else if (item is Coffee coffee)
                {
                    hasCoffee = true;
                    total += coffee.GetPrice();
                }
            }
            // adjust for the discounts
            Discount discountCalculator = new Discount();
            total -= discountCalculator.GetDiscountForBulk(bagelCount);
            // Discount for coffee and bagel combo
            if (hasCoffee && bagelCount > 0)
            {
                total -= discountCalculator.GetDiscountForCombo(hasCoffee, bagelCount > 0);
            }

            return total;
        }
    }

    public class Bagel
    {
        public string SKU { get; }
        public double Price { get; }
        public string Name { get; }
        public string Variant { get; }
        private List<Filling> fillings;
        public Bagel(string sku, double price, string name, string variant)
        {
            SKU = sku;
            Price = price;
            Name = name;
            Variant = variant;
            fillings = new List<Filling>();
        }
        public double GetPrice() => Price;
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
        public double TotalCostWithFilling() => Price + fillings.Sum(f => f.GetPrice());

    }

    public class Filling
    {
        public string SKU { get; }
        public double Price { get; }
        public string Name { get; }
        public Filling(string sku, double price, string name)
        {
            SKU = sku;
            Price = price;
            Name = name;
        }
        public double GetPrice() => Price;
    }

    public class Coffee
    {
        public string SKU { get; }
        public double Price { get; }
        public string Variant { get; }
        public Coffee(string sku, double price, string variant)
        {
            SKU = sku;
            Price = price;
            Variant = variant;
        }
        public double GetPrice() => Price;
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
            items.Add(new Bagel("BGLO", 0.49, "Bagel", "Onion"));
            items.Add(new Bagel("BGLP", 0.39, "Bagel", "Plain"));
            items.Add(new Bagel("BGLE", 0.49, "Bagel", "Everything"));
            items.Add(new Bagel("BGLS", 0.49, "Bagel", "Sesame"));
            items.Add(new Coffee("COFB", 0.99, "Black"));
            items.Add(new Coffee("COFW", 1.19, "White"));
            items.Add(new Coffee("COFC", 1.29, "Capuccino"));
            items.Add(new Coffee("COFL", 1.29, "Latte"));
            items.Add(new Filling("FILB", 0.12, "Bacon"));
            items.Add(new Filling("FILE", 0.12, "Egg"));
            items.Add(new Filling("FILC", 0.12, "Cheese"));
            items.Add(new Filling("FILX", 0.12, "Cream Cheese"));
            items.Add(new Filling("FILS", 0.12, "Smoked Salmon"));
            items.Add(new Filling("FILH", 0.12, "Ham"));
        }
        public bool DoesTheItemExist(string sku)
        {
            return items.Any(item =>
                   (item is Bagel && ((Bagel)item).SKU == sku) ||
                   (item is Filling && ((Filling)item).SKU == sku) ||
                   (item is Coffee && ((Coffee)item).SKU == sku));
        }
        public double GetPriceOfItem(string sku)
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
            return 0;
        }
    }

    public class Discount
    {

        public double GetDiscountForBulk(int itemCount)
        {
            if (itemCount >= 12)
            {
                return 3.99 - (12 * 0.49); // 12 for 3.99 discount
            }
            else if (itemCount >= 6)
            {
                return 2.49 - (6 * 0.49); // 6 for 2.49 discount
            }
            return 0;
        }
        public double GetDiscountForCombo(bool hasCoffee, bool hasBagel)
        {
            if (hasCoffee && hasBagel)
            {
                return 0.49 + 0.99 - 1.25; // coffee with Bagel for 1.25 discount
            }
            return 0;
        }
    }
}
