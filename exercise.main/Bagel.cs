using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : Product
    {
        private int _id;
        public Bagel(double price, string variant) 
        {
            _id = ++_id;
            _price = price;
            _name = "Bagel";
            _variant = variant;
        }

    }
}
