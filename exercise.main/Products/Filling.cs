﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class Filling : Product
    {
        public Filling(string sku, double price, string name, string variant) : base(sku, price, name, variant)
        {
        }
    }
}
