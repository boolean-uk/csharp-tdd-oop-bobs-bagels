using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Product
    {
        private List<Product> _subProducts;
        public Product(string name, double price, string variant)
        {
            Price = price;
            Name = name;
            Variant = variant;
            _subProducts = new List<Product>();
        }

        public double Price { get; private set; }
        public string Name { get; private set; }
        public string Variant { get; private set; }

        public void AddSubProduct(string variant)
        {
            Product product = Inventory.skuToProduct[Inventory.variantToSku[variant]];
            _subProducts.Add(product);
            Price+=product.Price;

        }

        public double GetPrice()
        {
            return Price;
        }

        public List<Product> GetSubProducts()
        {
            return _subProducts;
        }
    }
}
