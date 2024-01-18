﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Objects
{
    public class Product
    {
        private string _SKU;
        private double _price;
        public enum pType{
            Bagel,
            Coffee,
            Filling
        }
        private pType _type;
        private string _variant;
        public string SKU { get { return _SKU; } }
        public double Price { get { return _price; } }
        public pType Type { get { return _type; } }
        public string Variant { get { return _variant; } }

        public List<Product> Filling = new();

        public Product(string sku, double price, pType name, string variant)
        {
            _type = name;
            _SKU = sku;
            _price = price;
            _variant = variant;
        }

        public bool AddFilling(Product filling)
        {
            if (filling == null || filling._type != pType.Filling || _type != pType.Bagel) return false;
            Filling.Add(filling);
            return true;
        }

        public bool RemoveFilling(Product filling)
        {
            if (filling == null || !Filling.Any(t => t.SKU == filling.SKU))
            {
                return false;
            }
            Filling.Remove(filling);
            return true;
        }

    }
}
