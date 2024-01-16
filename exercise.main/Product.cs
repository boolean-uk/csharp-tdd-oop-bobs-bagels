using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Product
    {

        public string _sku;
        public double _price;
        public string _name;
        public string _variant;
        public List<Product> _products;


        public Product(string SKU, double Price, string Name, string Variant) 
        {
            _products = new List<Product>();
            _sku = SKU;
            _price = Price;
            _name = Name;
            _variant = Variant;
        }

        


        public List<Product> Products { get {  return _products; } }
        

        public void addProductToList(Product product) 
        {
            _products.Add(product);
        }

        

    }
}
