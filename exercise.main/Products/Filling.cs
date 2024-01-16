using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class Filling
    {
        public string SKUName { get; }
        float _price;

        public Filling(string SKU)
        {
            if (IsValid(SKU))
            SKUName = SKU;
        }

        public bool IsValid(string SKU) 
        {
            throw new NotImplementedException();
        }

        public float GetPrice() 
        { 
            throw new NotImplementedException();
        }
    }
}
