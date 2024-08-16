using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Filling : IItem
    {
        public Filling(string sKU, double price, string name, string variant)
        {
            SKU = sKU;
            Price = price;
            Name = name;
            Variant = variant;
        }

        public string SKU { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Variant { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
