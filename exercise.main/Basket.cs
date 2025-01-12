using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
            _basketSize = 10;
        }

        public void Add(Item item)
        {
            if (item.name == "Filling")
                Console.WriteLine("Fillings cannot be added to the basket directly.");

            else if (Inventory.CheckIfInInventory(item))
            {
                _items.Add(item);
                Console.WriteLine($"{item.variant} {item.name} added.");
            }

            else
                Console.WriteLine("Item does not exist.");
        }

        public void Remove(Item item)
        {
            if (_items.Count == 0)
                Console.WriteLine("Basket is empty");

            foreach (Item itm in _items)
                if (itm == item)
                {
                    _items.Remove(itm);
                    Console.WriteLine($"{itm.variant} {itm.name} removed.");
                    return;
                }

            Console.WriteLine($"{item} is not in basket.");
        }

        public int SpaceLeft()
        {
            return _basketSize - _items.Count;
        }

        public void ChangeCapacity(int newCapacity)
        {
            _basketSize = newCapacity;
        }

        public float GetTotalCost()
        {
            float totalCost = 0f;

            foreach (Item item in _items)
            {
                totalCost += item.cost;
                foreach (Item filling in item.GetFillings())
                    totalCost += filling.cost;
            }

            return totalCost;
        }

        public List<Item> items { get { return _items; } }
    }
}
