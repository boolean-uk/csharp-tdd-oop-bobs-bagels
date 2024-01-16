using exercise.main.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Customer
    {
        private readonly Basket _basket;

        public Customer()
        {
            _basket = new Basket();
        }
        public Basket Basket { get { return _basket; } }
        public void Order(IFood food)
        {
            _basket.Add(food);
        }
    }
}
