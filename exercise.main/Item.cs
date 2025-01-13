using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace exercise.main
{
    public abstract class Item
    {
        public string SKU { get; set; }
        public string name { get; set; }
        public double cost { get; set; }
        public string variant { get; set; } 
        public bool isDiscounted { get; set; }

        public Item(string SKU, string name, double cost, string variant)
        {
            this.SKU = SKU;
            this.name = name;
            this.cost = cost;
            this.variant = variant;
            this.isDiscounted = false;
        }
        public Type getInstance()
        {
            return GetType();
        }

    }
}