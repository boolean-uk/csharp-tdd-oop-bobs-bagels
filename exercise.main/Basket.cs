using System;
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
            List<string> basket = new List<string>();
            public int basketCapacity = 2;

            public Basket()
            {
                basket = new List<string>();
            }


            public bool addBagel(string bagelType, out string message)
            {
                if (basket.Count < basketCapacity)
                {
                    basket.Add(bagelType);
                    message = string.Empty;
                    return true;
                }
                else
                {
                    message = "Basket is full";
                    return false;
                }
            }

            public List<string> GetBasketContent()
            {
                return new List<string>(basket); // Return a copy of the basket to prevent modification from outside
            }



            public bool removeBagel(string bagelType, out string message)
            {
                Console.WriteLine(basket.Count);
                if (basket.Contains(bagelType))
                {
                    basket.Remove(bagelType);
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
