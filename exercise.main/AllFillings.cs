using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class AllFillings
    {
        List<Filling> fillings = new List<Filling>();
        public List<Filling> Fillings { get { return fillings; } }
        public void addFilling(string type)
        {
            Filling filling = new Filling(type);
            fillings.Add(filling);
        }
        public float TotalPrice()
        {
            float fillingPrice = 0;
            foreach (Filling item in fillings)
            {
                fillingPrice += item.Price;
            }
            return fillingPrice;
        }


        public override string ToString()
        {
            fillings.Sort();
            string result = "";
            foreach (Filling filling in fillings)
            {
                result += filling.SKU;
            }
            return result;
        }
    }
}
