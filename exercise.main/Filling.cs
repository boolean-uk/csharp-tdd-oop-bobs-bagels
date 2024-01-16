using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Filling
    {
        Dictionary<string, int> fillings;

        public Filling() 
        {
            fillings = new Dictionary<string, int>();
            fillings.Add("Cola", 20);
            fillings.Add("Mayonaise", 30);
            fillings.Add("Jelly", 15);
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
