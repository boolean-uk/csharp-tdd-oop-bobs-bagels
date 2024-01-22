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
            
            private List<Item> basket = new List<Item>();
            
            private int basketCapacity;
            private Inventory inventory;

            public Basket(Inventory inventory) 
            {
                basketCapacity = 2;
                this.inventory = inventory;
            }




            public bool AddProduct(string productSKU, out string errorMessage)
            {
                if (inventory.ContainsProduct(productSKU))
                {
                    Item product = inventory.GetProduct(productSKU);

                    if (basket.Count < basketCapacity)
                    {
                        basket.Add(product);
                        errorMessage = string.Empty;
                        return true;
                    }
                    else 
                    {
                        errorMessage = "Basket is full";
                        return false;
                    }
            
                }
                errorMessage=string.Empty;
                return false;
            }

           

            public List<Item> GetBasketContent()
            {
                return new List<Item>(basket); // Return a copy of the basket to prevent modification from outside
            }



            public bool RemoveProduct(string productSKU, out string errorMessage)
            {

                Item product = inventory.GetProduct(productSKU);
                
                if (basket.Contains(product))
                {
                    basket.Remove(product);
                    errorMessage = string.Empty;
                    
                    return true;
                }
                else
                {
                    errorMessage = "Item not in basket";
                    return false;
                }
            }


            public int changeCapacity(int newCapacity)
            {
                basketCapacity = newCapacity;
                return basketCapacity;
            }


    // cost of bagel before added to basket
    //cost of filling before adding
        }
    
}
