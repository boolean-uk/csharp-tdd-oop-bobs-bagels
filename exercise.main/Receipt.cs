using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        private float total;
        private Basket basket;

        public Receipt(Basket basket)
        {
            basket = basket;
            
        }

        public float totalPrice()
        {
            return 0.0f;
        }


    }
}
