using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        public List<Item> inventory;
        public Inventory()
        {
            inventory = new List<Item>();
            inventory.Add(new Item("BGLO", 0.49f, "Bagel", "Onion"));
            inventory.Add(new Item("BGLP", 0.39f, "Bagel", "Plain"));
            inventory.Add(new Item("BGLE", 0.49f, "Bagel", "Everything"));
            inventory.Add(new Item("BGLS", 0.49f, "Bagel", "Sesame"));
            inventory.Add(new Item("COFB", 0.99f, "Coffee", "Black"));
            inventory.Add(new Item("COFW", 1.19f, "Coffee", "White"));
            inventory.Add(new Item("COFC", 1.29f, "Coffee", "Capuccino"));
            inventory.Add(new Item("COFL", 1.29f, "Coffee", "Latte"));
            inventory.Add(new Item("FILB", 0.12f, "Filling", "Bacon"));
            inventory.Add(new Item("FILE", 0.12f, "Filling", "Egg"));
            inventory.Add(new Item("FILC", 0.12f, "Filling", "Cheese"));
            inventory.Add(new Item("FILX", 0.12f, "Filling", "Cream Cheese"));
            inventory.Add(new Item("FILS", 0.12f, "Filling", "Smoked Salmon"));
            inventory.Add(new Item("FILH", 0.12f, "Filling", "Ham"));

        }
        public bool inInventory(string SKU)
        {
            foreach(Item item in inventory)
            {
                if(item.SKU == SKU)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
