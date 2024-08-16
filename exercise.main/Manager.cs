﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Manager
    {
        public int allowedBasketSize = 3;

        Inventory inv = new Inventory();

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
    }
}
