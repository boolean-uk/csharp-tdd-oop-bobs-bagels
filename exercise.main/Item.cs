using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public abstract class Item
    {
        private string id;
        private double price;

        public string Id { get { return id; } }
        public double Price { get { return price; } } 

        public Item(string id, double price)
        {
            this.id = id;
            this.price = price;
        }

        public abstract string getVariant();

        public abstract double getPrice();

    }

    
    
}
