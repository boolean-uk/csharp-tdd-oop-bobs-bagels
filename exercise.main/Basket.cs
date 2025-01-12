using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private static int maxSize;
        private List<Item> items;

        public int MaxSize { get { return maxSize; } set { maxSize = value; } }

        public List<Item> Items { get { return items; } set { items = value; } }

        public void addToBasket(Item order) 
        {
            if (!checkFull()){ items.Add(order); }
            else { throw new Exception("Basket is full"); }        
        }

        public void removeFromBasket(Item order) 
        {
            if (items.Contains(order)) { items.Remove(order); }
            else { throw new Exception("No such item in basket"); }
        } 

        public bool checkFull() { return items.Count >= maxSize; }

        public void setBasketSize(bool manager, int newSize)
        {
            if (!manager) { throw new Exception("No persmission to alter size"); } 
            else { maxSize = newSize; }
        }

        public double getTotalCost()
        {
            if(items != null && items.Count > 0)
            {
                double totalCost = 0;
                foreach (Item item in items)
                {
                    totalCost += item.getPrice();
                }
                return totalCost;
            }
            return 0;
        }

    }
}
