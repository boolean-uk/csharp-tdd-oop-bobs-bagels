﻿using System;
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

        public void RemoveFromBasket(Item item)
        {

            BasketItems.Remove(item);
        }

        public string PrintBasket()
        {
            string printout = "";
            if (BasketItems.Count > 0)
            {
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
            else
            {
                return "Basket is empty";
            }
        }

        public double BasketTotal()
        {
            foreach (Item item in BasketItems)
            {
                Total += item.Price;
            }
            return Math.Round(Total, 2);
        }

        public double Total { get => _total; set => _total = value; }
    
    }
}
