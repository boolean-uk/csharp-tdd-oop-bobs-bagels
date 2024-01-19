using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using exercise.main.Inventory;


namespace exercise.main.Inventory
{

    public class BobsInventory
    {

        //List of all items in Bobs stock
        public static List<(string _SKU, double _price, Type _type, string _variant)> Inventory { get; }
                 = new List<(string _SKU, double _price, Type _type, string _variant)>()
                 {
                     ("BGLO", 0.49, Type.Bagel, "Onion"),
                     ("BGLP", 0.39, Type.Bagel, "Plain"),
                     ("BGLE", 0.49, Type.Bagel, "Everything"),
                     ("BGLS", 0.49, Type.Bagel, "Sesame"),
                     ("COFB", 0.99, Type.Coffee, "Black"),
                     ("COFW", 1.19, Type.Coffee, "White"),
                     ("COFC", 1.29, Type.Coffee, "Cappuccino"),
                     ("COFL", 1.29, Type.Coffee, "Latte"),
                     ("FILB", 0.12, Type.Filling, "Bacon"),
                     ("FILE", 0.12, Type.Filling, "Egg"),
                     ("FILC", 0.12, Type.Filling, "Cheese"),
                     ("FILX", 0.12, Type.Filling, "Cream Cheese"),
                     ("FILS", 0.12, Type.Filling, "Smoked Salmon"),
                     ("FILH", 0.12, Type.Filling, "Ham")
                 };
        

        
    }
}
