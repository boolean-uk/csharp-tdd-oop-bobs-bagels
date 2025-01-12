using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

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
                return "Basket is full. Item was not added to basket.";
            }

            if (!_inventory.Products.ContainsKey(product.SKU))
            {
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

        public double TotalCost()
        {

            double total = 0;
            foreach (Product product in _order)
            {
                if (product is Bagel bagel)
                {
                    total += bagel.Price;
                    Console.WriteLine($"{bagel.Name} Price: {bagel.Price} $");
                    foreach (var filling in bagel.Fillings)
                    {
                        total += filling.Price;
                        Console.WriteLine($"{filling.Name} Price: {filling.Price} $");
                    }
                }
                else
                {
                    total += product.Price;
                    Console.WriteLine($"{product.SKU} Price: {product.Price} $");
                }
            }
            Console.WriteLine($"Total Price: {total} $");
            return total;

        }

    }
}