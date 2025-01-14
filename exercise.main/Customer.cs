using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Customer
    {
        private static int _counter = 0;
        public int _id { get; set; }
        public string _name { get; set; }
        public Basket _basket { get; set; }
        public Store _store { get; set; }

        public Customer(string name, Store store)
        {
            _counter += 1;
            _id = _counter;
            _name = name;
            _basket = new Basket();
            _store = store;
        }

        public Basket order(string sku)
        {
            Item? item = _store._itemsInStock.Find((x) => x.SKU == sku);
            // if under capacity and found sku in store inventory
            if (_store._basketCapacity > _basket._items.Count && item != null)
            {
                Item itemToAdd = item switch
                {
                    Bagel => new Bagel(item.SKU, item.name, item.cost, item.variant),
                    Coffee => new Coffee(item.SKU, item.name, item.cost, item.variant),
                    Filling => new Filling(item.SKU, item.name, item.cost, item.variant),
                    _ => throw new InvalidOperationException("Not valid SKU")
                };
                _basket._items.Add(itemToAdd);
                Console.WriteLine($"{sku} was added");
                return _basket;
            }
            Console.WriteLine($"{sku} was not added");
            return _basket;
        }

        public string DeleteItem(string sku)
        {
            Item? item = _basket._items.Find((x) => x.SKU.Equals(sku));
            if (item != null)
            {
                _basket._items.Remove(item);
                return $"{sku} has been deleted";
            }
            return $"{sku} was not found";
        }

        public double CalculateCostBeforeOrder(string sku)
        {
            Item? item = _basket._items.Find((x) => x.SKU == sku);
            if (item != null)
            {
                return item.cost;
            }
            return 0.0;
        }

        public double FindPriceDifference()
        {
            double fullPrice = 0.0;
            foreach (Item item in _basket._items)
            {
                fullPrice += _store._itemsInStock.Find((x) => x.SKU == item.SKU).cost;
            }
            return fullPrice - _basket._items.Sum(item => item.cost);
        }

        /**
         * Extension 3: Discount Receipts
         */

        public string GenerateReceiptWithDiscounts()
        {
            if (_basket._items.Count == 0)
            {
                return "Empty Basket";
            }
            StringBuilder sb = new StringBuilder();
            string Receipt =
                "~~~ Bob's Bagels ~~~ \n" +
                "\n" +
               $"{DateTime.Now.ToString("yyyy/dd/mm hh:mm:ss")} \n" +
                "----------------------------------------\n";
            sb.AppendLine(Receipt);


            Dictionary<string, int> itemCount = new Dictionary<string, int>();
            foreach (Item item in _basket._items)
            {
                itemCount[$"{item.variant} {item.name}"] = itemCount.ContainsKey($"{item.variant} {item.name}") ? itemCount[$"{item.variant} {item.name}"] + 1 : 1;
            }
            double savedOnPurchase = 0;
            foreach (string itemName in itemCount.Keys)
            {
                Item itemInStock = _basket._items.Find((x) => x.variant + " " + x.name == itemName);
                sb.AppendFormat("{0,-25}{1,5}{2,10}\n", itemName, itemCount[itemName], (decimal)itemInStock.cost * itemCount[itemName]);
                if (itemInStock.cost != _basket._items.Last((x) => x.variant + " " + x.name == itemName).cost)
                {
                    sb.AppendFormat("{0,40}\n", (-(decimal) _store._itemsInStock.Find((x) => $"{x.variant} {x.name}" ==itemName).cost * itemCount[itemName]) + (decimal) _basket._items.Last((x) => x.variant + " " + x.name == itemName).cost * itemCount[itemName]);
                    savedOnPurchase += _basket._items.Last((x) => x.variant + " " + x.name == itemName).cost - itemCount[itemName];
                }
            }
        
            sb.AppendLine("----------------------------------------\n");
            sb.AppendFormat("{0,-25}{1,15}",$"Total", $"£{_basket.CalculateTotalCost():F2}");

            sb.AppendLine(
                $"\nYou saved a total of £{FindPriceDifference():F2} on this shop \n" +
                "Thank you for your order!");

            return sb.ToString();
        }

    }
    }
