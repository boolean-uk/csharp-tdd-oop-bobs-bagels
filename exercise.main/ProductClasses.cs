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

    public class BagelCoffee : Product
    {
        public BagelCoffee(BagelShop shop, string sku, double price, string name, string variant) : base(shop, sku, price, name, variant) { }

        public override string ToString()
        {
            return $"Coffee & {base.Variant} {base.Name}";
        }

        public override bool IncreaseStock()
        {
            bool coffee = base.Shop.Category[base.Sku.Substring(0, 4)].IncreaseStock();
            bool bagel = base.Shop.Category[base.Sku.Substring(4, 4)].IncreaseStock();
            return true;
        }

        public override bool DecreaseStock()
        {
            bool coffee = base.Shop.Category[base.Sku.Substring(0, 4)].DecreaseStock();
            bool bagel = base.Shop.Category[base.Sku.Substring(4, 4)].DecreaseStock();
            if (bagel && coffee) return true;
            return false;
        }

    }
}
