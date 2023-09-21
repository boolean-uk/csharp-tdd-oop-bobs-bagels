﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Coffee : IProduct
    {
        public string SKU { get; }
        public decimal Price { get; }
        public string Variant { get; }
        public string Name => Variant;

        public Coffee(string sku, decimal price, string variant)
        {
            SKU = sku;
            Price = price;
            Variant = variant;
        }

        public decimal GetPrice() => Price;
    }
}