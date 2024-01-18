using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Item
    {
        private string _SKU;
        private float _price;
        private string _type;
        private string _variant;
        private string _name;
        public Item(string SKU, float price, string type, string variant)
        {
            _SKU = SKU;
            _price = price;
            _type = type;
            _variant = variant;
            _name = _variant + " " + _type;

        }
    }
}
