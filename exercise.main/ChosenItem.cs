using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public static class ChosenItem
    {
        //public Bagel ChosenBagel;
        //public Coffee ChosenCoffee;
        public static Bagel AddFillings(Bagel thisBagel, List<string> fillings) 
        {
            Bagel filledBagel = thisBagel;
            return filledBagel;
        }
        public static Filling ChooseFillings(string sku, double price, string name, string variant)
        {
            Filling thisFilling = new Filling(sku, price, name, variant);
            return thisFilling;
        }

        public static Bagel MakeBagel(string sku, double price, string name, string variant, string filling)
        {
            Bagel newBagel = new Bagel(sku, price, name, variant, filling);
            return newBagel;
        }

        public static string MakeCoffee() 
        {
            return "Nothing";
        }

        
    }
}
