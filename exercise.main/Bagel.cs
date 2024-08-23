using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : Item
    {
        private string _filling = "";
        public Bagel(string sku, double price, string name, string variant, string filling) : base(sku, price, name, variant)
        {
            Sku = sku;
            Price = price;
            Name = name;
            Variant = variant;
            Filling = filling;
        }

        public string Filling { get => _filling; set => _filling = value; }
        
    }
}
