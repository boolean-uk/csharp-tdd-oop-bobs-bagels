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
            this.basket = basket;
            
        }

        public float totalPrice()
        {

            float total = 0;  // Initialize total outside the loop

            foreach (Item item in basket.GetBasketContent())
            {
                total += item.Price;
            }

            return total;
        }


    }
}
