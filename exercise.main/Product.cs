using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public abstract class Product : IProduct
    {
        public string SKU { get; set; }
        public double Price { get; set; }
        public string Variant { get; set; }

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

            this.SKU = SKU;
            Price = _priceDict[SKU];
            Variant = _SKUDict[SKU];
        }
    }
}
