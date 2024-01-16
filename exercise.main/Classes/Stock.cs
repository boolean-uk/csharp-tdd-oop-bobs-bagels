using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class Stock
    {
        List<(string SKU, double Price, string Name, string Variant)> items = new List<(string, double, string, string)>
        {
            ("BGLO", 0.49, "Bagel", "Onion"),
            ("BGLP", 0.39, "Bagel", "Plain"),
            ("BGLE", 0.49, "Bagel", "Everything"),
            ("BGLS", 0.49, "Bagel", "Sesame"),
            ("COFB", 0.99, "Coffee", "Black"),
            ("COFW", 1.19, "Coffee", "White"),
            ("COFC", 1.29, "Coffee", "Cappuccino"),
            ("COFL", 1.29, "Coffee", "Latte"),
            ("FILB", 0.12, "Filling", "Bacon"),
            ("FILE", 0.12, "Filling", "Egg"),
            ("FILC", 0.12, "Filling", "Cheese"),
            ("FILX", 0.12, "Filling", "Cream Cheese"),
            ("FILS", 0.12, "Filling", "Smoked Salmon"),
            ("FILH", 0.12, "Filling", "Ham")
        };



    }
}
