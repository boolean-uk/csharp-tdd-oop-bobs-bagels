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
        private static int basketSize { get; set; }

        public Basket()
        {

        }

        public void Add(Item item)
        {
            _items.Add(item);
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
