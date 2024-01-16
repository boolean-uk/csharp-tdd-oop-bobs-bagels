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

        public Bagel(string bagelType, int cost, string fillingName = "", int fillingCost = 0) 
        {
            this.bagelType = bagelType;
            this.bagelCost = cost;

            this.fillingName = fillingName;
            this.fillingCost = fillingCost;
        }

        public int CostOfBagel(string bagelType)
        {
            return 0;
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
