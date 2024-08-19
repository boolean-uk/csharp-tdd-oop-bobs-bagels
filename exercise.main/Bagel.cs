﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BobsBagels.main
{
    public class Bagel(string sku, float price, string name, string variant) : Item(sku, price, name, variant)
    {
        private List<Filling> _fillings = [];
        private float _price = price;
        private static void CalculatePrice() { throw new NotImplementedException();}
        public bool AddFilling(Filling filling) 
        {
            if (_fillings.Contains(filling)) return false;
            _fillings.Add(filling);
            return true;
        }

        public bool RemoveFilling(Filling filling) { throw new NotImplementedException(); }

        public List<Filling> Fillings { get { return _fillings; } }
    }
}
