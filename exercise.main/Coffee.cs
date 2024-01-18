using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Coffee : IProduct
    {
        public string Sku { get; set; }
        public decimal Price { get; set; }
    }
}