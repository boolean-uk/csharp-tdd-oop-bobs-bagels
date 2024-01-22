using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Inventory
{
    public class Filling : Item
    {
        public Filling(string sku, double price, Type type, string variant) : base(sku, price, type, variant)
        {
            
        }
    }
}
