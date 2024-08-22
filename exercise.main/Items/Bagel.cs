using exercise.main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Items
{
    public class Bagel : IItem, IDiscountable
    {
        public string id { get; set; }
        public double price { get; set; }
        public string name { get; set; }
        public string variant { get; set; }

        public ICollection<Filling> fillings { get; set; }
        public int discount { get; set; }

        public Bagel() { }

        public Bagel(string id, double price, string name, string variant) 
        {
            this.id = id;
            this.price = price;
            this.name = name;
            this.variant = variant;
        }
    }
}
