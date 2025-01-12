using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Inventory
    {
        private Dictionary<string, Product> _products;


        public Inventory()
        {
            _products = new Dictionary<string, Product>();
        }
        
        public void AddProduct(string key, Product product)

        {
            _products[key] = product;
        }

        public Dictionary<string, Product> Products => _products;

        public T? OrderProduct<T>(string key) where T : Product
        {
            if (_products.TryGetValue(key, out Product? product))
            {
                if (product is T typedProduct)
                {
                    return typedProduct; 
                }
                else
                {
                    Console.WriteLine($"Product is not {typeof(T).Name}");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Product not found.");
                return null; 
            }
        }

    }
}