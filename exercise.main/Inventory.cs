using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        private string[] _SKU = { "BGLO", "BGLP", "BGLE", "BGLS", "COFB", "COFW", "COFC", "COFL" };
        private string[] _SKUFillings ={"FILB", "FILE", "FILC", "FILX", "FILS", "FILH" };
        private double[] _Price = { 0.49, 0.39, 0.49, 0.49, 0.99, 1.19, 1.29, 1.29 };
        private string[] _ProductName = { "Bagel", "Coffe", "Filling", };
        private string[] _Variant = { "Onion", "Plain", "Everything", "Sesame", "Black", "White", "Cappucino", "Latte" };
        private string[] _VariantFilling = {"Bacon", "Egg", "Cheese", "Cream Cheese", "Smoked Salmon", "Ham" };
        public Dictionary<string, double> Prices = new Dictionary<string, double>();
        public Dictionary<string, string> Variants = new Dictionary<string, string>();
        public Dictionary<string, string> Fillings = new Dictionary<string, string>();
        public Inventory()
        {
            ProductList = new List<Product>();
            PopulateDictionaries();

        }

       
        public void PopulateDictionaries()
        {
            for (int i = 0; i < _SKU.Length; i++)
            {
                Prices.Add(_SKU[i], _Price[i]);
                Variants.Add(_SKU[i], _Variant[i]);
            };
            for(int j = 0; j < _SKUFillings.Length; j++)
            {
                Fillings.Add(_SKUFillings[j], _VariantFilling[j]);
            };
            
        }
        public List<Product> ProductList;


        public string[] SKU { get { return _SKU; } }
        public double[] Price { get { return _Price; } }
        public string[] ProductName { get { return _ProductName; } }
        public string[] BagelVariant { get { return _Variant; } }


    }

    
}
