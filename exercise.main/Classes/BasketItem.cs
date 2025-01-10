using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class BasketItem
    {
        private Product _product;
        private int _amount;

        public BasketItem(Product product, int amount)
        {
            _amount = amount;
            _product = product;
        }

        public Product Product => _product;

        public int Amount
        {
            get => _amount;
            set { _amount = value; }
        }
    }
}
