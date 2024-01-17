using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Coffee : Product
    {
        private Dictionary<string, double> _priceDict = new Dictionary<string, double>()
        {
            {"COFB", 0.99}, {"COFW", 1.19}, {"COFC", 1.29}, {"COFL", 1.29}
        };
        private Dictionary<string, string> _SKUDict = new Dictionary<string, string>()
        {
            {"COFB", "Black"}, {"COFW", "White"}, {"COFC" , "Capuccino"}, {"COFL" , "Latte"}
        };
        private string _SKU;
        private double _price;
        private string _variant;
        private Filling? _filling;

        public Coffee(string SKU)
        {
            if (!_SKUDict.ContainsKey(SKU))
            {
                throw new Exception("Coffee is not in stock");
            }
            _variant = _SKUDict[SKU];
            _SKU = SKU;
            _price = _priceDict[SKU];
            _filling = null;
        }

        public double Price { get => _price; set => _price = value; }

        public string SKU { get => _SKU; set => _SKU = value; }

        public string Variant { get => _variant; set => _variant = value; }
        public Filling Filling { get => _filling; }
    }
}