using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Basket
    {
        private List<IProduct> _items;
        private int _capacity;

        public Basket()
        {
            _items = new List<IProduct>();
            _capacity = 10;
        }

        public List<IProduct> Items { get =>  _items; }
        public int Capacity { get => _capacity; set => _capacity = value; }

        public void Add(IProduct product)
        {
            if (Items.Count == Capacity) { throw new Exception("Basket is full"); }

            Items.Add(product);
        }

        public void Remove(IProduct product)
        {
            if (!Items.Contains(product)) { throw new Exception("Product does not exist in basket"); }

            Items.Remove(product);
        }

        public double GetBagelDiscountHalfDozen(int count, double price)
        {
            double total = 2.49 * Math.Floor(count / 6d);

            if ((count % 6) >= 1)
            {
                total += price * (count % 6);
            }

            return total;
        }

        public double GetBagelDiscountDozen(int count, double price)
        {
            double total = 3.99 * Math.Floor(count / 12d);

            if ((count % 12) >= 6) {
                total += 2.49 + (price * (count % 6));
            } 
            else
            {
                total += price * (count % 12);
            }

            return total;
        }

        public double GetPrice(int count, double price, bool discount)
        {
            double total = 0;

            if (!discount) { return price * count; }

            if ((count / 12) >= 1)
            {
                total += GetBagelDiscountDozen(count, price);
            }
            else if ((count / 6) >= 1)
            {
                total += GetBagelDiscountHalfDozen(count, price);
            }
            else
            {
                total += price * count;
            }

            return total;
        }

        public Dictionary<string, int> getCount(IEnumerable<IProduct> items)
        {
            Dictionary<string, int> countDict = new Dictionary<string, int>();
            foreach(var item in items)
            {
                if (!countDict.ContainsKey(item.SKU))
                {
                    countDict.Add(item.SKU, 1);
                } 
                else
                {
                    countDict[item.SKU]++;
                }
            }
            return countDict;
        }

        public double GetTotal()
        {
            Dictionary<string, int> bagelCount = getCount(Items.Where(item => item is Bagel));
            double sum = 0;

            foreach ((string SKU, int count) in bagelCount)
            {
                sum += GetPrice(count, new Bagel(SKU).Price, true);
            }

            sum += Items.Where(item => (item is Filling || item is Coffee)).Sum(item => item.Price);

            return sum;
        }
    }
}