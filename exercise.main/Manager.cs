﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Manager
    {
        private int capacity = 5;
        Inventory inventory = new Inventory();

        public bool ChangeCapcity(int newCapacity)
        {
            if(newCapacity < 0)
            {
                return false;
            }
            capacity = newCapacity; 
            return true;
            
        }

        public bool ConfirmOrder(string name, string variant, double remainingFunds, int basketSize)
        {
            if(!inventory.IsInInventory(name, variant))
            {
                return false; // item does not exist on menu
            }
            if(inventory.GetPrice(name, variant) > remainingFunds)
            {
                return false; //insufficient funds
            }
            if(basketSize >= capacity && name != "Filling")
            {
                return false; // basket cannot exceed capacity
                // note that fillings do not take up space, they are included in the bagel
            }

            return true;
        }

        public bool PrintReceipt(Basket basket)
        {
            if(basket.GetSize() > 0) // if basket is not empty
            {
                Receipt receipt = new Receipt();
                receipt.PrintReceipt(basket);
                return true;
            }
            return false;
        }
    }
}
