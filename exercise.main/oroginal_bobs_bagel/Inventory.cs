using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory {
        public List<Item> _inventory = new List<Item> {
            new Item("BGLO", 0.49m, "Bagel", "Onion"),
            new Item("BGLP", 0.39m, "Bagel", "Plain"),
            new Item("BGLE", 0.49m, "Bagel", "Everything"),
            new Item("BGLS", 0.49m, "Bagel", "Sesame"),
            new Item("COFB", 0.99m, "Coffee", "Black"),
            new Item("COFW", 1.19m, "Coffee", "White"),
            new Item("COFC", 1.29m, "Coffee", "Capuccino"),
            new Item("COFL", 1.29m, "Coffee", "Latte"),
            new Item("FILB", 0.12m, "Filling", "Bacon"),
            new Item("FILE", 0.12m, "Filling", "Egg"),
            new Item("FILC", 0.12m, "Filling", "Cheese"),
            new Item("FILX", 0.12m, "Filling", "Cream Cheese"),
            new Item("FILS", 0.12m, "Filling", "Smoked Salmon"),
            new Item("FILH", 0.12m, "Filling", "Ham")
        };

        // Can be fun to have a class to change avaliability and add a bool param in Item constructor

        public bool IsItemInStock(string sku) {
            foreach (Item item in _inventory) {
                if (item.Sku.Equals(sku)) { // it is in inventory
                    return true;
                }
            }
            return false;
        }

        public decimal GetFillingCost(string sku)
        { 
            if (sku.Contains("FIL", StringComparison.OrdinalIgnoreCase)) //! We only want to check fillings in this function
            {
                foreach (Item item in _inventory)
                {
                    if (item.Sku.Equals(sku))
                    {
                        return item.Price;                    
                    }
                }
            } 
            throw new Exception("Invalid filling SKU!");
        }

        public Item GetFilling(string sku)
        {
            if (IsItemInStock(sku) && sku.Contains("FIL", StringComparison.OrdinalIgnoreCase))
            {
                return _inventory.Find(item => item.Sku.Equals(sku));
            }

            throw new Exception("Invalid filling SKU!");
        }

        public List<Tuple<string, decimal>> DisplayAllFillings()
        {
            List<Tuple<string, decimal>> allFillings = new List<Tuple<string, decimal>>();

            foreach (Item item in _inventory)
            {
                if (item.Name.Equals("Filling"))
                {
                    allFillings.Add(new Tuple<string, decimal> ( item.Variant, item.Price ));
                }
            }

            return allFillings;
        }

        public decimal GetBagelCost(string sku)
        {
            if (sku.Contains("BGL", StringComparison.OrdinalIgnoreCase)) //! We only want to check bagels in this funciton
            {
                foreach (Item item in _inventory)
                {
                    if (item.Sku.Equals(sku))
                    {
                        return item.Price;
                    }
                }
            }
            throw new Exception("Invalid Bagel SKU!");
        }

        public Item GetBagel(string sku)
        {
            if (IsItemInStock(sku))
            {
                foreach (Item item in _inventory)
                {
                    if (item.Sku.Equals (sku))
                    {
                        return item;
                    }    
                }
                 
            }
            throw new Exception("Invalid type of bagel!");
        }
    }
}