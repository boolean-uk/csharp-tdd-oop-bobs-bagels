using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        public List<Item> items { get; private set; }
        public Inventory()
        {
            items = new List<Item>
            {
                new Item("BGLO", 0.49, "Bagel", "Onion"),
                new Item("BGLP", 0.39, "Bagel", "Plain"),
                new Item("BGLE", 0.49, "Bagel", "Everything"),
                new Item("BGLS", 0.49, "Bagel", "Sesame"),
                new Item("COFB", 0.99, "Coffee", "Black"),
                new Item("COFW", 1.19, "Coffee", "White"),
                new Item("COFC", 1.29, "Coffee", "Capuccino"),
                new Item("COFL", 1.29, "Coffee", "Latte"),
                new Item("FILB", 0.12, "Filling", "Bacon"),
                new Item("FILE", 0.12, "Filling", "Egg"),
                new Item("FILC", 0.12, "Filling", "Cheese"),
                new Item("FILX", 0.12, "Filling", "Cream Cheese"),
                new Item("FILS", 0.12, "Filling", "Smoked Salmon"),
                new Item("FILH", 0.12, "Filling", "Ham")
            };
        }

        public Item? GetItem(string sku)
        {
            return items.FirstOrDefault(x => x.Sku == sku);
        }

    }
}
