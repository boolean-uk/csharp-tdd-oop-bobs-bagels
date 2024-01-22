using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class Coffee : Product,InventoryProduct
    {
        public Coffee(string sku, string variant, double price)
        {
            Name = "Coffee";
            Sku = sku;
            Variant = variant;
            Price = price;
        }
        public Coffee(string sku)
        {
            Name = "Coffee";
            getItemMembers(sku);
        }
      
    }

}
