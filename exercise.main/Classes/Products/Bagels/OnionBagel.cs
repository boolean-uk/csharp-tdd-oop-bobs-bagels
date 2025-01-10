using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes.Products.Bagels
{
    public class OnionBagel : Bagel
    {
        public OnionBagel(string sku = "bglo", decimal price = 0.49M, string name = "bagel", string variant = "onion")
        {
            base.Sku = sku;
            base.Price = price;
            base.Name = name;
            base.Variant = variant;
        }
    }
}
