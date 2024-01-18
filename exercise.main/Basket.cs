using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace exercise.main
{
    
        public class Basket : Item
        {
            //set basket capacity, i.e list length
            private List<IProduct> basket = new List<IProduct>();
            //private List<IProduct> basketItems;
            private int basketCapacity;
            private Inventory inventory;

        public Basket(Inventory inventory) : base(0, "", "", "") // Call the base class constructor
        {
            //basketItems = new List<IProduct>();
            basketCapacity = 2;
            this.inventory = inventory;
        }




        public bool AddProduct(string productSKU, out string message)
        {
            if (inventory.ContainsProduct(productSKU))
            {
                IProduct product = inventory.GetProduct(productSKU);

                if (basket.Count < basketCapacity)
                {
                    basket.Add(product);
                    message = string.Empty;
                    return true;
                }
                else //(basket.Count >= basketCapacity)
                {
                    message = "Basket is full";
                    return false;
                }
            
            }
            message=string.Empty;
            return false;
        }

        //add filling method

        public List<IProduct> GetBasketContent()
            {
                return new List<IProduct>(basket); // Return a copy of the basket to prevent modification from outside
            }



            public bool RemoveProduct(string productSKU, out string message)
            {

                IProduct product = inventory.GetProduct(productSKU);
            //Console.WriteLine(basket.Count);
                if (basket.Contains(product))
                {
                    basket.Remove(product);
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

        public bool AddFillingToBagel(string productSKU, IProduct filling, out string message)
        {
            IProduct product = inventory.GetProduct(productSKU);
            // Check if bagel is in the basket
            if (basket.Contains(product))
            {
                // Check if filling starts with 'F'
                if (filling.Name.StartsWith("F") )
                {
                        ((Item)product).AddSubItems(filling);
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
    


  
}
