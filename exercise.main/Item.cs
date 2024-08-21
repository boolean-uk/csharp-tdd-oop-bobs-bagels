using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Item
    {
        public string id {  get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string variant { get; set; }

        public Item() { }
        public Item(string id, string name, double price, string variant)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.variant = variant;
        }
    }
}
