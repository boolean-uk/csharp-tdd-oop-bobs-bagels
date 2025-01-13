using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public abstract class Item
    {
        private string _name;

        public string Name { get { return _name; } }

        private float _price;

        public float Price { get { return _price; } }

        private string _sku;

        public string Sku { get { return _sku; } }

        protected Item(string sku, float price, string name) 
        { 
            _sku = sku;
            _name = name;
            _price = price;
        }

        public string GetItemName()
        {
            return Name;
        }

        public abstract float GetItemCost();

    }
}