using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Coffee : Item
    {
        public Coffee(string type)
        {
            SKU = type;
            name = "Coffee";
            switch (type)
            {
                case "COFB":
                    variant = "Black";
                    price = 0.99f;
                    break;
                case "COFW":
                    variant = "White";
                    price = 1.19f;
                    break;
                case "COFC":
                    variant = "Capuccino";
                    price = 1.29f;
                    break;
                case "COFL":
                    variant = "Latte";
                    price = 1.29f;
                    break;
                default: 
                    variant = "";
                    price = 0.99f;
                    break;
            }
        }
    }
}
