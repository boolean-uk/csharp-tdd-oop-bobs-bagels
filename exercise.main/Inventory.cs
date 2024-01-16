using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory {
        public List<Item> _inventory = new List<Item> {
            new Item("BGLO", 0.49f, "Bagel", "Onion"),
            new Item("BGLP", 0.39f, "Bagel", "Plain"),
            new Item("BGLE", 0.49f, "Bagel", "Everything"),
            new Item("BGLS", 0.49f, "Bagel", "Sesame"),
            new Item("COFB", 0.99f, "Coffee", "Black"),
            new Item("COFW", 1.19f, "Coffee", "White"),
            new Item("COFC", 1.29f, "Coffee", "Capuccino"),
            new Item("COFL", 1.29f, "Coffee", "Latte"),
            new Item("FILB", 0.12f, "Filling", "Bacon"),
            new Item("FILE", 0.12f, "Filling", "Egg"),
            new Item("FILC", 0.12f, "Filling", "Cheese"),
            new Item("FILX", 0.12f, "Fillin", "Cream Cheese"),
            new Item("FILS", 0.12f, "Filling", "Smoked Salmon"),
            new Item("FILH", 0.12f, "Filling", "Ham")
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
    }
}