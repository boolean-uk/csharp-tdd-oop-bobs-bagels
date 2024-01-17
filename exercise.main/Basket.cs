using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<Product> _items;
        private int _capacity;

        public Basket()
        {
            _items = new List<Product>();
            _capacity = 10;
        }

        public string AddProduct(string product)
        {

            if (_items.Count >= _capacity)
            {
                return "Nope. Overencumbered.";
            }
            else if (!Inventory.variantToSku.ContainsKey(product))
            {
                return "Warning: The product is not available.";
            }
            else
            {
                _items.Add(Inventory.skuToProductFactory[Inventory.variantToSku[product]]());
                return "Product added to basket";
            }

        }

        public void ChangeCapacity(int v)
        {
            _capacity = v;
        }

        public List<Product> GetItems()
        {
            return _items;
        }

        public string RemoveProduct(string variant)
        {
            // Find the product with the matching variant
            var productToRemove = _items.FirstOrDefault(p => p.Variant == variant);

            if (productToRemove == null)
            {
                return "No such product to remove.";
            }
            else
            {
                _items.Remove(productToRemove);
                return "Product removed from basket";
            }
        }

        public double TotalPrice()
        {
            return _items.Sum(product => product.Price);
        }

        
    }

}

