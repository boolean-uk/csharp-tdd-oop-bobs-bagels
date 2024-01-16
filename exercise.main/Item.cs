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
        private string _SKU;
        private string _type;
        private string _variant;
        private List<Item> subItems;
        private Dictionary<string, float> priceList = new Dictionary<string, float>();
        
        public Item(string SKU, float price, string type, string variant)
        {
            _SKU = SKU;
            _price = price;
            _type = type;
            _variant = variant;
        }
    }
}
