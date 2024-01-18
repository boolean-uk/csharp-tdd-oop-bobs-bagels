﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Coffee
    {
        public string _sku;
        public double _price;
        public string _name;
        public string _variant;
        public List<Coffee> _Coffee;

        public Coffee(string sku, double price, string name, string variant)
        {
            _sku = sku;
            _price = price;
            _name = name;
            _variant = variant;
        }

        public string SKU { get { return _sku; } set { _sku = value; } }
        public double Price { get { return _price; } set { _price = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Variant { get { return _variant; } set { _variant = value; } }

        public List<Coffee> coffees { get { return _Coffee; } }
    }
}
