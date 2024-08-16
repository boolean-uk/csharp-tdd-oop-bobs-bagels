using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Item
    {
        public string sku {  get; set; }
        public double price { get; set; }
        public string name { get; set; }
        public string variant { get; set; }

        public Item() { }

        public Item(string sku, double price, string name, string variant) {

            sku = sku;
            price = price;
            name = name;
            variant = variant;
        
        }

    }
   
    }

