﻿namespace exercise.main
{
    public abstract class Item
    {
        public abstract string Name { get; set; }
        public abstract double Price { get; set; }
        public abstract string Sku { get; set; }
        public abstract string Type { get; set; }

        public double GetPrice()
        {
            return Price;
        }
    }
}
