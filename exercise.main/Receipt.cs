using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        private int _id;
        private Basket _relatedBasket;
        public Basket RelatedBasket {  get { return _relatedBasket; } }
        public int ID { get { return _id; } }

        public Receipt(Basket basket, int id)
        {
            _relatedBasket = basket;
            _id = id;
        }
    }
}
