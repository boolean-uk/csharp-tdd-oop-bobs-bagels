using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private int _capacity;
        private List<Product> _products;
        private BagelStore _bagelStore;

        public Basket(BagelStore bagelStore) { //inject current bagelstore?
            _products = new List<Product>();
            _bagelStore = bagelStore;
            _capacity = _bagelStore.getManager().getCurrentBasketSize();
        }

        public int getCapacity() { return _capacity; }

        public List<Product> getProductsInBasket() { return _products; }

        public bool addProduct(Product product) { 
            _products.Add(product);
            foreach (var item in _products)
            {
                if (item == product) { return true; }
            }
            return false;
        } //change so it does not always add true

        //public BagelStore GetBagelStore() { return _bagelStore; } //hide this?

        public bool removeProduct(string SKU) { return _products.Remove(_products.FirstOrDefault(product => product.SKU == SKU));}

        public void productNotInBasketWarning() { Console.WriteLine("This is your basket speaking. The product you are trying to remove does not exist, please cease you action!"); }
    }
}
