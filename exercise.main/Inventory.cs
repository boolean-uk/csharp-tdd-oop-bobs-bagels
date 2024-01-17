using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
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
        private Dictionary<string, int> _stockCount = new Dictionary<string, int>();
        public Inventory()
        {
           PopulateDictionaries();
        }

        public void PopulateDictionaries()
        {
            for (int i = 0; i < _SKU.Length; i++)
            {
                _stockCount.Add(_SKU[i], 3);
                Prices.Add(_SKU[i], _Price[i]);
                Variants.Add(_SKU[i], _Variant[i]);
             };
            for(int j = 0; j < _SKUFillings.Length; j++)
            {
                _stockCount.Add(_SKUFillings[j], 3);
                Fillings.Add(_SKUFillings[j], _VariantFilling[j]);
            };
           
        }

        public void restockInventory(int newNumber, string sku)
        {
                _stockCount[sku] = newNumber;
        }
          
        public void restockInventory()
        {
            foreach(string key in _stockCount.Keys){
                _stockCount[key] = 3;
            }
        }

        public void removeSoldItems(List<Product> soldItems)
        {
            foreach (Product product in soldItems)
            {
                _stockCount[product.SKU] -= 1;
                foreach(Filling filling in product.Fillings)
                {
                    _stockCount[filling.SKU] -= 1;
                }
            }
        }
        public KeyValuePair<int,bool> checkInventory(string sku)
        {
            KeyValuePair<int, bool> Result;
            if (_stockCount.ContainsKey(sku))
            {
                int numInStock = _stockCount[sku];
                Result = new KeyValuePair<int, bool>(_stockCount[sku], true);
            }
            else { Result = new KeyValuePair<int, bool> (0, false); }


            return Result;
        }



        public Dictionary<string,int> stockCount { get { return _stockCount; } }
  

    }

    
}
