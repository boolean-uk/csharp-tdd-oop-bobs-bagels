using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public abstract class Product
    {
        internal double price { get; set; }
        public string SKU { get; set; }

        public abstract double GetPrice();
    }

}
