using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public enum CoffeeType { Black, White, Capuccino, Latte };
    public class Coffee : Product
    {
        public CoffeeType _coffee;

        public Dictionary<CoffeeType, (double price, string SKU)> coffeToInfo { get; } = new Dictionary<CoffeeType, (double price, string SKU)>()
        {
            { CoffeeType.Black, (0.99d, "COFB") },
            { CoffeeType.White, (1.19d, "COFW") },
            { CoffeeType.Capuccino, (1.29d, "COFC") },
            { CoffeeType.Latte, (1.29d, "COFL") }
        };

        public Coffee(CoffeeType coffee) 
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