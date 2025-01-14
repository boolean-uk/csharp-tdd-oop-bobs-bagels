using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Filling : Product
    {
        string SKU;
        decimal price;
        string type;
        string name;

        public Filling(string SKU,decimal price, string name,string type){ 
            this.SKU = SKU;
            this.price = price;
            this.type = type;
            this.name = name;
        }

        public override string Name { get { return name; } }

        public override string Type {  get { return type; } }   

        public override decimal Price {  get { return price; } }  

        public override string Sku {  get { return SKU; } } 
    }
}
