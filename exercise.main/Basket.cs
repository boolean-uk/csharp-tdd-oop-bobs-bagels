using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<Item> _items = new List<Item>();
        private static int _basketSize { get; set; }

        private List<Item> inventory = Inventory.inventory;

        public Basket()
        {
            List<Item> inventory = Inventory.inventory;
        }

        public void Add(Item item)
        {
            if (Inventory.CheckIfInInventory(item))
            {
                _items.Add(item);
                Console.WriteLine("Item added.");
            }
            else
                Console.WriteLine("Item does not exist.");
        }

        public void Remove(string item)
        {
            if (_items.Count == 0)
                Console.WriteLine("Basket is empty");

            foreach (Item itm in _items)
                if (itm.sKU == item)
                {
                    _items.Remove(itm);
                    Console.WriteLine($"{itm.name} {itm.variant} removed.");
                    return;
                }

            Console.WriteLine($"{item} is not in basket.");
        }

        public List<Item> items { get { return _items; } }
    }
}
