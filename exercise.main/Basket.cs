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
        private int _total = 0;
        // Define properties
        public List<Product> _basket = new List<Product>();

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
            _basket.Remove(product);
            return true;

        }

        public int getPrice(Product product)
        {
            throw new NotImplementedException();
        }

        public int getTotalPrice()
        {
            throw new NotImplementedException();
        }

        public bool setNewCapacity(int newCapacity)
        {

            throw new NotImplementedException();
        }

        public List<Product> getBasket()
        {
            return _basket;
        }

        public int capacity { get { return _capacity; } }

    }
}
