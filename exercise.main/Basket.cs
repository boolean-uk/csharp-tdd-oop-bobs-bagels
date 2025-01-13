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
        private List<Item> items;  // Should be dict?:  private Dictionary<string, Item> items;

        public Dictionary<string, Item> StockItems = new Dictionary<string, Item>()
        {
            {"BGLO", new Bagel("Bagel", "Onion", 0.49)},
            {"BGLP", new Bagel("Bagel", "Plain", 0.39)},
            {"BGLE", new Bagel("Bagel", "Everything", 0.49)},
            {"BGLS", new Bagel("Bagel", "Sesame", 0.49)},
            {"COFB", new Coffee("Coffee", "Black", 0.99)},
            {"COFW", new Coffee("Coffee", "White", 1.19)},
            {"COFC", new Coffee("Coffee", "Cappucino", 1.29)},
            {"COFL", new Coffee("Coffee", "Latte", 1.29)}
        };


        public int MaxSize { get { return maxSize; } set { maxSize = value; } }

        public List<Item> Items { get { return items; } set { items = value; } }


        public void addToBasketByID(string order) 
        {
            if (checkFull()){ throw new Exception("Basket is full"); }
            else if (!StockItems.ContainsKey(order)) { throw new Exception("Order not in stock"); }  
            else { items.Add(StockItems[order]); }
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
