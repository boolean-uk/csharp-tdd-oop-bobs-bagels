using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Product
    {
        public string SKU { get; set; }
        public double Price { get;set; }

        public string Name { get; set; }
        public string Variant {  get; set; }
        
        //For bagels, before we get into inheritance
        //public List<Product> fillings { get; set; } = new List<Product>();

        public Product(string SKU, double price, string name, string variant) 
        {
            this.SKU = SKU;
            this.Price = price;
            this.Name = name;
            this.Variant = variant;
        }
    }
}
