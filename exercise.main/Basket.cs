using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Basket
    {
        private List<IProduct> _items;
        private int _capacity;
        private int _nrItems;

        public Basket()
        {
            _items = new List<IProduct>();
            _capacity = 10;
            _nrItems = 0;
        }

        public List<IProduct> Items { get =>  _items; }
        public int Capacity { get => _capacity; set => _capacity = value; }
        public int NrItems { get => _nrItems; set => _nrItems = value; }

        public void Add(IProduct product)
        {
            if (Items.Count == Capacity)
            {
                throw new Exception("Basket is full");
            }

            Items.Add(product);
            NrItems++;
        }

        public void Remove(IProduct product)
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

        public double GetPrice(int count, double price, bool discount)
        {
            double total = 0;
            if (!discount) { return price * count; }
            if ((count / 12) >= 1) total = 3.99 + (price * (count % 12));
            else if ((count / 6) >= 1) total = 2.49 + (price * (count % 6));
            else total = price * count;
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

        // Find simpler way?
        public double GetTotal()
        {
            Dictionary<string, int> bagelCount = getCount(Items.Where(item => item is Bagel));

            double sum = 0;
            foreach ((string SKU, int count) in bagelCount)
            {
                sum += GetPrice(count, new Bagel(SKU).Price, true);
            }

            sum += Items.Where(filling => filling is Filling).Sum(filling => filling.Price);
            sum += Items.Where(coffee => coffee is Coffee).Sum(coffee => coffee.Price);

            return sum;
        }
    }
}