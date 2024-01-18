using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop.main
{
    public class Filling : Item
    {

        public Filling(string sku, double price)
        : base(sku, "Filling", "", price)
        {
        }
    }
}
