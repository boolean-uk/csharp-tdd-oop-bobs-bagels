using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public abstract class Discount
    {
        public abstract bool IsDiscounted(IProduct product);
        public abstract decimal CalculateDiscount(IProduct product, int quantity, decimal originalPrice);
    }
}