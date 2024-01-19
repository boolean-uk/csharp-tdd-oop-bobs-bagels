using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        public List<Item> InventoryItems { get; set; } = new List<Item>();

        public Inventory()
        {
            InventoryItems.Add(new Item("BGLO", 0.49, "Bagel", "Onion"));
            InventoryItems.Add(new Item("BGLP", 0.39, "Bagel", "Plain"));
            InventoryItems.Add(new Item("BGLE", 0.49, "Bagel", "Everything"));
            InventoryItems.Add(new Item("BGLS", 0.49, "Bagel", "Sesame"));
            InventoryItems.Add(new Item("COFB", 0.99, "Coffee", "Black"));
            InventoryItems.Add(new Item("COFW", 1.19, "Coffee", "White"));
            InventoryItems.Add(new Item("COFC", 1.29, "Coffee", "Capuccino"));
            InventoryItems.Add(new Item("COFL", 1.29, "Coffee", "Latte"));
            InventoryItems.Add(new Item("FILB", 0.12, "Filling", "Bacon"));
            InventoryItems.Add(new Item("FILE", 0.12, "Filling", "Egg"));
            InventoryItems.Add(new Item("FILC", 0.12, "Filling", "Cheese"));
            InventoryItems.Add(new Item("FILX", 0.12, "Filling", "Cream Cheese"));
            InventoryItems.Add(new Item("FILS", 0.12, "Filling", "Smoked Salmon"));
            InventoryItems.Add(new Item("FILH", 0.12, "Filling", "Ham"));
        }

        public void CostOfBagel()
        {
            Console.WriteLine("Price of all Bagels");
            foreach (var item in this.InventoryItems)
            {
                if (item.Name == "Bagel")
                {
                    Console.WriteLine($"Variant: {item.Variant}, Price: {item.Price}");
                }
            }
        }

        public void CostOfFilling()
        {
            Console.WriteLine("Price of all Fillings");
            foreach(var item in this.InventoryItems)
            {
                if(item.Name == "Filling")
                {
                    Console.WriteLine($"Variant: {item.Variant}, Price: {item.Price}");
                }
            }

        }

    }
}
