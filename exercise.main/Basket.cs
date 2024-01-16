using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        // Define field
        private int _capacity = 3; //Default = 3
        private double _total = 0;
        // Define properties
        public List<Product> _basket = new List<Product>();
        Dictionary<Product, List<Product>> _sandWiches = new Dictionary<Product, List<Product>>();

        public bool Add(Product product)
        {
            if (_basket.Count < _capacity)
            {
                _basket.Add(product);
                return true;
            }
            return false;
        }

        public bool Remove(Product product)
        {
            if (_basket.Contains(product))
            {
                _basket.Remove(product);
                return true;
            }
            return false;

        }

        public int getPrice(Product product)
        {
            throw new NotImplementedException();
        }

        public double getTotalPrice()
        {
            _total = _basket.Sum(product => product.getPrice());
            return _total;
        }

        public bool setNewCapacity(int newCapacity)
        {
            _capacity = newCapacity;
            return true;
        }

        public List<Product> getBasket()
        {
            return _basket;
        }

        public void MakeSandwich(Product product1, Product product5)
        {
            if (_basket.Contains(product1) && product1.name == "Bagel")
            {
                if (_sandWiches.ContainsKey(product1))
                {
                    if (Add(product5))
                    {
                        _sandWiches[product1].Add(product5);
                    }
                    else {
                        throw new Exception("Check the basket capacity");
                    }
                }
                else
                {
                    _sandWiches.Add(product1, new List<Product>() { product5 });
                }

            }
            else
            {
                throw new Exception("Need to by a bagel and add it to your basket first");
            }
        }

        public Dictionary<Product, List<Product>> getSandwich()
        {
            return _sandWiches;
        }

        public int capacity { get { return _capacity; } }

    }
}
