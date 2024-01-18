using exercise.main.items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        private List<Product> _products;
        private string _time;
        private StringBuilder _sb;
        private double _fullPrice;
        public Receipt(List<Product> products) 
        {
            _products = products;
            _sb = new StringBuilder();
            _time = DateTime.Now.ToString("yyyy - dd - MM HH:mm:ss");
            _fullPrice = products.Sum(p => p.Cost());
        }

        public string GetReceipt()
        {
            _sb.AppendLine($"{new(' ', (35 - 12) / 2)}Bob's Bagels");
            _sb.AppendLine($"{new(' ', (35 - _time.Length) / 2)}{_time}");
            _sb.AppendLine($"{new('=', 35)}");
            _sb.AppendLine($"Item{new(' ', 18)}Count   Price");
            _sb.AppendLine($"{new('-', 35)}");
            _sb.Append(GetBagels());
            _sb.Append(GetCoffees());
            _sb.AppendLine($"{new('-', 35)}");
            _sb.AppendLine("Discounts:");
            _sb.Append(GetDiscounts().text);
            _sb.AppendLine($"{new('-', 35)}");
            _sb.AppendLine($"Sum{new(' ', 29-3)}{(_fullPrice < 10 ? " £" : "£") + Math.Round(_fullPrice, 2)}");
            _sb.AppendLine($"Total Discount{new(' ', 28 - 14)}{(GetDiscounts().totalDiscount < 10 ? " -£" : "-£") + Math.Round(GetDiscounts().totalDiscount, 2)}");
            _sb.AppendLine($"Total{new(' ', 29 - 5)}{((_fullPrice - GetDiscounts().totalDiscount) < 10 ? " £" : "£") + Math.Round((_fullPrice - GetDiscounts().totalDiscount), 2)}");
            _sb.AppendLine($"{new('=', 35)}");
            if (GetDiscounts().totalDiscount < _fullPrice) _sb.AppendLine($"{new(' ', (35 - 28)/2)}You saved a total of £{Math.Round(GetDiscounts().totalDiscount, 2)}");
            if (GetDiscounts().totalDiscount < _fullPrice) _sb.AppendLine($"{new(' ', (35-16)/2)}on this purchase");


            return _sb.ToString();
        }

        private string GetBagels()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (BagelVariant bagelVariant in Enum.GetValues(typeof(BagelVariant)))
            {
                List<Bagel?> bagels = _products.Where(p => p.Bagel != null && p.Bagel.Variant.Equals(bagelVariant))
                    .Select(p => p.Bagel).ToList();
                int count = bagels.Count();
                Bagel sampleBagel = new Bagel(bagelVariant);

                if (count > 0)
                {
                    stringBuilder.AppendLine($"{sampleBagel.ToString()}{new (' ', 24-sampleBagel.ToString().Length)}{count + (count < 9 ? " " : "")}   {(count * sampleBagel.Price < 10 ? " £" : "£") + count*sampleBagel.Price}");
                    int fillingsAmount = bagels.Sum(b => b.Fillings.Count);
                    if (fillingsAmount > 0)
                    {
                        double fillingsCost = bagels.Sum(b => b.FillingCost());
                        stringBuilder.AppendLine($" - Filling x{fillingsAmount}{new(' ', 31 - 14)}£{fillingsCost}");
                    }
                }

            }
            return stringBuilder.ToString();
        }

        private string GetCoffees()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (CoffeeVariant coffeeVariant in Enum.GetValues(typeof(CoffeeVariant)))
            {
                int count = _products.Where(p => p.Coffee != null && p.Coffee.Variant.Equals(coffeeVariant)).Count();
                Coffee sampleCoffee = new Coffee(coffeeVariant);

                if (count > 0)
                {
                    stringBuilder.AppendLine($"{sampleCoffee.ToString()}{new(' ', 24 - sampleCoffee.ToString().Length)}{count + (count < 9 ? " " : "")}   {(count * sampleCoffee.Price < 10 ? " £" : "£") + Math.Round(count * sampleCoffee.Price, 2)}");
                }

            }
            return stringBuilder.ToString();
        }

        private (string text, double totalDiscount) GetDiscounts()
        {
            StringBuilder stringBuilder = new StringBuilder();
            double totalDiscount = 0;

            List<Coffee?> coffees = _products.Where(p => p.Coffee != null).Select(p => p.Coffee).ToList();
            coffees = coffees.OrderByDescending(c => c.Price).ToList();

            foreach (BagelVariant bagelVariant in Enum.GetValues(typeof(BagelVariant)))
            {
                int count = _products.Where(p => p.Bagel != null && p.Bagel.Variant.Equals(bagelVariant)).Count();
                Product product = _products.First(p => p.Bagel != null);
                double price = product != null && product.Bagel != null ? product.Bagel.Price : 0;


                if (count >= 12)
                {
                    int amt = count / 12;
                    count -= amt * 12;
                    double diff = (amt * 12 * price) - (3.99d * amt);
                    totalDiscount += diff;

                    stringBuilder.AppendLine($"Bagel x12 for £3.99{new(' ', 24 - 19)}{amt + (amt < 9 ? " " : "")}  {(amt < 10 ? " -£" : "-£") + diff}");
                }

                if (count >= 6)
                {
                    int amt = count / 6;
                    count -= amt * 6;
                    double diff = (3.99d * amt) - (amt * 12 * price);
                    totalDiscount += diff;

                    stringBuilder.AppendLine($"Bagel x6 for £2.49{new(' ', 24 - 18)}{amt + (amt < 9 ? " " : "")}  {(amt < 10 ? " -£" : "-£") + diff}");
                }

                int combiDeals = 0;
                double combiSaving = 0d;
                while (coffees.Count > 0 && count > 0)
                {
                    Coffee coffee = coffees.First();
                    coffees.Remove(coffee);

                    combiDeals++;

                    combiSaving += (price + coffee.Price) - 1.25d;
                }
                if (combiDeals > 0)
                {
                    totalDiscount += combiSaving;
                    stringBuilder.AppendLine($"Bagel & Coffe for £1.25{new(' ', 24 - 23)}{combiDeals + (combiDeals < 9 ? " " : "")}  {(combiDeals < 10 ? " -£" : "-£") + Math.Round(combiSaving, 2)}");
                }
            }
            return (stringBuilder.ToString(), totalDiscount);
        }
    }
}