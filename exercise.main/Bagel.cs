using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : IProduct, IFillable
    {
        public string Sku {get; set; }
        public decimal Price { get; set; } 
        public List<Tuple<string, decimal>> _fillings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}