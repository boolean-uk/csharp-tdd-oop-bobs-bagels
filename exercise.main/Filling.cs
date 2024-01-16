using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Filling
    {
        private string _SKU;
        private double _price;
        private string _variant;

        private Dictionary<string, string> _SKUDict = new Dictionary<string, string>() 
        {
            {"FILB" , "Bacon"}, {"FILE" , "Egg"}, {"FILC" , "Cheese"}, {"FILX" , "Cream Cheese"},
            {"FILS" , "Smoked Salmon"}, {"FILH" , "Ham"}
        };

        public Filling(string SKU)
        {
            if (!_SKUDict.ContainsKey(SKU))
            {
                throw new Exception("Filling not in stock");
            }

            _variant = _SKUDict[SKU];
            _SKU = SKU;
            _price = 0.12;
        }

        public string SKU { get => _SKU; set => _SKU = value; }
        public double Price { get => _price; set => _price = value; }
        public string Variant { get => _variant; set => _variant = value; }
    }
}