using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Class_Items
{
    public class Filling : Product
    {
        public Filling(string sku, double price, ProdType type, string varaiant) : base(sku, price, type, varaiant)
        {
        }
    }
}
