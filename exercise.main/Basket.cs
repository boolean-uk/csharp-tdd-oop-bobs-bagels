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
        public List<Item> Items { get; set; }

        public void AddToBasket(Item item) 
        {
            
        }

        public string PrintBasket()
        {
            return "Nothing";
        }
    
    }
}
