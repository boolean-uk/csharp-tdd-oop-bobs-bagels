using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel
    {
        private string bagelType;
        private int bagelCost;
        
        private string fillingName;
        private int fillingCost;
        private Dictionary<string, int> prices = new Dictionary<string, int>();

        public Bagel(string bagelType, int cost, string fillingName = "", int fillingCost = 0) 
        {            
            for (int i = 0; i < prices.Count(); i++)
            {
                if (prices.ContainsKey(bagelType))
                    return;
            }
            prices.Add(bagelType, cost);

            this.bagelType = bagelType;
            this.bagelCost = cost;

            this.fillingName = fillingName;
            this.fillingCost = fillingCost;
        }

        public int CostOfBagel(string bagelType)
        {
            return prices[bagelType];
        }
        
        public string GetBagelType()
        {
            return bagelType;
        }

        public int GetBagelCost()
        {
            return bagelCost;
        }

        public string GetFillingName()
        {
            return fillingName;
        }

        public int GetFillingCost()
        {
            return fillingCost;
        }
    }
}
