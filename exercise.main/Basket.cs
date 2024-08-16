﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public Basket() { }

        public string Add(string productID)
        {
            if (capacity <= productCount) { return "your basket is full"; }
            if (!inventoryProductIds.Contains(productID)) { return "product does not exist inventory"; }

            Product product = GetFromInventory(productID);
            _basket.Add(product);
            return "product added to basket";
        }
 
        public bool Remove(string productID)
        {
            if (!inventoryProductIds.Contains(productID)) { return false; }
            
            Product product = GetFromInventory(productID);
            _basket.Remove(product);
            return true;
        }

        public Product GetFromInventory(string productID)
        {
            return _inventory.First(item => item.SKU == productID);
        }


        public int ChangeCapacity(int c, string adminPassword)
        {
            //Just returns the current capacity if not admin for now
            if (adminPassword == "admin"){ capacity = c;}

            return capacity;
        }

        public double GetCostOfProduct(string productId)
        {
            return GetFromInventory(productId).Price;
        }

        private List<Product> _inventory { get; set; } = new List<Product>()
        {
            new Product("BGLO", 0.49, "onion"),
            new Product("BGLP", 0.39, "plain"),
            new Product("BGLE", 0.49, "everything"),
            new Product("BGLS", 0.49, "sesame"),
            new Product("COFB", 0.99, "black"),
            new Product("COFW", 1.19, "white"),
            new Product("COFC", 1.29, "capuccino"),
            new Product("COFL", 1.29, "latte"),
            new Product("FILB", 0.12, "bacon"),
            new Product("FILE", 0.12, "egg"),
            new Product("FILC", 0.12, "cheese"),
            new Product("FILX", 0.12, "cream cheese"),
            new Product("FILS", 0.12, "smoked salmon"),
            new Product("FILB", 0.12, "ham"),
        };
        public int capacity { get; set; } = 5;
        public int productCount { get { return _basket.Count; } }
        public List<Product> _basket { get; set; } = new List<Product>();

        public List<string> basketProductIds { get { return _basket.Select(item => item.SKU).ToList(); } }

        public List<string> inventoryProductIds { get { return _inventory.Select(item => item.SKU).ToList();  } }
        public double totalCost { get { return _basket.Select(item => item.Price).ToList().Sum(); } }
    }
}
