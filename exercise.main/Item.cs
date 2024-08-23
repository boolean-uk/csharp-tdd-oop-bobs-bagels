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
        public string _variant;


        public Item()
        {

        }
        public Item(string sku, double price, string name, string variant) {

            _sku = sku;
            _price = price;
            _name = name;
            _variant = variant;
        
        }
        public string Sku { get { return _sku; } }
        public double Price { get { return _price; } }
        public string Name { get { return _name; } }

        public string Variant { get { return _variant; } }

    }
   
    }

