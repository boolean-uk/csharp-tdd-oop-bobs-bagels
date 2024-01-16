using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Filling
    {
        Dictionary<string, float> fillings;

        public Filling() 
        {
            fillings = new Dictionary<string, float>();
            fillings.Add("Bacon", 0.12f);
            fillings.Add("Egg", 0.12f);
            fillings.Add("Cheese", 0.12f);
            fillings.Add("Cream Cheese", 0.12f);
            fillings.Add("Smoked Salmon", 0.12f);
            fillings.Add("Ham", 0.12f);
        }

        public string AllFillings()
        {
            string fillingList = "";

            for (int i = 0; i < fillings.Count(); i++)
            {
                if (i > 0)
                    fillingList += ", ";

                fillingList += fillings.ElementAt(i).Key;
            }

            return fillingList;
        }

        public string FillingCosts()
        {
            string fillingList = "";

            for (int i = 0; i < fillings.Count(); i++)
            {
                if (i > 0)
                    fillingList += ", ";

                fillingList += fillings.ElementAt(i).Key;
                fillingList += ":";
                fillingList += fillings.ElementAt(i).Value.ToString();
            }

            return fillingList;
        }

    }
}
