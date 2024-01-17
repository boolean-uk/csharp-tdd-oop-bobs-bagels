using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class BagelInventory
    {

        public bool IsItemInInventory(string item)
        {
            return _inventory.ContainsKey(item);
        }
        private Dictionary<string, Bagel> _inventory;

        public BagelInventory()
        {
            _inventory = new Dictionary<string, Bagel>
            {
                {"BGLO", new Bagel {SKU = "BGLO", Price = 0.49, Name = "Bagel", Variant = "Onion"}},
                {"BGLP", new Bagel {SKU = "BGLP", Price = 0.39, Name = "Bagel", Variant = "Plain"}},
                {"BGLE", new Bagel {SKU = "BGLE", Price = 0.49, Name = "Bagel", Variant = "Everything"}},
                {"BGLS", new Bagel {SKU = "BGLS", Price = 0.49, Name = "Bagel", Variant = "Sesame"}},
                {"COFB", new Bagel {SKU = "COFB", Price = 0.99, Name = "Coffee", Variant = "Black"}},
                {"COFW", new Bagel {SKU = "COFW", Price = 1.19, Name = "Coffee", Variant = "White"}},
                {"COFC", new Bagel {SKU = "COFC", Price = 1.29, Name = "Coffee", Variant = "Cappuccino"}},
                {"COFL", new Bagel {SKU = "COFL", Price = 1.29, Name = "Coffee", Variant = "Latte"}},
                {"FILB", new Bagel {SKU = "FILB", Price = 0.12, Name = "Filling", Variant = "Bacon"}},
                {"FILE", new Bagel {SKU = "FILE", Price = 0.12, Name = "Filling", Variant = "Egg"}},
                {"FILC", new Bagel {SKU = "FILC", Price = 0.12, Name = "Filling", Variant = "Cheese"}},
                {"FILX", new Bagel {SKU = "FILX", Price = 0.12, Name = "Filling", Variant = "Cream Cheese"}},
                {"FILS", new Bagel {SKU = "FILS", Price = 0.12, Name = "Filling", Variant = "Smoked Salmon"}},
                {"FILH", new Bagel {SKU = "FILH", Price = 0.12, Name = "Filling", Variant = "Ham"}},
            };
        }

        public double GetCost(string bagelType)
        {
            if(_inventory.TryGetValue(bagelType, out var bagel))
            {
                return bagel.Price;
            }

            throw new ArgumentException("Invalid bagel type.");
        }

        public double GetFillingsCost(string[] fillings)
        {
            double totalCost = 0;
            foreach (var filling in fillings)
            {
                if (_inventory.TryGetValue(filling, out var fillingBagel))
                {
                    totalCost += fillingBagel.Price;
                }
                else
                {
                    throw new ArgumentException($"Invalid filling type: {filling}.");
                }
            }

            return totalCost;
        }

    }
}