using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Basket
    {
        private List<Item> _items;
        private int _capacity ;//{ get; set; }
        public int Capacity { get { return _capacity; } }
        public List<Item> Items { get { return _items; } } 

        public Basket(int capacity)
        {
            _items = new List<Item>();
            _capacity = capacity; 
        }
        public bool AddItem(Item item)
        {
            if (_capacity > _items.Count)
            {
                if (Inventory.inventory.Contains(item))
                {
                    _items.Add(item);
                    return true;
                }
                return false;
            }
            return false;
        }

        public void RemoveItem(Item testItem)
        {
            Console.WriteLine(testItem);
            Console.WriteLine(_items);
            _items.Remove(testItem);
        }

        public void ChangeCapasity(int basketCapacity)
        {
            _capacity = basketCapacity;
        }

        public float GetCost()
        {
            return _items.Sum(x => x.Price);
        }
    }
}