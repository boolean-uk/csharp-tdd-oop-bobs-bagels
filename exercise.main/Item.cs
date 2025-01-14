﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static exercise.main.Bagel;

namespace exercise.main
{
    public abstract class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Variant { get; set; }

        public Item(string id, string name, string variant, double price)
        {
            Id = id;
            Name = name;
            Variant = variant;
            Price = price;

        }

        public abstract double getPrice();
        public abstract void addFilling(string order);
        public abstract void removeFilling(string order);
        public abstract List<Filling> getFillings();   

        public string getItemToString()
        {
            return $"{Id}, {Name}, {Variant}, {Price}";
        }
    }

    
    
}
