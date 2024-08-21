using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.products
{
    public enum productType
    {
        COFB = 0,
        COFW = 1,
        COFC = 2,
        COFL = 3,

        BGLO = 10,
        BGLP = 11,
        BGLE = 12,
        BGLS = 13,

        FILB = 21,
        FILE = 22,
        FILC = 23,
        FILX = 24,
        FILS = 25,
        FILH = 26,
    }

    public abstract class Product
    {
        public Product() { }
        public abstract string Name { get; }
        public abstract float Cost { get; }

        public abstract productType Type { get; }

    }
}
