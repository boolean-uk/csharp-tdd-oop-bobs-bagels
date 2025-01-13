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
        private readonly List<Product> _order;

        private int _capacity = 3;
        public List<Product> BasketOrder => _order;

        private Inventory _inventory;

        public int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }


        }
        public Basket(List<Product> order, Inventory inventory)
        {
            _order = order;
            _inventory = inventory;
        }

        public Basket(Inventory inventory)
        {
            _order = [];
            _inventory = inventory;
        }


        public string AddItem(Product product)
        {
            if (_order.Count >= _capacity)
            {
                Console.WriteLine("Basket is full. Item was not added to basket.");
                return "Basket is full. Item was not added to basket.";
            }

            if (!_inventory.Products.ContainsKey(product.SKU))
            {
                Console.WriteLine("Item is not in the inventory. Item was not added to basket.");
                return "Item is not in the inventory. Item was not added to basket.";
            }

            _order.Add(product);
            return $"{product.SKU} added to basket.";
        }

        public string RemoveItem(Product product)
        {
            if (_order.Contains(product))
            {
                _order.Remove(product);
                return "Item removed successfully";
            }
            else
            {
                return "Item does not exist in basket";
            }

        }

        public decimal Total { get { return _order.Sum(product => product.Price); } }
        public decimal TotalCost()
        {

            decimal total = 0;
            foreach (Product product in _order)
            {
                if (product is Bagel bagel)
                {
                    total += bagel.Price;
                    Console.WriteLine($"{bagel.Name} Price: {bagel.Price:F2} $");
                    foreach (var filling in bagel.Fillings)
                    {
                        total += filling.Price;
                        Console.WriteLine($"{filling.Name} Price: {filling.Price:F2} $");
                    }
                }
                else
                {
                    total += product.Price;
                    Console.WriteLine($"{product.SKU} Price: {product.Price} $");
                }
            }
            Console.WriteLine($"Total Price: {total:F2} $");
            return total;
        }


        public Dictionary<Product, int> ProductCount()
        {
            Dictionary<Product, int> productCount = new Dictionary<Product, int>();


            foreach (Product product in _order)
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

        public decimal ApplyDiscount()
        {

            var productCount = ProductCount();
            decimal totalPrice = 0;
            foreach (var keyValuePair in productCount)
            {
                if (keyValuePair.Key.SKU == "BGLO" || keyValuePair.Key.SKU == "BGLE")
                {
                    var originalPrice = keyValuePair.Value * keyValuePair.Key.Price;
                    int numberOfDiscounts = keyValuePair.Value / 6;
                    int remainder = keyValuePair.Value - numberOfDiscounts * 6;

                    decimal discountedPrice = numberOfDiscounts * 2.49m + remainder * 0.49m;

                    var discount = originalPrice - discountedPrice;

                    Console.WriteLine($"{keyValuePair.Key.Name} x{keyValuePair.Value} Original Price: {originalPrice:F2}");
                    Console.WriteLine($"Dicount: {discount:F2}");
                    Console.WriteLine($"Discounted Price: {discountedPrice:F2}");
                    totalPrice += discountedPrice;

                }
                if(keyValuePair.Key.SKU == "BGLP")
                {
                    var originalPrice = keyValuePair.Value * keyValuePair.Key.Price;
                    int numberOfDiscounts = keyValuePair.Value / 12;
                    int remainder = keyValuePair.Value - numberOfDiscounts * 12;

                    decimal discountedPrice = numberOfDiscounts * 3.99m + remainder * 0.39m;

                    var discount = originalPrice - discountedPrice;

                    Console.WriteLine($"{keyValuePair.Key.Name} x{keyValuePair.Value} Original Price: {originalPrice:F2}");
                    Console.WriteLine($"Dicount: {discount:F2}");
                    Console.WriteLine($"Discounted Price: {discountedPrice:F2}");
                    totalPrice += discountedPrice;
                }
            }
            Console.WriteLine($"Total price after discounts: {totalPrice:F2}");
            return totalPrice;
        }
    }
}