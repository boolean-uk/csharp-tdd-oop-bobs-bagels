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
        COFW = 0,
        COFC = 0,
        COFL = 0,
        BGLO = 1,
        BGLP = 1,
        BGLE = 1,
        BGLS = 1,
        FILB = 2,
        FILE = 2,
        FILC = 2,
        FILX = 2,
        FILS = 2,
        FILH = 2,
    }

    public abstract class Product
    {
        public Product() { }
        public abstract string Name { get; }
        public abstract float Cost { get; }

        public abstract productType Type { get; }

    }
}
