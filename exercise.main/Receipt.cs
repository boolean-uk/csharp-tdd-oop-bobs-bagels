using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        private float totalCost;
        private Dictionary<string, float> priceList;
        public Receipt() 
        {
            priceList = new Dictionary<string, float>();
            priceList.Clear();
            priceList.Add("BGLO", 0.49f);
            priceList.Add("BGLP", 0.39f);
            priceList.Add("BGLE", 0.49f);
            priceList.Add("BGLS", 0.49f);
            priceList.Add("COFB", 0.99f);
            priceList.Add("COFW", 1.19f);
            priceList.Add("COFC", 1.29f);
            priceList.Add("COFL", 0.29f);
            priceList.Add("FILB", 0.12f);
            priceList.Add("FILE", 0.12f);
            priceList.Add("FILC", 0.12f);
            priceList.Add("FILX", 0.12f);
            priceList.Add("FILS", 0.12f);
            priceList.Add("FILH", 0.12f);
        }
        public void addCost(string SKU)
        {
            totalCost += priceList[SKU];
        }
        public string printTotal()
        {
            string output = $"Your current total comes to: {totalCost.ToString()}";
            return output;
        }
    }
}
