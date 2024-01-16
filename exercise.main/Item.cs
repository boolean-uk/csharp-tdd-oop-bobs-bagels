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
        private float _price;
        private string _type;
        private string _variant;
        private List<Item> subItems;
        
        public Item(float price, string type, string variant)
        {
            _price = price;
            _type = type;
            _variant = variant;
        }
    }
}
