using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using item.main;
using inventory.main;
using System.Reflection.Emit;
using bagel.main;
using System.Collections;

namespace basket.main
{
    //private Dicitonary to find items in Inventory List

    public class Basket
    {
        public List<Item> basketItems = new List<Item>();
       // private Inventory _inventory;
        private int _capacity = 5;
        private double _totalPrice = 0;
        private double _bagelDiscount6 = 2.49;
        private double _bagelDiscount12 = 3.99;

        /*
        public Basket(int basketCapacity, Inventory inventory)
        {
            _items = new List<Item>();
            _inventory = inventory;
            basketItems = new List<Item>();

            // set _capacity to given basketCapacity new Basket(5) in Test [SetUp]
            _capacity = basketCapacity;
        }
        */
        public bool ItemInStock(string sku)
        {
            Inventory inventory = new Inventory();
            sku = sku.ToUpper();
            if (inventory.Stock.ContainsKey(sku))
            {
                Item item = inventory.Stock[sku];
                Console.WriteLine($"Your {item.Variant} {item.Name}is in stock!");
                return true;
            }
            Console.WriteLine($"Item does not excist in stock!");
            return false;
        }
        public bool AddItemToBasket(string sku)
        {
            Inventory inventory = new Inventory();
            // check if sku exists in inventory's Stock Dictionary
            if (ItemInStock(sku) == true)
            {
                Item item = inventory.Stock[sku];
                basketItems.Add(item);
                // if exists get the matching sku - Item object from the inventory's stong using sku as a keyvalue
                // print message of which item and which variant is added to your order to see if right.
                Console.WriteLine($"- item {sku}: {item.Name} {item.Variant} is added to your order.");
                return true;
            }
            Console.WriteLine($"{sku} is not added to your basket");
            return false;
        }

        public bool RemoveItem(string sku)
        {
            if (basketItems.Exists(item => item.Sku == sku))
            {
                Item item = basketItems.Where(item => item.Sku == sku).First();
                basketItems.Remove(item);
                Console.WriteLine($"{item.Name} {item.Variant} is removed from your order.");
                return true;
            }
            return false;
        }

        public bool FullBasket(int capacity)
        {
            if (_capacity >= capacity)
            {
                Console.WriteLine("Maximum basket Capacity is reached!");
                return true;
            }
            Console.WriteLine("Your item is added!");
            return false;
        }

        public double TotalPrice()
        {
            // set initial value of totalCosts to 0;
            double totalCosts = 0;
            foreach (Item item in basketItems)
            {
                Console.WriteLine($"{item.Name}: {item.Price}");
                totalCosts += item.Price;
            }
            // print the total price to the console.
            Console.WriteLine($"Total Price: €{totalCosts:F2}");
            return Math.Round(totalCosts, 2);
        }

        public double DiscountPrice()
        {
            int discountBagels6 = basketItems.Count(item => item is Bagel && item.Variant == "Onion" | item.Variant == "Everything");
            int discountBagels12 = basketItems.Count(item => item is Bagel && item.Variant == "Plain");

            if (discountBagels6 == 6 )
            {
                _totalPrice = _bagelDiscount6;
                Console.WriteLine($"You're 6 bagel discount price is: €{_bagelDiscount6}.");
            }
            else if (discountBagels12 == 12)
            {
               _totalPrice = _bagelDiscount12;
               Console.WriteLine($"You're 12 bagel discount price is: €{_bagelDiscount12}.");
            }
            return _totalPrice;
        }
    }
}
