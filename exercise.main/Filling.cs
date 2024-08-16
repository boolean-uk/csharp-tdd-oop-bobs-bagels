using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Filling : Item
    {
        private string _sku;
        private double _price;
        private string _name;
        private string _variant;

        public Filling(string sku, double price, string name, string variant)
        {
            this._sku = sku;
            this._price = price;
            this._name = name;
            this._variant = variant;
        }

        public int CheckItemCost()
        {
            return 0;
        }

        public string Sku { get => _sku; set => _sku = value; }
        public double Price { get => _price; set => _price = value; }
        public string Name { get => _name; set => _name = value; }
        public string Variant { get => _variant; set => _variant = value; }
    }
}
