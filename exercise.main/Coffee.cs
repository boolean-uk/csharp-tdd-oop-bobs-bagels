using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public enum CoffeeType
    {
        Black,
        White,
        Cappuccino,
        Latte
    }

    public class Coffee
    {
        public Coffee(CoffeeType type = CoffeeType.Black)
        {
            mCoffeeType = type;
        }
        public CoffeeType mCoffeeType { get; set; }
    }
}
