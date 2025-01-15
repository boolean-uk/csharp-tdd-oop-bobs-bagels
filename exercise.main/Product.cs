﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Product
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string SKU, double price, string name)
        {
            this.SKU = SKU;
            this.Price = price;
            this.Name = name;
        }
    }
}
