using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Filling : Product
    {
        public Filling(double price, string variant) 
        {
            _price = price;
            _name = "Filling";
            _variant = variant;
        }
    }
}
