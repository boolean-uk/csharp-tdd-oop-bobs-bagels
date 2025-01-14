using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Classes.Products;

namespace exercise.main.Classes
{
    public class Basket
    {
        private List<Product> products;
        public int capacity;

        public Basket()
        {
            products = new List<Product>();
            capacity = 5;
        }

        public void AddProduct(string sku, Inventory inventory)
        {
            Product? product = inventory.GetProduct(sku.ToUpper());
            if (product == null)
            {
                Console.WriteLine($"Product not found!");
            }
            else if (IsFull())
            {
                Console.WriteLine($"Basket is full!");
            }
            else
            {
                Console.WriteLine($"{product.Variant} {product.Name} added to basket!");
                products.Add(product);
            }
        }

        public void RemoveProduct(string sku)
        {
            Product? product = GetProduct(sku.ToUpper());
            if (product == null)
            {
                Console.WriteLine($"Product not found in basket!");
            }
            else
            {
                Console.WriteLine($"{product.Variant} {product.Name} removed from basket!");
                products.Remove(product);
            }
        }

        public void Clear()
        {
            Console.WriteLine($"Cleared {products.Count} products from basket!");
            products.Clear();
        }

        public bool IsFull()
        {
            if (products.Count >= capacity)
            {
                Console.WriteLine("Basket is full!");
                return true;
            }
            else
            {
                Console.WriteLine("Basket is not full!");
                return false;
            }
        }

        public Product? GetProduct(string sku)
        {
            Product? foundProduct = null;
            products.ForEach(product => { if (product.Sku == sku) { foundProduct = product; } });
            return foundProduct;
        }

        public List<Product> GetProducts() { return products; }

        public decimal TotalCost()
        {
            decimal totalCost = products.Sum(p => p.Price);
            Console.WriteLine($"Total cost of products: " + totalCost);
            return totalCost;
        }

        public void ChangeCapacity(int newCapacity) { capacity = newCapacity; }

        public int GetProductCount(string sku)
        {
            int count = products.Count(product => product.Sku == sku);
            return count;
        }
    }
}
