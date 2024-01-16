using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class Filling
    {
        string _SKUName { get; }
        float _price;

        public Filling(string SKU, float price) 
        {
            _SKUName = SKU;
            _price = price;
        }

        public float GetPrice() 
        { 
            throw new NotImplementedException();
        }
    }
}
