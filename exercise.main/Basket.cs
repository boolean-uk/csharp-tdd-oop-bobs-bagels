using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Basket
    {
        private List<Product> _items;
        private int _capacity;
        private int _nrItems;

        public Basket()
        {
            _items = new List<Product>();
            _capacity = 10;
            _nrItems = 0;
        }

        public List<Product> Items { get =>  _items; }
        public int Capacity { get => _capacity; set => _capacity = value; }
        public int NrItems { get => _nrItems; set => _nrItems = value; }

        public void Add(Product product)
        {
            if (Items.Count == Capacity)
            {
                throw new Exception("Basket is full");
            }

            Items.Add(product);
            NrItems++;
        }

        public void Remove(Product product)
        {
            if (Items.Contains(product))
            {
                Items.Remove(product);
                NrItems--;
            }
            else
            {
                throw new Exception("Product does not exist in basket");
            }
        }

/*        public void Add(Coffee coffee)
        {
            if (Items.Count == Capacity)
            {
                throw new Exception("Basket is full");
            }
            
            Coffees.Add(coffee);
            NrItems++;
        }

        public void Remove(Coffee coffee)
        {
            if(Coffees.Contains(coffee))
            {
                Coffees.Remove(coffee);
                NrItems--;
            }
            else
            {
                throw new Exception("Coffee does not exist in basket");
            }
        }*/

        public double GetTotal()
        {
            Dictionary<string, int> bagelCount = new Dictionary<string, int>();
            foreach(Bagel bagel in Items.Where(item => item is Bagel))
            {
                if (!bagelCount.ContainsKey(bagel.SKU))
                {
                    bagelCount.Add(bagel.SKU, 1);
                }
                else
                {
                    bagelCount[bagel.SKU]++;
                }

            }

            double sum = 0;
            foreach ((string SKU, int count) in bagelCount)
            {
                if ((count / 12) >= 1) sum += 3.99 + (new Bagel(SKU).Price * (count % 12));
                else if ((count / 6) >= 1) sum += 2.49 + (new Bagel(SKU).Price * (count % 6));
                else sum += new Bagel(SKU).Price * count;
            }

            sum += Items.Where(bagel => bagel is Bagel).Sum(bagel => bagel.Filling is not null ? bagel.Filling.Price : 0);
            sum += Items.Where(coffee => coffee is Coffee).Sum(coffee => coffee.Price);

            return sum;
        }
    }
}