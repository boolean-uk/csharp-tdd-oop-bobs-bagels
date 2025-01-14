using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public abstract class Product
    {
        public abstract string Name { get; }
        public abstract string Type { get; }
        public abstract decimal Price{ get; }
        public abstract string Sku { get; }


    }
}
