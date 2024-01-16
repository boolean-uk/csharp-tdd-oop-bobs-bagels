using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Core;

namespace exercise.main.Objects.Products
{
    public class Filling : Product
    {
        public Filling(string sku, double price, string variant) : base(sku, price, variant)
        {

        }
    }
}
