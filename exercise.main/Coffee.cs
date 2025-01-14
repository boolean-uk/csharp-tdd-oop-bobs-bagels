using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Coffee : Product
    {
        public string name;
        public decimal price;
        public string type;
        public string SKU;
        public Coffee(string SKU, decimal price, string name, string type) {
            this.SKU = SKU;
            this.price = price;
            this.name = name;
            this.type = type;
        }
        public override string Name { get { return name; } }    

        public override string Type { get { return type; } }    

        public override decimal Price {  get { return price; } }

        public override string Sku {  get { return SKU; } } 
    }
}
