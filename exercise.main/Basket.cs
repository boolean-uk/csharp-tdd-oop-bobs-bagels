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

        public string Add(Item item)
        {
            Inventory inventory = new Inventory();
            if (!inventory.ValidateItem(item))
            {
                return "invalid item";
            }

            if (this.capacity > items.Count)
            {
                items.Add(item);
                return $"{item.Sku} added to basket.";
            }
            return "Basket is full, item not added";
        }

        public Item Remove(string sku)
        {
            Item? item = items.FirstOrDefault(i => i.Sku == sku);
            if (item != null)
            {
                items.Remove(item);
            }
            return item;
        }
        

        public int ChangeCap(int cap)
        {
            this.capacity = cap;
            return this.capacity;

        }

        public double Total()
        {
            double total = 0;
            foreach (Item item in items)
            {
                // apply filling price if bagel has filling
                if(item.Type == "Bagel" && item.Filling != null)
                {
                    total += item.Filling.Price;
                }
                total += item.Price;
            }

            return total;
        }

        public void ApplyDiscount()
        {
            
        }
    }
}
