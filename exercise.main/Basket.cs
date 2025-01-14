using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using exercise.main.Products;

namespace exercise.main
{
    public class Basket
    {
        private readonly List<IProduct> _basketProducts;

        private int _capacity = 20;

        private Inventory _inventory;

        public List<IProduct> BasketProducts {  get { return _basketProducts; } }

        public int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }

        public Basket(Inventory inventory)
        {
            _basketProducts = [];
            _inventory = inventory;
        }

        public decimal Total { get { return _basketProducts.Sum(product => product.Price); } }

        public bool AddItem(IProduct product)
        {
            if (_basketProducts.Count >= _capacity)
            {
                Console.WriteLine("Basket is full. Item was not added to basket.");
                return false;
            }

            if (!_inventory.Products.ContainsKey(product.SKU))
            {
                Console.WriteLine("Item is not in the inventory. Item was not added to basket.");
                return false;
            }

            if (product is Bagel b && b.Fillings.Count > 0)
            {
                _basketProducts.Add(b);
                foreach (var filling in b.Fillings)
                {
                    _basketProducts.Add(filling);
                }
                return true;
            }

            _basketProducts.Add(product);
            return true;
        }

        public bool RemoveItem(IProduct product)
        {
            if (_basketProducts.Contains(product))
            {
                _basketProducts.Remove(product);
                Console.WriteLine("Item removed successfully");
                return true;
            }
            else
            {
                Console.WriteLine("Item does not exist in basket");
                return false;
            }
        }

        public Dictionary<IProduct, int> ProductCount()
        {
            Dictionary<IProduct, int> productCount = new Dictionary<IProduct, int>();


            foreach (IProduct product in _basketProducts)
            {
                if (productCount.ContainsKey(product))
                {
                    productCount[product]++;
                }
                else
                {
                    productCount.Add(product, 1);
                }
            }
            return productCount;
        }
    }
}