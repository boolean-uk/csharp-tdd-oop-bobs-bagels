using exercise.main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Items
{
    public class Coffee : IItem, IDiscountable
    {
        public string id { get; set; }
        public double price { get; set; }
        public string name { get; set; }
        public string variant { get; set; }
        public int discount { get; set; }

        public Coffee() { }

        public Coffee(string id, double price, string name, string variant)
        {
            this.id = id;
            this.price = price;
            this.name = name;
            this.variant = variant;
        }
    }
}
