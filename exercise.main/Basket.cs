using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        // Does the basket need to contain the actual objects, or will "printouts" suffice?
        //public List<ChosenItem> items;
        private double _total;

        private int _cap;
        private string? _capnotice;

        public Dictionary<int, List<Item>> BasketItems = new();

        public void AddToBasket(int id, List<Item> item) 
        {
            if (BasketItems.Count < Cap)
            {
                BasketItems.Add(id, item);
            }
            else 
            {
                CapNotice = "Your basket is full";
            }
        }

        public void RemoveFromBasket(int id)
        {
            BasketItems.Remove(id);
            //BasketItems.Remove(item);
        }

        public string PrintBasket()
        {
            string printout = "";
            if (BasketItems.Count > 0)
            {
                foreach (KeyValuePair<int, List<Item>> item in BasketItems)
                {
                    int key = item.Key;
                    List<Item> items = item.Value;
                    foreach (Item thing in items)
                    if (thing is Bagel bagel)
                    {
                        printout += thing.PrintItem();
                        printout += $"\nWith: {bagel.Filling}";
                    }
                    else
                    {
                        //printout += thing.PrintItem();
                    }
                }
                return printout;
            }
            else
            {
                return "Basket is empty";
            }
        }

        public double BasketTotal()
        {
            foreach (KeyValuePair<int, List<Item>> item in BasketItems)
            {
                int key = item.Key;
                List<Item> items = item.Value;
                foreach (Item thing in items) 
                {
                    Total += thing.Price;
                }
            }
            return Math.Round(Total, 2);
        }

        public double Total { get => _total; set => _total = value; }

        public int Cap { get => _cap; set => _cap = value;}

        public string CapNotice { get => _capnotice; set => _capnotice = value; }
    
    }
}
