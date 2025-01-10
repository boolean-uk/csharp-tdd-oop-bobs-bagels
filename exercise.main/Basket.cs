using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public List<Item> items;
        public int capacity;
        public Basket()
        {
            items = new List<Item>();
            capacity = 5;
        }

        public void Add(Item item)
        {
            items.Add(item);
        }

        public Item Remove(string sku)
        {
            Item? item = items.FirstOrDefault(i => i.Sku == sku);
            if (item != null)
            {
                items.Remove(item);
                return item;
            }
            return item;
        }

    }
}
