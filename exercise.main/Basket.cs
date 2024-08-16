﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public int size {  get; set; } //Size of basket
        public List<Product> products = new List<Product>(); //List of all 

        public Basket(Manager manager)
        {
            this.size = manager.allowedBasketSize; 
        }
    }
}
