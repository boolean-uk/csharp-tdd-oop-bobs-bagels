using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public List<IProduct> items;

        public int capacity;
        public Basket()
        {
            items = new List<IProduct>();
            capacity = 5;
        }

        public string Add(IProduct item)
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

        public IProduct Remove(string sku)
        {
            IProduct? item = items.FirstOrDefault(i => i.Sku == sku);
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
            foreach (IProduct item in items)
            {
                if (item is Bagel bagel && bagel.filling != null)
                {
                    total += bagel.filling.Price;
                }

                total += item.Price;
            }

            return total;
        }

        public void ApplyDiscount()
        {
            throw new NotImplementedException();
        }
    }
}
