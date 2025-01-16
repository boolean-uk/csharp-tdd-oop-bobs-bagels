﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class InventoryItem
    {

        public InventoryItem(string sku, double price, string name, string variant)
        {
            SKU = sku;
            Price = price;
            Name = name;
            Variant = variant;

        }

        public string SKU { get; set; }

        public double Price { get; set; }

        public string Name { get; set; }

        public string Variant { get; set; }

    }
}
