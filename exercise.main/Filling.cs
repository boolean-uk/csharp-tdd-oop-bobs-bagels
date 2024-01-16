using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Filling : Product
    {
        public Filling(string sku, float price, ProductType type, string variant) : base(sku, price, type, variant)
        {
        }
    }
}
