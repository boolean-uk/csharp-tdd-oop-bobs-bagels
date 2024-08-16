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
        private BagelStore _bagelStore = new BagelStore();

        public Customer(string firstName, string lastName)
            : base(firstName, lastName)
        { 
            _basket = null; //if you dont have a basket no bagels for you
        }

        public void grabBasket()
        {
            _basket = new Basket();
        }

        public bool recieveProductInBasket(Product product)
        {
            if (product != null)
            {
                _basket.addProduct(product);
                return true;
            }
            return false;
        }

        public bool addProduct(string SKU) { return _bagelStore.getManager().getProduct(SKU, this);} //done
        public bool removeProduct(string SKU) 
        {
            Product product = _bagelStore.getManager().getProductReference(SKU);
            if (product != null)
            {
                _basket.getProductsInBasket().Remove(product); //might not remove intended object, might have to go with if SKU == SKU remove or something
                return true;
            }
            return false;
        }

        public List<Product> checkBasketContent() { return _basket.getProductsInBasket(); }
    }
}
