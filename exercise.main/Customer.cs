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

        public bool recieveProductInBasket(Product product) //TODO: check for basket overflow
        {
            if (product != null && _basket != null && _basket.getProductsInBasket().Count < _basket.getCapacity())
            {
                _basket.addProduct(product);
                return true;
            }
            return false;
        }

        public bool addProduct(string SKU) { return _bagelStore.getManager().getProduct(SKU, this);} //done
        public bool removeProduct(string SKU) 
        {
            return _basket.getProductsInBasket().Remove(_basket.getProductsInBasket().FirstOrDefault(product => product.SKU == SKU));
        }

        public List<Product> checkBasketContent() { return _basket.getProductsInBasket(); }

        public BagelStore GetBagelStore() { return _bagelStore; }
        //add lamdas to experiment
        //public bool addProductCool => (string SKU) { return _bagelStore.getManager().getProduct(SKU, this); } //done


    }
}
