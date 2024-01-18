using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop.main
{
    public class Coffee : Item
    {
        public Coffee(string sku, double price, string Category, string variant)
         : base(sku, "Coffee", "", price)
        {
        }
    }
}
