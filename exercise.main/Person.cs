using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    abstract class Person : Iperson
    {
        public void ChangeBasketCapacity(int capacity)
        {
            return; //not authorized to change basket capacity
        }

        public Basket GetBasket()
        {
            throw new NotImplementedException();
        }

        public int ItemNotPresent()
        {
            throw new NotImplementedException();
        }
    }
}
