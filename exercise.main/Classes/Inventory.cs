using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class Inventory
    {
        private List<Product> _products;
        public Inventory() 
        {
            _products = new List<Product>();
        }

        public void Add(Product product) { }

        public void Remove(Product product) { }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(string SKU)
        {
            throw new NotImplementedException();
        }

        public int GetStock(string SKU)
        {
            throw new NotImplementedException();
        }
    }
}
