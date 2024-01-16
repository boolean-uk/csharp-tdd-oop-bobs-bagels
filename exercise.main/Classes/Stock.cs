using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class Stock
    {

        public static List<(string SKU, double price, Name name, string variant)> Items { get; } = new()
        {
            ("BGLO", 0.49, Name.Bagel, "Onion"),
            ("BGLP", 0.39, Name.Bagel, "Plain"),
            ("BGLE", 0.49, Name.Bagel, "Everything"),
            ("BGLS", 0.49, Name.Bagel, "Sesame"),
            ("COFB", 0.99, Name.Coffee, "Black"),
            ("COFW", 1.19, Name.Coffee, "White"),
            ("COFC", 1.29, Name.Coffee, "Cappuccino"),
            ("COFL", 1.29, Name.Coffee, "Latte"),
            ("FILB", 0.12, Name.Filling, "Bacon"),
            ("FILE", 0.12, Name.Filling, "Egg"),
            ("FILC", 0.12, Name.Filling, "Cheese"),
            ("FILX", 0.12, Name.Filling, "Cream Cheese"),
            ("FILS", 0.12, Name.Filling, "Smoked Salmon"),
            ("FILH", 0.12, Name.Filling, "Ham")
        };



    }
}
