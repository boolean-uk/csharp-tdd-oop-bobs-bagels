using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public enum BagelType
    {
        Onion,
        Plain,
        Everything,
        Sesame
    }

    public enum BagelFilling
    {
        None,
        Bacon,
        Egg,
        Cheese,
        CreamCheese,
        SmokedSalmon,
        Ham
    }

    public class Bagel
    {
        public Bagel(BagelType type = BagelType.Plain, BagelFilling filling = BagelFilling.None)
        {
            mBagelType = type;
            mBagelFilling = filling;
        }
        public BagelType mBagelType { get; set; }

        public BagelFilling mBagelFilling { get; set; }
    }
}
