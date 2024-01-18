using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public int _Capacity { get; set; } = 20;
        private readonly Products _DB;
        private double Price { get; set; } = 0;
        public List<Product> _Basket { get; set; } = [];
        public Basket(Products dB)
        {
            _DB = dB;
        }

        private void CalculateCost()
        {
            List<Product> bagels = _Basket.Where(p => p.Name == "Bagel").ToList();
            List<Product> coffees = _Basket.Where(p => p.Name == "Coffee").ToList();
            int bagelAmount = bagels.Count;
            double cost = 0;

            // case: 12 bagels for 3.99$
            int twelvePairs = bagelAmount / 12;
            if (twelvePairs > 0)
            {
                double specialOfferTwelvePairPrice = twelvePairs * 3.99;
                cost += specialOfferTwelvePairPrice;
                bagelAmount -= twelvePairs * 12;
            }

            //case: 6 bagels for 2.49$
            int sixPairs = bagelAmount / 6;
            if (sixPairs > 0)
            {
                double specialOfferSixPairPrice = sixPairs * 2.49;
                cost += specialOfferSixPairPrice;
                bagelAmount -= sixPairs * 6;
            }

            // case: one coffe and one bagle for 1.25$
            int coffeeAmount = _Basket.Count(p => p.Name == "Coffee");
            if (bagelAmount > 0 && coffeeAmount > 0)
            {
                int coffeeBagelPair = Math.Min(bagelAmount, coffeeAmount);
                cost += coffeeBagelPair * 1.25;
                bagelAmount -= coffeeBagelPair;
                coffeeAmount -= coffeeBagelPair;
            }

            // adding price for bagels not involved in the special offers
            for (int i = bagels.Count - 1; i >= bagels.Count - bagelAmount; i--) { cost += bagels[i].Price; }

            // adding price for coffees not invovled in the special offers
            for (int j = coffees.Count - 1; j >= coffees.Count - coffeeAmount; j--) { cost += coffees[j].Price; }

            // adding price for bagel-fill
            var filling = _Basket.OfType<Bagel>();
            double sumFilling = filling.Sum(c => c.Filling.Price);

            cost += sumFilling;
            Price = cost;
        }

        public bool Add(string sku)
        {
            if (_Basket.Count != _Capacity)
            {
                Product? p = _DB.productList.FirstOrDefault(x => x.SKU == sku);
                if (p != null)
                {
                    _Basket.Add(p);
                    Price += p.Price;
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string sku)
        {
            Product? p = _Basket.Find(x => x.SKU == sku);
            if (p != null)
            {
                this._Basket.Remove(p);
                Price -= p.Price;
                return true;
            }
            return false;
        }

        public bool ChangeCapacity(int newCapacity)
        {
            try
            {
                _Capacity = newCapacity;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }


        public double TotalCost()
        {/*
            double sum = _Basket.Sum(p => p.Price);
            var filling = _Basket.OfType<Bagel>();
            sum += filling.Sum(x => x.Filling.Price);*/
            CalculateCost();
            return Price;
        }

        public double GetCostOfBagel(string sku)
        {
            Product? p = _DB.productList.Find(x => x.SKU == sku);
            if (p != null)
            {
                return p.Price;
            }
            return -1;
        }

        public bool Add(string sku, string filling)
        {
            if (_Basket.Count != _Capacity)
            {
                Product? p = _DB.productList.FirstOrDefault(x => x.SKU == sku);
                Product? p2 = _DB.productList.FirstOrDefault(x => x.SKU == filling);
                if (p != null && p2 != null)
                {
                    Bagel bagelWithFilling = new Bagel()
                    {
                        Id = p.Id,
                        Name = p.Name,
                        SKU = p.SKU,
                        Price = p.Price,
                        Variant = p.Variant,
                        Filling = p2
                    };
                    _Basket.Add(bagelWithFilling);
                    Price += p.Price + p2.Price;
                    return true;
                }
            }
            return false;
        }

        public void Receipt()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(' ', 5);
            sb.Append('~', 3);
            sb.Append(' ');
            sb.Append("Bob's Bagels");
            sb.Append(' ');
            sb.Append('~', 3);
            sb.AppendLine();
            sb.Append(' ', 5);

            Console.WriteLine(sb.ToString());

            string date = DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss");
            Console.Write("     " + date);

            sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine();
            sb.Append('-', 30);
            Console.WriteLine(sb.ToString());
            Console.WriteLine();

            Products products = new Products();
            Basket basket = new Basket(products);

            string bagel = Menu.BGLP.ToString();
            string bagel2 = Menu.BGLP.ToString();
            string bagel3 = Menu.BGLS.ToString();
            string coffee = Menu.COFB.ToString();
            string fill1 = Menu.FILH.ToString();
            basket.Add(bagel);
            basket.Add(bagel2);
            basket.Add(bagel3);
            basket.Add(bagel3, fill1);
            basket.Add(bagel3, fill1);
            for (int i = 0; i < 2; i++)
            {
                basket.Add(coffee);
            }

            var noe = from product in basket._Basket
                      group product by product.SKU into newGroup
                      select new
                      {
                          variant = newGroup.First().Variant,
                          name = newGroup.First().Name,
                          quantity = newGroup.Count(),
                          total = newGroup.Sum(x => x.Price)
                      };

            var filling = basket._Basket.OfType<Bagel>();
            var noe2 = from fill in filling
                       group fill by fill.SKU into newGroups
                       select new
                       {
                           variant = newGroups.First().Filling.Variant,
                           name = newGroups.First().Filling.Name,
                           quantity = newGroups.Count(),
                           total = newGroups.Sum(x => x.Filling.Price)
                       };


            foreach (var item in noe)
            {
                Console.WriteLine($"{item.variant,-7} {item.name,-12} {item.quantity,-2} £{item.total}");
            }

            foreach (var item in noe2)
            {
                Console.WriteLine($"{item.variant,-7} {item.name,-12} {item.quantity,-2} £{item.total}");
            }

            sb = new StringBuilder();
            sb.AppendLine();
            sb.Append('-', 30);
            Console.WriteLine(sb.ToString());
            Console.WriteLine();
            Console.WriteLine($"{"Total",-23} £{Math.Round(basket.TotalCost(), 2)}");
            Console.WriteLine($"{"Thank you",19}");
            Console.WriteLine($"{"for your order!",22}");
        }
    }
}
