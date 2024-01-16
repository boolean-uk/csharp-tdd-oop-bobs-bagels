using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public static class Inventory
    {
        private static readonly Dictionary<string, float> coffeePrices;
        private static readonly Dictionary<string, float> bagelPrices;
        private static readonly Dictionary<string, float> fillingPrices;
        static Inventory()
        {
            Dictionary<string, float> coffeePrices = new Dictionary<string, float>();
            coffeePrices.Add("COFB", 0.99f);
            coffeePrices.Add("COFW", 1.19f);
            coffeePrices.Add("COFC", 1.29f);
            coffeePrices.Add("COFL", 1.29f);

            Dictionary<string, float> bagelPrices = new Dictionary<string, float>();
            bagelPrices.Add("BGLO", 0.49f);
            bagelPrices.Add("BGLP", 0.39f);
            bagelPrices.Add("BGLE", 0.49f);
            bagelPrices.Add("BGLS", 0.49f);

            Dictionary<string, float> fillingPrices = new Dictionary<string, float>();
            fillingPrices.Add("FILB", 0.12f);
            fillingPrices.Add("FILE", 0.12f);
            fillingPrices.Add("FILC", 0.12f);
            fillingPrices.Add("FILX", 0.12f);
            fillingPrices.Add("FILS", 0.12f);
            fillingPrices.Add("FILH", 0.12f);
        }
        public static float GetCoffePrice(string SKU) 
        {
            throw new NotImplementedException();
        }
        public static float GetBagelPrice(string SKU)
        {
            throw new NotImplementedException();
        }
        public static float GetFillingPrice(string SKU)
        {
            throw new NotImplementedException();
        }
    }
}
