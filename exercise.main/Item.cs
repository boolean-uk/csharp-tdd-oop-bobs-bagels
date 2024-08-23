﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public abstract class Item
    {
        private string _sku;
        private double _price;
        private string _name;
        private string _variant;

        protected Item (string sku, double price, string name, string variant)
        {
            Sku = sku;
            Price = price;
            Name = name;
            Variant = variant;
        }

        public string Sku { get => _sku; set => _sku = value; }
        public double Price { get => _price; set => _price = value; }
        public string Name { get => _name; set => _name = value; }
        public string Variant { get => _variant; set => _variant = value; }



        public string PrintItem()
        {
            return $"{Sku}, {Price}\n{Name}, {Variant}";
        }
    }
}
