using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public enum CoffeeType { Black = 4, White = 5, Capuccino = 6, Latte = 7 };
    public class Coffee : Product
    {
        public CoffeeType coffeeType;

        public Dictionary<CoffeeType, (double price, string SKU)> coffeToInfo { get; } = 
            new Dictionary<CoffeeType, (double price, string SKU)>()
        {
            { CoffeeType.Black, (0.99d, "COFB") },
            { CoffeeType.White, (1.19d, "COFW") },
            { CoffeeType.Capuccino, (1.29d, "COFC") },
            { CoffeeType.Latte, (1.29d, "COFL") }
        };

        public Coffee(CoffeeType coffee) 
        {
            coffeeType = coffee;
            price = coffeToInfo[coffee].price;
            SKU = coffeToInfo[coffee].SKU;
        }

        public override double GetPrice() { return price; }

        public override int itemNr { get => (int) coffeeType; }

        public override string name() => coffeeType.ToString();
    }
}