using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Core;

namespace exercise.main.Objects.Products
{
    public class Bagel : Ware
    {
        protected Filling _filling = null;

        public Bagel(string sku, double price, string variant, Filling filling = null) 
        : base(sku, price, variant)
        {
            _filling = filling;
        }


        public override double GetPrice()
        {
            if (_filling == null)
                return _price;

            return _price + _filling.GetPrice();
        }
    }
}
