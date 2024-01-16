using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Bagel
    {
        private string _SKU;
        private double _price;
        private string _variant;
        private Filling? _filling;

        private Dictionary<string, string> _SKUDict = new Dictionary<string, string>()
        {
            {"Onion", "BGLO"}, {"Plain", "BGLP"}, {"Everything", "BGLE"}, {"Sesame", "BGLS"}
        };

        private Dictionary<string, double> _priceDict = new Dictionary<string, double>()
        {
            {"Onion", 0.49}, {"Plain", 0.39}, {"Everything", 0.49}, {"Sesame", 0.49}
        };

    public Bagel(string name)
        {
            _SKU = _SKUDict[name];
            _price = _priceDict[name];
            _variant = name;
            _filling = null;
        }

        public string SKU { get => _SKU; set => _SKU = value; }
        public double Price { get => _price; set => _price = value; }
        public string Variant { get => _variant; set => _variant = value; }
        public Filling Filling { get => _filling; }

        public void SetFilling(string filling)
        {
            _filling = new Filling(filling);
        }
    }
}