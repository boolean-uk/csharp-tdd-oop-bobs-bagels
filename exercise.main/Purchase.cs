using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    //Extension task 2
    public class Purchase
    {
        public Purchase()
        {
        }

        public Purchase(string variant, string name, double price)
        {
            this.Variant = variant;
            this.Name = name;
            this.Quantity = 1;
            this.Price = price;
         
        }

        public Purchase(string variant, string name,int qty, double price)
        {
            this.Variant = variant;
            this.Name = name;
            this.Quantity = qty;
            this.Price = price;

        }

        public string Variant { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
