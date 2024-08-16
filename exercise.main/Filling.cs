using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Filling : Item
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _sku;
        public string Sku
        {
            get { return _sku; }
            set { _sku = value; }
        }
        private string _name;
        public string Name
        {
            get => _name; set => _name = value;
        }
        private double _price;
        public double Price
        {
            get => _price; set => _price = value;
        }
        private string _variant;
        public string Variant
        {
            get => _variant; set => _variant = value;
        }

        public Filling(string sku, double price, string name, string variant)
        {
            this._sku = sku;
            this._name = name;
            this._price = price;
            this._variant = variant;
        }

    }
}
