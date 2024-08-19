using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class ProductOrder
    {
        private Product _product;
        private int _amount;

        public ProductOrder(Product prod, int amt)
        {
            _product = prod;
            _amount = amt;
        }

        public Product Product { get { return _product; } }

        public int Amount { get { return _amount; } set { _amount = value; }



    }
}
