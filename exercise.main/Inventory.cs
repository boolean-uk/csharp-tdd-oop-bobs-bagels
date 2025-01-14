using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Inventory
    {
        private Dictionary<string, IProduct> _products;


        public Inventory()
        {
            _products = new Dictionary<string, IProduct>();
        }
        
        public void AddProduct(string key, IProduct product)

        {
            _products[key] = product;
        }

        public Dictionary<string, IProduct> Products => _products;

    }
}