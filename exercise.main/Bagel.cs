﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : IItem
    {
        public string Sku { get; }
        public double Price { get; }
        public string Name { get; }
        public string Variant { get; }

        public Bagel(string sku, double price, string name, string variant)
        {
            Sku = sku;
            Price = price;
            Name = name;
            Variant = variant;
        }
    }
}
