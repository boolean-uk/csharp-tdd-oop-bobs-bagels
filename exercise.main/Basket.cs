using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        //public List<String> myBasket = new List<String>();

        public List<Item> myBasket = new List<Item>();

        public int BasketSize { get; set; } = 5;

        public bool AddItem(Item item)
        {
            myBasket.Add(item);
            return true;
        }

        public bool RemoveItem(Item item)
        {
            myBasket.Remove(item);
            return true;
        }

        public bool FullBasket(List<Item> items)
        {
            bool isFull = false;
            if (items.Count < BasketSize)
            {
                Console.WriteLine("Your basket is not full!");
                isFull = false;
            }
            else if (items.Count >= BasketSize)
            {
                Console.WriteLine("Your basket is full!");
                isFull = true;
            }
            return isFull;
        }
        public int BasketCapacity(int newCap)
        {
            return BasketSize = newCap;
        }

        public bool SchrodingersItem(Item item)
        {
            bool hypotheticalItem = true;
            if (!myBasket.Contains(item))
            {
                hypotheticalItem = false;
                Console.WriteLine($"{item} does not exist and can NOT be removed from basket");
            }
            else
            {
                hypotheticalItem = true;
                Console.WriteLine($"{item} exists and can be removed from basket");
            }
            return hypotheticalItem;
        }
    }
}
