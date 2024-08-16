using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public struct Base //The base of a product
    {
        public string key;
        public float price;
        public string name;
        public string variant;

        public Base(string key, float price, string name, string variant)
        {
            this.key = key;
            this.price = price;
            this.name = name;
            this.variant = variant;
        }
    }
}
