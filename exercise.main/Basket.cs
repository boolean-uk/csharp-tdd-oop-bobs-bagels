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

        public List<Item> BasketItems = new List<Item>();

        public void AddToBasket(Item item) 
        {
            BasketItems.Add(item);
        }

        public string PrintBasket()
        {
            string printout = "";
            foreach (Item item in BasketItems)
            {
                if (item is Bagel bagel) 
                {
                    printout += item.PrintItem();
                    printout += $"\nWith: {bagel.Filling}";
                }
                else
                {
                    printout += item.PrintItem();
                }
            }
            return printout;
        }

        public double BasketTotal()
        {
            foreach (Item item in BasketItems)
            {
                Total += item.Price;
            }
            return Total;
        }

        public double Total { get => _total; set => _total = value; }
    
    }
}
