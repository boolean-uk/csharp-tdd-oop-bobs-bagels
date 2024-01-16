using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Coffee
    {
        private Dictionary<string, double> _priceDict = new Dictionary<string, double>()
        {
            {"Black", 0.99}, {"White", 1.19}, {"Capuccino", 1.29}, {"Latte", 1.29}
        };
        private Dictionary<string, string> _SKUDict = new Dictionary<string, string>()
        {
            {"Black", "COFB"}, {"White", "COFW"}, {"Capuccino", "COFC"}, {"Latte", "COFL"}
        };
        private string _SKU;
        private double _price;
        private string _variant;

        public Coffee(string name)
        {
            _variant = name;
            _SKU = _SKUDict[name];
            _price = _priceDict[name];


        }

        public double Price { get => _price; set => _price = value; }

        public string SKU { get => _SKU; set => _SKU = value; }

        public string Variant { get => _variant; set => _variant = value; }
    }
}