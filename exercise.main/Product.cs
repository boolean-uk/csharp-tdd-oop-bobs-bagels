using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Product
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Variant { get; set; }
    }

    public class Bagel : Product 
    {
        public string DoughType { get; set; }
        public List<string> Fillings { get; set; }

        
        public Bagel()
        {
            Fillings = new List<string>();
        }
    }
    public class Coffee : Product 
    {
        public string CoffeeType { get; set; }
            
    }

    public class Filling : Product 
    {
        public string FillingType { get; set;}
        public List<string> Fillings { get; }

    }

   
}