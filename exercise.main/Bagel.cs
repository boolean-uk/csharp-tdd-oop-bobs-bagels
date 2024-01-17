using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Bagel : IProduct
    {
        private string _SKU;
        private double _price;
        private string _variant;

        private Dictionary<string, string> _SKUDict = new Dictionary<string, string>()
        {
            {"BGLO", "Onion"}, {"BGLP", "Plain"}, {"BGLE", "Everything"}, {"BGLS" , "Sesame"}
        };

        private Dictionary<string, double> _priceDict = new Dictionary<string, double>()
        {
            {"BGLO", 0.49}, {"BGLP", 0.39}, {"BGLE", 0.49}, {"BGLS", 0.49}
        };

        public Bagel(string SKU)
        {
            if (!_SKUDict.ContainsKey(SKU))
            {
                throw new Exception("Bagel is not in stock");
            }

            _SKU = SKU;
            _price = _priceDict[SKU];
            _variant = _SKUDict[SKU];
        }

        public string SKU { get => _SKU; set => _SKU = value; }
        public double Price { get => _price; set => _price = value; }
        public string Variant { get => _variant; set => _variant = value; }
    }
}