using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace exercise.main
{
    public class Item
    {
        public float _price;
        public string _type;
        public string _variant;
        //private List<Item> subItems;
        
        public Item(float price, string type, string variant)
        {
            _price = price;
            _type = type;
            _variant = variant;
        }
    }
}
