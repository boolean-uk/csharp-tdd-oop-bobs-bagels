using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public abstract class Product
    {
        public required string Sku { get; set; }
        public required decimal Price { get; set; }
        public required string Name { get; set; }
        public required string Variant { get; set; }

        public string GetSKU() {  return Sku; }

        public decimal GetPrice() { return Price; }

        public string GetName() { return Name; }

        public string GetVariant() { return Variant; }

    }
}
