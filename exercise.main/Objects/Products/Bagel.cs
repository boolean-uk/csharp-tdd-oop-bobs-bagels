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
        public override string Name { get => "Bagel"; }

        public Bagel(string sku, double price, string variant, Filling filling = null) 
        : base(sku, price, variant)
        {
            Attachment = filling;
        }
    }
}
