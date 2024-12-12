using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Discount
    {
        public static double SixBagels { get { return 2.49d; } }

        public static double TwelveBagels { get { return 3.99d; } }

        public static double CoffeeAndBagel { get { return 1.25d; } }


        public string SKU { get; set; }
        public string Name { get; set; } 
        public string Variant { get; set; }
        public double Price { get; set; }
        public string SpecialOffers { get; set; }
    }
}
