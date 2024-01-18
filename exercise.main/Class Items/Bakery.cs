using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Class_Items
{
    public class Bakery
    {
        private List<(string SKU, double Price, Product.ProdType Type, string Variant)> _products;
        private int _basketCapacity = 12;
        private List<Basket> _customers = new List<Basket>();
        public Bakery() 
        {
            _products = new List<(string, double, Product.ProdType, string)>
            {
                ("BGLO", 0.49d, Product.ProdType.Bagle, "Onion"),
                ("BGLP", 0.39d, Product.ProdType.Bagle, "Plain"),
                ("BGLE", 0.49d, Product.ProdType.Bagle, "Everything"),
                ("BGLS", 0.49d, Product.ProdType.Bagle, "Sesame"),
                ("COFB", 0.99d, Product.ProdType.Coffee, "Black"),
                ("COFW", 1.19d, Product.ProdType.Coffee, "White"),
                ("COFC", 1.29d, Product.ProdType.Coffee, "Cappuccino"),
                ("COFL", 1.29d, Product.ProdType.Coffee, "Latte"),
                ("FILB", 0.12d, Product.ProdType.Filling, "Bacon"),
                ("FILE", 0.12d, Product.ProdType.Filling, "Egg"),
                ("FILC", 0.12d, Product.ProdType.Filling, "Cheese"),
                ("FILX", 0.12d, Product.ProdType.Filling, "Cream Cheese"),
                ("FILS", 0.12d, Product.ProdType.Filling, "Smoked Salmon"),
                ("FILH", 0.12d, Product.ProdType.Filling, "Ham")
            };

            _customers.Add(new Basket(_basketCapacity));
        }

        public bool AddToBasket(string sku, int customer = 0)
        {
            //throw new NotImplementedException();

            if (_products.Exists(x => x.SKU == sku))
            {
                int index = _products.IndexOf(_products.Find(x => x.SKU == sku));
                return _customers[customer].AddProduct(new Bagle(_products[index].SKU, _products[index].Price, _products[index].Type, _products[index].Variant));
            }
            return false;
        }

        public int RemoveFromBasket(string sku, int customer = 0)
        {
            return _customers[customer].Remove(sku);
        }

        public int ChangeCapacity(int amount)
        {
            if (amount < 0)
                return _basketCapacity;
            _basketCapacity = amount;
            foreach (var item in _customers)
            {
                item.ChangeCapacity(_basketCapacity);
            }
            return _basketCapacity;
        }

        public double BagleCost(string sku)
        {
            if (_products.Exists(x => x.SKU == sku))
            {
                return _products.Find(x => x.SKU == sku).Price;
            }
            return -1d;
        }
        
        public double AddFilling(string skuB, string skuF, int customer = 0)
        {
            if (_products.Exists(x => x.SKU == skuF))
            {
                int index = _products.IndexOf(_products.Find(x => x.SKU == skuF));
                return _customers[customer].AddFilling(skuB, new Filling(_products[index].SKU, _products[index].Price, _products[index].Type, _products[index].Variant));
            }
            return -1d;
        }

        public double FillingCost(string sku)
        {
            if (_products.Exists(x => x.SKU == sku))
            {
                return _products.Find(x => x.SKU == sku).Price;
            }
            return -1d;
        }

        public double CheckOut(int customer = 0)
        {
            double price = _customers[customer].TotalCost();
            List<Product> products = _customers[customer].Items;
            Console.WriteLine("\t~~~ Bob's Bagles ~~~");
            Console.WriteLine();
            Console.WriteLine("\t" + DateTime.Now);
            Console.WriteLine();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine();
            
            price = Discount(price, products);
            
            Console.WriteLine();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"Total:\t\t\t\t £{Math.Round(price, 2)}");
            return Math.Round(price,2);
        }

        private double Discount(double price, List<Product> cart)
        {
            //throw new NotImplementedException();
            int bagleCount = cart.Where(i => i.Type == Product.ProdType.Bagle).Count();
            var bagleList = cart.Where(i => i.Type == Product.ProdType.Bagle).OrderBy(i => i.Price).ToList();


            if (bagleCount >= 12)
            {
                Console.WriteLine("Twelve Bagel deal \t\t £3.99");
                price += 3.99d;
                double saved = 0;
                for (int i = 0; i < 12; i++)
                {
                    price -= _products.Find(x => x.SKU == bagleList[i].SKU).Price;
                    saved += _products.Find(x => x.SKU == bagleList[i].SKU).Price;
                    cart.RemoveAt(cart.IndexOf(cart.Find(x => x.SKU == bagleList[i].SKU)));
                }
                Console.WriteLine($"\t\t\t\t -£{-1*Math.Round(3.99d - saved, 2)}");
                price = Discount(price, cart);
            }
            else if (bagleCount >= 6)
            {
                Console.WriteLine("Six Bagel deal \t\t\t £2.49");
                price += 2.49d;
                double saved = 0;
                for (int i = 0; i < 6; i++)
                {
                    price -= _products.Find(x => x.SKU == bagleList[i].SKU).Price;
                    saved += _products.Find(x => x.SKU == bagleList[i].SKU).Price;
                    cart.RemoveAt(cart.IndexOf(cart.Find(x => x.SKU == bagleList[i].SKU)));
                }
                Console.WriteLine($"\t\t\t\t -£{-1*Math.Round(2.49d - saved, 2)}");
                price = Discount(price, cart);
            }
            else if (cart.Exists(x => x.Type == Product.ProdType.Bagle) && cart.Exists(x => x.Type == Product.ProdType.Coffee)) 
            {
                Console.WriteLine("Coffee and bagle deal \t\t £1.25");
                price += 1.25d;
                double saved = 0;
                price -= _products.Find(x => x.SKU == bagleList[0].SKU).Price;
                saved += _products.Find(x => x.SKU == bagleList[0].SKU).Price;
                cart.RemoveAt(cart.IndexOf(cart.Find(x => x.SKU == bagleList[0].SKU)));

                price -= cart.Find(x => x.Type == Product.ProdType.Coffee).Price;
                saved += cart.Find(x => x.Type == Product.ProdType.Coffee).Price;
                cart.RemoveAt(cart.IndexOf(cart.Find(x => x.Type == Product.ProdType.Coffee)));
                
                Console.WriteLine($"\t\t\t\t -£{-Math.Round(1.25 - saved, 2)}");
                price = Discount(price, cart);
            }
            else 
            {
                foreach (var item in cart)
                {
                    Console.WriteLine($"{item.Type} {item.Varaiant} \t\t\t £{item.Price}");
                }
            }
            return price;
        }
    }
}
