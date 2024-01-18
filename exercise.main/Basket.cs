using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop.main
{
    public class Basket
    {
        public List<Item> items;

        public int Capacity { get; private set; }

        public Basket(int capacity)
        {
            Capacity = capacity;
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (!IsFull())
            {
                items.Add(item);
            }

            else
            {
                throw new InvalidOperationException("Basket is full. Cannot add more items.");
            }
        }


        public void RemoveItem(Item item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
            }
            else
            {
                throw new InvalidOperationException($"{item} not found in the basket.");
            }
        }

        public bool IsFull()
        {
            return items.Count >= Capacity;
        }

        public double CalculateTotalCost()
        {
            double totalCost = 0;
            foreach (var item in items)
            {
                totalCost += item.CalculateCost();
            }
            return totalCost;
        }

        public void ExpandCapacity(int newCapacity)
        {
            Capacity = newCapacity;
        }
    }
}
