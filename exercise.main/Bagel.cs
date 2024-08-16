using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel
    {
        public string SKU { get; set; }
        public int Price { get;set; }
        public string Variant {  get; set; }
        
        public List<Filling> fillings { get; set; } = new List<Filling>();

        public Bagel(string SKU, int price, string variant) 
        {
            this.SKU = SKU;
            this.Price = price;
            this.Variant = variant;
        }
    }
}
