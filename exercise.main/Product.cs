using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public abstract class Product
    {
        public double _price;
        public string _name;
        public string _variant;
        
        public double GetPrice() { return _price; }
        
        public string GetVariant() { return _variant; }
    }
}
