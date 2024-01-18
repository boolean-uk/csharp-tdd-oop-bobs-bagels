using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Customer
    {
        private Basket _basket;
        public Customer() {
            _basket = new Basket();
        }

        public Basket basket { get => _basket; }
    }
}
