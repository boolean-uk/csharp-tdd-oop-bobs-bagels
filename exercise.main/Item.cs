﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Item
    {
        private string _sku;
        private double _price;
        private string _name;
        private string _variant;

        public string Sku => _sku;
        public double Price => _price;
        public string Name => _name;
        public string Variant => _variant;


        public Item(string sku, double price, string name, string variant)
        {
            _sku = sku;
            _price = price;
            _name = name;
            _variant = variant;
        }

        public ItemDto ToDto()
        {
            return new ItemDto(Sku, Price, Name, Variant);
        }
    }
}
