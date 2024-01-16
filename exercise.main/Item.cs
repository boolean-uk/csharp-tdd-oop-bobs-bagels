using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    internal class Item
    {
        public string _sku {  get; set; }
        public string _name { get; set; }
        public string _variant { get; set; }
        public float _price { get; set; }
        public List<Item> filling { get; set; }

        public Item(string sku, string name, string variant, float price)
        {
            _sku = sku;
            _name = name;
            _variant = variant;
            _price = price;
            filling = new List<Item>();

        }
    }
}
