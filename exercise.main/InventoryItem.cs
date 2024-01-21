using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class InventoryItem
    {
        private string _product;
        private double _price;
        private string _name;
        private string _variant;

        public InventoryItem(string product, double price, string name, string variant)
        {
            _product = product;
            _price = price;
            _name = name;
            _variant = variant;
        }

        public InventoryItem() { }
        
        public List<InventoryItem> Inventory { get; set; }

        public string Product { get { return _product; } set { _product = value; } }
        public double Price { get { return _price; } set { _price = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Variant { get { return _variant; } set { _variant = value; } }
    }
}
