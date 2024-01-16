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

        public Basket Basket { get { return _basket; } }
        public Basket GetBasketContent()
        {
            throw new NotImplementedException();
        }

        public void Order(Bagel bagel)
        {
            throw new NotImplementedException();
        }
    }
}
