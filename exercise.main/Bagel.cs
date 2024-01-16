using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace exercise.main
{
    public class Bagel
    {
        private string SKU;
        private float bagelCost;
        
        private string fillingName;
        private float fillingCost;
        private Dictionary<string, float> prices = new Dictionary<string, float>();

        public Bagel(string SKU, float cost, string fillingName = "", float fillingCost = 0) 
        {
            if (prices.ContainsKey(SKU))
            {
                for (int i = 0; i < prices.Count(); i++)
                {
                    if (prices.ElementAt(i).Key == SKU)
                        this.bagelCost = prices.ElementAt(i).Value;
                }
            }
            else
            {
                prices.Add(SKU, cost);
                this.bagelCost = cost;
            }

            this.SKU = SKU;
            this.fillingName = fillingName;
            this.fillingCost = fillingCost;
        }

        public float CostOfBagel(string bagelType)
        {
            return prices[bagelType];
        }
        
        public string GetBagelType()
        {
            return SKU;
        }

        public float GetBagelCost()
        {
            return bagelCost;
        }

        public string GetFillingName()
        {
            return fillingName;
        }

        public float GetFillingCost()
        {
            return fillingCost;
        }
    }
}
