using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class BobsBagel
    {
        private int _basketCapacity;
        public int BasketCapasity
        {
            get => _basketCapacity;
        }

        public BobsBagel(int basketCapacity)
        {
            _basketCapacity = basketCapacity;
        }

        public void ChangeBasketCapasity(int newCapacity)
        {
            _basketCapacity = newCapacity;
        }

        public Basket NewBasket()
        {
            return new Basket(_basketCapacity);
        }
    }
}