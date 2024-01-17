using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public abstract class Product
    {
        public double price { get; set; }
        public string SKU { get; set; }

        public abstract int itemNr { get; }

        public abstract double GetPrice();
    }

}
