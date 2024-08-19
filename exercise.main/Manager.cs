using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Manager
    {
        public int allowedBasketSize = 3; //Maximum basket size for all newly created baskets

        private Inventory inv = new Inventory(); //Inventory containing all products in the store

        public bool AddProduct(Basket bskt, string product)
        {
            //Check if product exists in inventory
            if(inv.Find(product))
            {
                //Add product to basket if it fits
                if (bskt.products.Count < bskt.size)
                {
                    bskt.products.Add(inv.GetProduct(product));
                    return true;
                }
            }
            return false;
        }

        public bool ChangeBasketSize(int newSize)
        {
            //If newSize is a positive integer
            if(newSize >= 0)
            {
                this.allowedBasketSize = newSize;
                return true;
            }
            return false;
        }

        public bool RemoveProduct(Basket bskt, string product)
        {
            //Check if product exists in basket
            int index = bskt.Search(product);
            if (index > -1)
            {
                //Remove product from basket
                bskt.products.RemoveAt(index);
                return true;
            }
            return false;
        }

        public float HowMuchProduct(string product)
        {
            //Check the inventory for the price of the item
            if(inv.Find(product))
            {
                return inv.GetProduct(product).info.price;
            }
            return 0.0f;
        }
    }
}
