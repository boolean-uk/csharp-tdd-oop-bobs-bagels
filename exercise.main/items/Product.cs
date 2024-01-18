using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.items
{
    public class Product
    {
        public Coffee? Coffee { get; set; }
        public Bagel? Bagel { get; set; }

        public Product(Coffee? coffee)
        {
            Coffee = coffee;
        }

        public Product(Bagel bagel)
        {
            Bagel = bagel;
        }

        public string ToString()
        {
            if (Bagel != null) return Bagel.ToString();
            if (Coffee != null) return Coffee.ToString();
            return "";
        }

        public double Cost()
        {
            if (Bagel != null) return Bagel.Cost();
            if (Coffee != null) return Coffee.Cost();
            return 0d;
        }
    }
}
