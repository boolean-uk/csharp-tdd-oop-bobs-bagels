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
        private double _discount = 0;
        private Product? _coffee;
        private List<Product> _fillings = new List<Product>();

        public ProductOrder(Product prod, int amt)
        {
            _product = prod;
            _amount = amt;
            SetDiscount();
        }

        // Max 3 fillings per bagel...
        public bool AddFilling(Product filling)
        {
            if (_fillings.Count > 3) return false;
            _fillings.Add(filling);
            return true;
        }

        // Private helper method
        private void SetDiscount()
        {
            double newDiscount = 0;
            if (_product is Bagel)
            {
                int div = _amount / 12;
                int mod = _amount % 12;
                newDiscount = div * (12 * _product.Price - 3.99);
                if (mod >= 6) newDiscount += 6 * _product.Price - 2.49;
                _discount = Math.Round(newDiscount, 2, MidpointRounding.AwayFromZero);

                if (_coffee != null)
                {
                    // We only allow one of the discounts to be added, we will add the highest
                    // discount available
                    double coffeeDiscount = _amount * (_product.Price + _coffee.Price - 1.25);
                    if (coffeeDiscount > newDiscount) _discount = Math.Round(coffeeDiscount, 2, MidpointRounding.AwayFromZero);
                }
            }
        }

        // Private helper method
        private double CostOfItems()
        {
            double cost = _product.Price;

            if (_coffee != null)
            {
                cost += _coffee.Price;
            }
            foreach (var filling in _fillings)
            {
                cost += filling.Price;
            }

            return Math.Round(cost * _amount, 2, MidpointRounding.AwayFromZero);
        }

        public Product Product { get { return _product; } }

        public Product Coffee { get { return _coffee!; } set { _coffee = value; SetDiscount(); } }

        public List<Product> Fillings { get { return _fillings; } }

        public double Cost { get { return CostOfItems(); } }

        public double Discount { get { return _discount; } }

        public int Amount { get { return _amount; }
                            set { _amount = value; SetDiscount(); } }
    }
}
