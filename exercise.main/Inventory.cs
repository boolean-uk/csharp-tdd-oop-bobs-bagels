using System;
using System.Collections.Generic;

namespace exercise.main
{
    public class Inventory
    {
        private Dictionary<string, Item> bagelInventory = new Dictionary<string, Item>();
        private Dictionary<string, Item> coffeeInventory = new Dictionary<string, Item>();
        private Dictionary<string, Item> fillingInventory = new Dictionary<string, Item>();

        public Inventory()
        {
            bagelInventory["BGLO"] = new Item("BGLO", "Bagel", 0.49, "Onion");
            bagelInventory["BGLP"] = new Item("BGLP", "Bagel", 0.39, "Plain");
            bagelInventory["BGLE"] = new Item("BGLE", "Bagel", 0.49, "Everything");
            bagelInventory["BGLS"] = new Item("BGLS", "Bagel", 0.49, "Sesame");

            coffeeInventory["COFB"] = new Item("COFB", "Coffee", 0.99, "Black");
            coffeeInventory["COFW"] = new Item("COFW", "Coffee", 1.19, "White");
            coffeeInventory["COFC"] = new Item("COFC", "Coffee", 1.29, "Capuccino");
            coffeeInventory["COFL"] = new Item("COFL", "Coffee", 1.29, "Latte");
            coffeeInventory["COFD"] = new Item("COFD", "Coffee", 1.25, "& Bagel");

            fillingInventory["FILB"] = new Item("FILB", "Filling", 0.12, "Bacon");
            fillingInventory["FILE"] = new Item("FILE", "Filling", 0.12, "Egg");
            fillingInventory["FILC"] = new Item("FILC", "Filling", 0.12, "Cheese");
            fillingInventory["FILX"] = new Item("FILX", "Filling", 0.12, "Cream Cheese");
            fillingInventory["FILS"] = new Item("FILS", "Filling", 0.12, "Smoked Salmon");
            fillingInventory["FILH"] = new Item("FILH", "Filling", 0.12, "Ham");
        }

        public Dictionary<string, Item> GetBagelInventory() => bagelInventory;
        public Dictionary<string, Item> GetFillingInventory() => fillingInventory;
        public Dictionary<string, Item> GetCoffeeInventory() => coffeeInventory;

        public void PrintInventories()
        {
            Console.WriteLine("Bagel Inventory:");
            foreach (var kvp in bagelInventory)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            Console.WriteLine("\nCoffee Inventory:");
            foreach (var kvp in coffeeInventory)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            Console.WriteLine("\nFilling Inventory:");
            foreach (var kvp in fillingInventory)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
        }
        public Item GetItemBySKU(string sku)
        {
            if (sku.Length >= 3)
            {
                string inventoryType = sku.Substring(0, 3);
                switch (inventoryType)
                {
                    case "BGL":
                        return bagelInventory.ContainsKey(sku) ? bagelInventory[sku] : null;
                    case "COF":
                        return coffeeInventory.ContainsKey(sku) ? coffeeInventory[sku] : null;
                    case "FIL":
                        return fillingInventory.ContainsKey(sku) ? fillingInventory[sku] : null;
                }
            }
            return null;
        }

    }
}
