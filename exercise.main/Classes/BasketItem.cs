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
        private double _price;
        private double _discount;

        public BasketItem(Product product, int amount, double price)
        {
            _amount = amount;
            _product = product;
            _price = price;
            _discount = 0.0;
        }

        public Product Product => _product;

        public int Amount
        {
            get => _amount;
            set { _amount = value; }
        }

        public double Price
        {
            get => _price;
            set { _price = value; }
        }

        public double Discount
        {
            get => _discount;
            set { _discount = value; }
        }
    }
}
