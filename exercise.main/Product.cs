using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Product : IProduct
    {
        private string _SKU;
        private double _price;
        private string _variant;

        private Dictionary<string, string> _SKUDict = new Dictionary<string, string>()
        {
            {"BGLO", "Onion"}, {"BGLP", "Plain"}, {"BGLE", "Everything"}, {"BGLS" , "Sesame"},
            { "FILB" , "Bacon"}, {"FILE" , "Egg"}, {"FILC" , "Cheese"}, { "FILX" , "Cream Cheese"},
            { "FILS" , "Smoked Salmon"}, { "FILH" , "Ham"}, {"COFB", "Black"}, {"COFW", "White"}, 
            {"COFC" , "Capuccino"}, {"COFL" , "Latte"}
        };

        private Dictionary<string, double> _priceDict = new Dictionary<string, double>()
        {
            {"BGLO", 0.49}, {"BGLP", 0.39}, {"BGLE", 0.49}, {"BGLS", 0.49},
            {"COFB", 0.99}, {"COFW", 1.19}, {"COFC", 1.29}, {"COFL", 1.29},
            {"FILB" , 0.12 }, {"FILE" , 0.12 }, {"FILC" , 0.12 }, {"FILX" , 0.12 },
            {"FILS" , 0.12 }, {"FILH" , 0.12 }
        };

        public Product(string SKU)
        {
            if (!_SKUDict.ContainsKey(SKU))
            {
                throw new Exception("Item is not in stock");
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
