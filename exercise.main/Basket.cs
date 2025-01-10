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
            if (Inventory.CheckIfInInventory(item))
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
                totalCost += item.cost;

            return totalCost;
        }

        public void AddFilling(Item filling, Item toBagel)
        {
            if (toBagel.name != "Bagel")
            {
                Console.WriteLine("Fillings can only be added to bagels.");
                return;
            }

            if (!_items.Contains(toBagel))
            {
                Console.WriteLine("Bagel not in basket.");
                return;
            }

            if (Inventory.CheckIfInInventory(filling)) {
                if (filling.name == "Filling")
                {
                    _items.Add(filling);
                    //toBagel.fillings.Add(filling);
                    Console.WriteLine($"Item added: {filling.variant} {filling.name}");
                }
                else
                    Console.WriteLine("Not a filling.");
            }
            else
                Console.WriteLine("Item does not exist.");
        }


        public List<Item> items { get { return _items; } }
    }
}
