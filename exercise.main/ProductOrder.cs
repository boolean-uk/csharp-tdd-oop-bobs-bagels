﻿using System;
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
        private double _discount = 0;

        public ProductOrder(Product prod, int amt)
        {
            _product = prod;
            _amount = amt;
            SetDiscount();
        }

        private void SetDiscount()
        {
            int div = _amount / 12;
            int mod = _amount % 12;
            double newDiscount = 0;
            newDiscount = div * (12 * _product.Price - 3.99);
            if (mod >= 6) { newDiscount += 6 * _product.Price - 2.49; }
            _discount = Math.Round(newDiscount, 2, MidpointRounding.AwayFromZero);
        }

        public Product Product { get { return _product; } }

        public double Discount { get { return _discount; } }

        public int Amount { get { return _amount; }
                            set { _amount = value; if (_product.GetType() == typeof(Bagel)) SetDiscount(); } }
    }
}
