using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public enum CoffeType { Black, White, Capuccino, Latte };
    public class Coffee : Product
    {
        public CoffeType _coffee;

        Dictionary<CoffeType, (double price, string SKU)> coffeToInfo = new Dictionary<CoffeType, (double price, string SKU)>() 
        {
            { CoffeType.Black, (0.99d, "COFB") },
            { CoffeType.Black, (1.19d, "COFW") },
            { CoffeType.Black, (1.29d, "COFC") },
            { CoffeType.Black, (1.29d, "COFL") }
        };

        public Coffee(CoffeType coffee) 
        {
            _coffee = coffee;
            price = coffeToInfo[coffee].price;
            SKU = coffeToInfo[coffee].SKU;
        }

        public override double GetPrice() { return price; }
    }

    /*
    public class Black : Coffee { public Black() { SKU = "COFB"; price = 0.99d; } }
    public class White : Coffee { public White() { SKU = "COFW"; price = 1.19d; } }
    public class Capuccino : Coffee { public Capuccino() { SKU = "COFC"; price = 1.29d; } }
    public class Latte : Coffee { public Latte() { SKU = "COFL"; price = 1.29d; } } */
}