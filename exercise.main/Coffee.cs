using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Coffee : Product
    {
        public Coffee(string sku, double price, ProductType type, string variant) : base(sku, price, type, variant)
        {
        }
    }
}
