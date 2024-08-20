using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{

    public abstract class Product
    {
        public Product() { }    
        public abstract string Name { get; }
        public abstract float Cost { get; }

        public abstract bool IsBagle { get; }

    }
}
