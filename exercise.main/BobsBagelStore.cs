﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Twilio.TwiML.Messaging;

namespace exercise.main
{
    public class BobsBagelStore
    {
        private int _receiptIDs = 0;
        private List<Item> _inventory;
        private List<Basket> _baskets;
        private List<Receipt> _receipts;
        private List<Order> _orders;

        public BobsBagelStore()
        {
            _inventory = new List<Item>();
            _baskets = new List<Basket>();
            _receipts = new List<Receipt>();
            _orders = new List<Order>();
        }

        public bool AddReceipt(Basket basket, Receipt newReceipt)
        {
            if (basket == null)
            {
                return false;
            }

            _receiptIDs++;

            if (_baskets.Where(x => x == basket).Count() == 0)
            {
                AddBasket(basket);
            }

            newReceipt.ID = _receiptIDs;

            _receipts.Add(newReceipt);
            return true;
        }

        public bool AddBasket(Basket basket)
        {
            if (basket == null) return false;
            if (_baskets.Contains(basket)) return false;
            _baskets.Add(basket);
            return true;
        }

        public Item? GetItem(string sku)
        {
            return _inventory.Find(item => item.SKU == sku);
        }

        public void StockUpInventory()
        {
            _inventory = new List<Item>();
            _inventory.Add(new Item("BGLO", 0.49f, "Bagel", "Onion"));
            _inventory.Add(new Item("BGLP", 0.39f, "Bagel", "Plain"));
            _inventory.Add(new Item("BGLE", 0.49f, "Bagel", "Everything"));
            _inventory.Add(new Item("BGLS", 0.49f, "Bagel", "Sesame"));
            _inventory.Add(new Item("COFB", 0.99f, "Coffee", "Black"));
            _inventory.Add(new Item("COFW", 1.19f, "Coffee", "White"));
            _inventory.Add(new Item("COFC", 1.29f, "Coffee", "Capuccino"));
            _inventory.Add(new Item("COFL", 1.29f, "Coffee", "Latte"));
            _inventory.Add(new Item("FILB", 0.12f, "Filling", "Bacon"));
            _inventory.Add(new Item("FILE", 0.12f, "Filling", "Egg"));
            _inventory.Add(new Item("FILC", 0.12f, "Filling", "Cheese"));
            _inventory.Add(new Item("FILX", 0.12f, "Filling", "Cream Cheese"));
            _inventory.Add(new Item("FILS", 0.12f, "Filling", "Smoked Salmon"));
            _inventory.Add(new Item("FILH", 0.12f, "Filling", "Ham"));
        }

        public string ViewInventory()
        {
            StringBuilder message = new StringBuilder();

            if (_inventory.Count == 0)
            {
                message.Append("No items in inventory!");
                Console.Write(message.ToString());
                return message.ToString();
            }

            message.Append("| SKU  | Price |   Name  |    Variant    |\n");
            message.Append("|------|-------|---------|---------------|\n");

            foreach (Item item in _inventory)
            {
                message.Append($"| {item.SKU} ");
                message.Append(string.Format("| {0:C2} ", item.Price.ToString("C", new CultureInfo("en-GB"))));

                message.Append(string.Format("| {0} ", item.Name.Length > 8 ? item.Name.Substring(0, 8) : item.Name));
                int spacesAmount = 7 - item.Name.Length;
                for (int i = 0; i < spacesAmount; i++) { message.Append(" "); }

                message.Append(string.Format("| {0} ", item.Variant.Length > 13 ? item.Variant.Substring(0, 13) : item.Variant));
                spacesAmount = 13 - item.Variant.Length;
                for (int i = 0; i < spacesAmount; i++) { message.Append(" "); }

                message.Append("|\n");
            }
            message.Append("\n\n\n");
            Console.Write(message.ToString());
            return message.ToString();
        }

        public float ViewProfits()
        {
            float profits = 0;
            foreach (Receipt receipt in _receipts)
            {
                foreach (Item item in receipt.Items.Keys)
                {
                    profits += item.Price * receipt.Items[item];
                }
            }
            Console.WriteLine($"Todays profits came to a total of {profits}£");
            return profits;
        }

        public string MakeOrder(Receipt receipt)
        {
            Order order = new Order(receipt);
            _orders.Add(order);
            StringBuilder orderMessage = new StringBuilder();

            orderMessage.Append("       ~~~ Order Created ~~~\n\n");
            orderMessage.Append($"Items Ordered at {order.OrderDate}\n".PadRight(5));
            orderMessage.Append($"Estimated delivery time is {order.DeliveryTime} minutes\n");
            orderMessage.Append($"at {order.DeliveryDate.Hour}:{order.DeliveryDate.Minute}\n".PadLeft(5));
            orderMessage.Append($"\nOrder receipt is\n");

            Console.WriteLine(orderMessage.ToString());

            orderMessage.Insert(0, receipt.PrintReceipt());

            return orderMessage.ToString();
        }

        public string PrintOrderHistory()
        {
            int counter = 0;
            StringBuilder orderHistory = new StringBuilder();
            orderHistory.Append("      ~~~ Order History ~~~\n\n");
            foreach (Order order in _orders) 
            {
                counter++;
                orderHistory.Append($"Order {counter} from {order.OrderDate}\n");
                orderHistory.Append($"Delivered at {order.DeliveryDate}\n\n");
                orderHistory.Append($"With items:\n");
                orderHistory.Append(new string('-', 33) + '\n');
                orderHistory.Append($"{order.BelongingReceipt.CalculateItems()}");
                orderHistory.Append(new string('-', 33) + '\n');
                orderHistory.Append($"Total\t\t".PadRight(18));
                orderHistory.Append($"£{float.Round(order.BelongingReceipt.Total, 2)}\n");
                if (order.BelongingReceipt.TotalDiscount > 0f)
                {
                    orderHistory.Append($"Total saved\t\t".PadRight(16));
                    orderHistory.Append($"£{float.Round(order.BelongingReceipt.TotalDiscount, 2)}\n");
                }
                orderHistory.Append(new string('~', 33) + "\n\n\n");
            }

            Console.WriteLine(orderHistory);

            return orderHistory.ToString();
        }

        public List<Basket> Baskets { get { return _baskets; } }
        public List<Item> Inventory { get { return _inventory; } }
        public List<Receipt> Receipts { get { return _receipts; } }
        public List<Order> Orders { get { return _orders; } }
    }
}
