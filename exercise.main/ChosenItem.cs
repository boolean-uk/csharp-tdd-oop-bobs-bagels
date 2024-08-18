using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public static class ChosenItem
    {
        //public Bagel ChosenBagel;
        //public Coffee ChosenCoffee;

        public static Bagel MakeBagel(string sku, double price, string name, string variant)
        {
            Bagel newBagel = new Bagel(sku, price, name, variant);
            return newBagel;
        }

        public static string MakeCoffee() 
        {
            return "Nothing";
        }

        
    }
}
