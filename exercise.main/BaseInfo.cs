using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public struct Base //The base of a product
    {
        public string key; //Example: BGLO
        public float price; //Example: 0.49f
        public string name; //Example: Bagel
        public string variant; //Example: Onion

        public Base(string key, float price, string name, string variant) //Construct the base product
        {
            this.key = key;
            this.price = price;
            this.name = name;
            this.variant = variant;
        }
    }
}
