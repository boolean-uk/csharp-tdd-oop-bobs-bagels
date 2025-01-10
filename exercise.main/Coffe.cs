using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Coffe : Product
    {
        public Coffe(double price, string variant) 
        {
            _price = price;
            _name = "Coffe";
            _variant = variant;
        }
    }
}
