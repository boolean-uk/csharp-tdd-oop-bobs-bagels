using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Customer : Person
    {
        private Basket _basket;
        private BagelStore _bagelStore = new BagelStore();
        private Reciept _receipt;

        public Customer(string firstName, string lastName)
            : base(firstName, lastName)
        { 
            _basket = null; //if you dont have a basket no bagels for you
        }

        public void grabBasket()
        {
            _basket = new Basket(_bagelStore);
            //_bagelStore = _basket.GetBagelStore();
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
            if (_basket.getProductsInBasket().Count > 0 && _basket.getProductsInBasket().FirstOrDefault(item => item.SKU == SKU) != null) 
            {
                return _basket.getProductsInBasket().Remove(_basket.getProductsInBasket().FirstOrDefault(product => product.SKU == SKU));
            }
            _basket.productNotInBasketWarning();
            return false;
        }

        public List<Product> checkBasketContent() { return _basket.getProductsInBasket(); }

        public BagelStore GetBagelStore() { return _bagelStore; }

        public int checkBasketCapacity() { return _basket.getCapacity(); }

        public List<Product> checkMenu() { return _bagelStore.getManager().getMenu(); }

        public float getTotalCost() //without discounts
        {
            float totalCost = 0f;
            foreach (var item in _basket.getProductsInBasket())
            {
                totalCost += item.price;
            }
            return totalCost;
        }

        public float checkout() //with discounts
        {
            float totalCost = _bagelStore.getManager().checkout(_basket);
            //printReceipt();
            return totalCost = (float)Math.Round(totalCost,2);
        }

        public void printReceipt() //non discount receipt
        {
            _receipt = new();
            _receipt.print(_basket.getProductsInBasket());
        }

        //add lamdas to experiment
        //public bool addProductCool => (string SKU) { return _bagelStore.getManager().getProduct(SKU, this); } //done


    }
}
