using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public abstract class Item
    {
        // properties
        public string SKU { get; set; }
        public double Cost { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        // constructor
        public Item() { }

        public Item(string name) 
        { 
            this.Name = name; 
        }

        public Item(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        public Item(string sku, double cost, string name, string type)
        {
            this.SKU = sku;
            this.Cost = cost;
            this.Name = name;
            this.Type = type;
        }

        // method
        public static double GetItemCost(Item item) { return item.Cost; }

    }
}
