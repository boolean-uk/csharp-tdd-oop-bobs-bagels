using exercise.main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class Coffee : IProduct
    {
        public int ID { get; set; }
        public string SKU { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }

        public List<IAddition> Additions { get; set; } = new List<IAddition>();
        public Coffee(string SKU, double price, string name, string variant)
        {
            this.SKU = SKU;
            this.Price = price;
            this.Name = name;
            this.Variant = variant;
        }
    }
}
