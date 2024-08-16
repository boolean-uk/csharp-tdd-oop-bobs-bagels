using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Customer : Person
    {
        private Basket _basket;

        public Customer(string firstName, string lastName)
            : base(firstName, lastName)
        { 
            _basket = null; //if you dont have a basket no bagels for you
        }

        public void grabBasket()
        {
            _basket = new Basket();
        }

        public bool addProduct(string SKU) { _basket.addProduct(); return false; }
        public bool removeProduct(string SKU) { return false; }

        public List<Product> checkBasketContent() { return _basket.getProductsInBasket(); }
    }
}
