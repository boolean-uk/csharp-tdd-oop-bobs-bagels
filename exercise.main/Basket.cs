using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            IProduct item = items.FirstOrDefault(i => i.Sku == sku);
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
                if (item is Bagel bagel && bagel.Filling != null)
                {
                    total += bagel.Filling.Price;
                }

                total += item.Price;
            }
            this.ApplyDiscount();
            return total;
        }
        public void ApplyDiscount()
        {
            var bagelCount = items
                .Where(item => item.Type == "Bagel") 
                .ToList().Count;

            double discountedPrice12b = 0.3325; 
            double discountedPrice6b = 0.415;  

            int discounted12Count = 0; 
            int discounted6Count = 0;  

            foreach (IProduct item in this.items)
            {
                if (item is Bagel bagel)
                {
                    // Apply discount for 12 bagels if there are enough
                    if (discounted12Count < (bagelCount / 12) * 12)
                    {
                        bagel.Price = discountedPrice12b;
                        discounted12Count++;
                    }
                    // Apply discount for 6 bagels if there are enough
                    else if (discounted6Count < (bagelCount % 12) / 6 * 6)
                    {
                        bagel.Price = discountedPrice6b;
                        discounted6Count++;
                    }
                }
            }
        }

    }
}
