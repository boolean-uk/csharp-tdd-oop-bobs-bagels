﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace exercise.main
{
    
        public class Basket
        {
            //set basket capacity, i.e list length
            private List<Item> basket = new List<Item>();
            private List<Item> basketItems;
            private int basketCapacity = 2;

        public Basket()
        {
            basket = new List<Item>();
            basketItems = new List<Item>();
        }

        public void AddItem(Item item)
        {
            basketItems.Add(item);
        }

        public List<Item> GetBasketItems()
        {
            return basketItems;
        }


        public bool addBagel(Item bagel, out string message)
            {

                if (basket.Count < basketCapacity)
                {
                    basket.Add(bagel);
                    message = string.Empty;
                    return true;
                }
                else
                {
                    message = "Basket is full";
                    return false;
                }
            }

            //add filling method

            public List<Item> GetBasketContent()
            {
                return new List<Item>(basket); // Return a copy of the basket to prevent modification from outside
            }



            public bool removeBagel(Item bagel, out string message)
            {
                Console.WriteLine(basket.Count);
                if (basket.Contains(bagel))
                {
                    basket.Remove(bagel);
                    message = string.Empty;
                    //
                    return true;
                }
                else
                {
                    message = "Item not in basket";
                    return false;
                }
            }


            public int changeCapacity(int newCapacity)
            {
                basketCapacity = newCapacity;
                return basketCapacity;
            }

        public bool addFillingToBagel(Item bagel, Item filling, out string message)
        {
            // Check if bagel is in the basket
            if (basket.Contains(bagel))
            {
                // Check if filling starts with 'F'
                if (filling.getNameVariant().StartsWith("F"))
                {
                    // Add the filling to the bagel's subItems
                    bagel.addSubItems(filling);

                    message = string.Empty;
                    return true;
                }
                else
                {
                    message = "Invalid filling type";
                    return false;
                }
            }
            else
            {
                message = "Bagel not in basket";
                return false;
            }
        }
    
}
    



    /*
     - class Basket()


     - Properties
    public List<string> basket
    public int basketCapacity


    -Methods
    bool add bageltype (string)
            adds a bagel to the basket, outputs true if bagel added and false otherwise
            If the basket is full, outputs a message saying the basket is full

    bool remove bageltype (string)
            removes a bagel from the basket, outputs true if the bagel is removed and false otherwise
            If the item is not in the basket, outputs a message saying the item doesn't exist

    int changeCapacity(int)
            changes the capacity of the basket, outputs the new integer capacity

     */
}
