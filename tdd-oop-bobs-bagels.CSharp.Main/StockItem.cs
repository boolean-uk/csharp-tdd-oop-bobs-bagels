using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class StockItem
    {
        private SKUEnum _sku;
        private double _price;
        private string _name;
        private string _variant;

        public StockItem(SKUEnum sku, double price, string name, string variant)
        {
            _sku = sku;
            _price = price;
            _name = name;
            _variant = variant;
        }

        public SKUEnum SKU { get => _sku; }
        public double Price { get => _price; }
        public string Name { get => _name; }
        public string Variant { get => _variant; }
    }
}