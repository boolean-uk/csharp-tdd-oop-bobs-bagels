using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : Product
    {
        public Bagel(BagelShop shop, string sku, double price, string name, string variant) : base(shop, sku, price, name, variant) { }
    }

    public class Coffee : Product
    {
        public Coffee(BagelShop shop, string sku, double price, string name, string variant) : base(shop, sku, price, name, variant) { }
    }

    public class Filling : Product
    {
        public Filling(BagelShop shop, string sku, double price, string name, string variant) : base(shop, sku, price, name, variant) { }
    }
}
