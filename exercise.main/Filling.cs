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
            {"Bacon", "FILB"}, {"Egg", "FILE"}, {"Cheese", "FILC"}, {"Cream Cheese", "FILX"},
            {"Smoked Salmon", "FILS"}, {"Ham", "FILH"}
        };

        public Filling(string name)
        {
            if (!_SKUDict.ContainsKey(name))
            {
                throw new Exception("Filling not in stock");
            }

            _SKU = _SKUDict[name];
            _variant = name;
            _price = 0.12;
        }

        public string SKU { get => _SKU; set => _SKU = value; }
        public double Price { get => _price; set => _price = value; }
        public string Variant { get => _variant; set => _variant = value; }
    }
}