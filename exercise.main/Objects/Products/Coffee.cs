using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Core;

namespace exercise.main.Objects.Products
{
    public class Coffee : Ware
    {
        public Coffee(string sku, double price, string variant) : base(sku, price, variant)
        {

        }
    }
}
