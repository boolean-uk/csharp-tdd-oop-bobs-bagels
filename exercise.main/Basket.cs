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

        public static List<Item> StockItems = new List<Item>()
        {
            new Bagel("BGLO", "Bagel", "Onion", 0.49),
            new Bagel("BGLP", "Bagel", "Plain", 0.39),
            new Bagel("BGLE", "Bagel", "Everything", 0.49),
            new Bagel("BGLS", "Bagel", "Sesame", 0.49),
            new Coffee("COFB", "Coffee", "Black", 0.99),
            new Coffee("COFW", "Coffee", "White", 1.19),
            new Coffee("COFC", "Coffee", "Cappucino", 1.29),
            new Coffee("COFL", "Coffee", "Latte", 1.29)
        };


        public int MaxSize { get { return maxSize; } set { maxSize = value; } }

        public List<Item> Items { get { return items; } set { items = value; } }


        public void addToBasket(Item order) 
        {
            if (checkFull()){ throw new Exception("Basket is full"); }
            else if (!StockItems.Contains(order)) { throw new Exception("Order not in stock"); }  
            else { items.Add(order); }
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
                return items.Sum(i => i.getPrice());
            }
            return 0;
        }

    }
}
