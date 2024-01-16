using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Core
{
    public abstract class Ware : Product
    {
        public Ware(string sku, double price, string variant) : base(sku, price, variant)
        {

        }
    }
}
