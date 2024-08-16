using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private Manager _manager;
        private int _capacity;
        private List<Product> _products;
        private BagelStore _bagelStore = new BagelStore();

        public Basket() { 
            _manager = _bagelStore.getManager();
            _products = new List<Product>();
            _capacity = _manager.getCurrentBasketSize();
        }

        public int getCapacity() { return _capacity; }

        public List<Product> getProductsInBasket() { return _products; }

        public bool addProduct(Product product) { _products.Add(product); return true; }

        public bool removeProduct(string SKU) { _products.Remove(_products.FirstOrDefault(product => product.SKU == SKU)); return true; }

        public void basketOverflowWarning() { Console.WriteLine("This is your basket speaking. I am at max capacity!"); }
        public void productNotInBasketWarning() { Console.WriteLine("This is your basket speaking. The product you are trying to remove does not exist, please cease you action!"); }
    }
}
