using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    
        /**
        public string SKU { get; }
        public decimal Price { get; }
        public string Name { get; }
        public string Type { get; }

        public Coffee(string sku, decimal price, string name, string type)
        {
            SKU = sku;
            Price = price;
            Name = name;
            Type = type;
        }
        **/
        public class Coffee(string SKU) : Product(SKU)
        {
        }
    
}
