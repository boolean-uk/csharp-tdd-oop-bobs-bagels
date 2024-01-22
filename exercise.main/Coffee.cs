using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Coffee(string sku, double price, string variant) : Product(sku, price, "Coffee", variant)
    {
    }
}
