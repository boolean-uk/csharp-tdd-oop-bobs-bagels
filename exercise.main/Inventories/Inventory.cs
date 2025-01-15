using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Products;

namespace exercise.main.Inventories
{
    public class Inventory : IInventory
    {
        //Singleton
        private static readonly Inventory _instance = new Inventory(); // Singleton instance
        public static Inventory Instance => _instance;

        private Dictionary<string, Product> _inventoryDictionary;

        private Inventory()
        {
            _inventoryDictionary = new Dictionary<string, Product>();

            PopulateInventory();
        }


        public double GetPrice(Product p)
        {
            if (IsInStock(p))
            {
                return p.Price;
            }
            return -1d;
        }

        public bool IsInStock(Product p)
        {
            return _inventoryDictionary.ContainsKey(p.Sku);
        }

        private void PopulateInventory()
        {
            _inventoryDictionary.Add("BGLO", new Bagel("BGLO", 0.49, "Bagel", "Onion"));
            _inventoryDictionary.Add("BGLP", new Bagel("BGLP", 0.39, "Bagel", "Plain"));
            _inventoryDictionary.Add("BGLE", new Bagel("BGLE", 0.49, "Bagel", "Everything"));
            _inventoryDictionary.Add("BGLS", new Bagel("BGLS", 0.49, "Bagel", "Sesame"));
            _inventoryDictionary.Add("COFB", new Coffee("COFB", 0.99, "Coffee", "Black"));
            _inventoryDictionary.Add("COFW", new Coffee("COFW", 1.19, "Coffee", "White"));
            _inventoryDictionary.Add("COFC", new Coffee("COFC", 1.29, "Coffee", "Capuccino"));
            _inventoryDictionary.Add("COFL", new Coffee("COFL", 1.29, "Coffee", "Latte"));
            _inventoryDictionary.Add("FILB", new Filling("FILB", 0.12, "Filling", "Bacon"));
            _inventoryDictionary.Add("FILE", new Filling("FILE", 0.12, "Filling", "Egg"));
            _inventoryDictionary.Add("FILC", new Filling("FILC", 0.12, "Filling", "Cheese"));
            _inventoryDictionary.Add("FILX", new Filling("FILX", 0.12, "Filling", "Cream Cheese"));
            _inventoryDictionary.Add("FILS", new Filling("FILS", 0.12, "Filling", "Smoked Salmon"));
            _inventoryDictionary.Add("FILH", new Filling("FILH", 0.12, "Filling", "Ham"));
        }

    }
}
