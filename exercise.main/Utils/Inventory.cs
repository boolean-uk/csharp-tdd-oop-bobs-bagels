﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public static class Inventory
    {
        private static Dictionary<string, float> coffeePrices = new Dictionary<string, float>
        {
            { "COFB", 0.99f },
            { "COFW", 1.19f },
            { "COFC", 1.29f },
            { "COFL", 1.29f },
        };
        private static Dictionary<string, float> bagelPrices = new Dictionary<string, float>
        {
            { "BGLO", 0.49f },
            { "BGLP", 0.39f},
            { "BGLE", 0.49f},
            { "BGLS", 0.49f},
        };
        private static Dictionary<string, float> fillingPrices = new Dictionary<string, float>
        {
            { "FILB", 0.12f },
            {"FILE", 0.12f},
            {"FILC", 0.12f},
            {"FILX", 0.12f},
            {"FILS", 0.12f},
            {"FILH", 0.12f},
        };

        public static float GetCoffePrice(string SKU)
        {
            return coffeePrices.Where(t => t.Key == SKU).FirstOrDefault(new KeyValuePair<string, float>("NA", 0f)).Value;
        }
        public static float GetBagelPrice(string SKU)
        {
            return bagelPrices.Where(t => t.Key == SKU).FirstOrDefault(new KeyValuePair<string, float>("NA", 0f)).Value;
        }
        public static float GetFillingPrice(string SKU)
        {
            float res = fillingPrices.Where(t => t.Key == SKU).FirstOrDefault(new KeyValuePair<string, float>("NA", 0f)).Value;
            return res;
        }

        /// <summary>
        /// Retrieve a list of every registered SKU for all IProduct integrators
        /// </summary>
        /// <returns>List<string> - A ascending sorted list (sorted by basePrice) of strings</returns>
        public static List<string> GetValidProductSKUs() 
        {
            List<(string Key, float Value)> combinedProducts = bagelPrices.Select(p => (p.Key, p.Value)).Concat(coffeePrices.Select(p => (p.Key, p.Value))).OrderBy(p => p.Value).ToList();
            return combinedProducts.Select(p => p.Key).ToList();
        }

        public static Dictionary<string, float> GetValidProductsInformation()
        {
            Dictionary<string, float> combinedProducts = new Dictionary<string, float>();
            combinedProducts = bagelPrices.Concat(coffeePrices).ToDictionary(x => x.Key, x => x.Value);
            return combinedProducts;
        }

        public static Dictionary<string, float> GetValidFillingInformation()
        {
            return new Dictionary<string, float>(fillingPrices);
        }
    }
}
