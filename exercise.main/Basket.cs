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

        public Basket() { 
            _manager = new Manager();
            _products = new List<Product>();
            _capacity = _manager.getCurrentBasketSize();
        }

        public int getCapacity() { return _capacity; }

        public List<Product> getProductsInBasket() { return _products; }

        public bool addProduct(Product product) { _products.Add(product); return true; }

        public bool removeProduct(string SKU) { _products.Remove(_products.FirstOrDefault(product => product.SKU == SKU)); return true; }
    }
}
