using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket { 

        public List<Product> products { get; private set; } = new List<Product>();
        private int capacity = 3;

        public bool Add(Product product)
        {
            if (products.Count >= capacity) return false;
            products.Add(product); 
            return true;
        }

        public bool Remove(Product product)
        {
            if ( !products.Contains(product) ) return false;
            products.Remove(product);
            return true;
        }

        public void ChangeCapacity(int v)
        {
            capacity = (v < 0 ? capacity : v);
        }

        public double TotalCost(bool discounts = true)
        {
            if ( !discounts  ) return products.Sum(x => x.GetPrice());
            double total = 0;
            int deals = 0, bagels = (products.OfType<Bagel>().Count());

            products = products.OrderBy(x => x.itemNr).ToList();

            // check if bagels should be discounted
            if ( bagels >= 12) total += bagelDeals(bagels, 12, out deals);
            if (bagels - deals >= 6) total += bagelDeals(bagels, 6, out deals); 


            int coffeeDeals = Math.Min(bagels - deals, products.Count - bagels);
            // check if there are non discounted bagels and coffees in the order
            if ( coffeeDeals > 0) total += CoffeeDeals(bagels, coffeeDeals, deals);

            return total + products.Sum(x => x.GetPrice());
        }

        private double bagelDeals(int bagels, int count, out int deals)
        {
            deals = (bagels / count) * count;
            for (int i = 0; i < deals; i++)
            {
                products[i].price = 0;
            }
            if (count == 12) return (bagels / 12) * 3.99d;
            return ((bagels % 12) / 6) * 2.49d;
        }

        private double CoffeeDeals(int bagels, int coffeeDeals, int deals = 0)
        {
            for (int i = 0; i < coffeeDeals; i++)
            {
                products[deals + i].price = 0;
                products[bagels + i].price = 0;
            }

            return coffeeDeals * 1.25d;
        }

        public string Prices()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Bagel:");
            Bagel bagel = new Bagel(BagelType.Everything);
            foreach (BagelType type in Enum.GetValues(typeof(BagelType)))
            {
                sb.AppendLine($"{type}: {bagel.bagelToInfo[type].price}");
            }

            sb.AppendLine("Coffee:");
            Coffee coffee = new Coffee(CoffeeType.Capuccino);
            foreach ( CoffeeType type in Enum.GetValues(typeof(CoffeeType)) )
            {
                sb.AppendLine($"{type}: {coffee.coffeToInfo[type].price}");
            }

            sb.AppendLine("Fillings:");
            foreach (FillingType type in Enum.GetValues(typeof(FillingType)))
            {
                sb.AppendLine($"{type}: {0.12d}");
            }
            return sb.ToString();
        }

        public void WriteReceipt()
        {


            Console.WriteLine( "       ~~~ Bob's Bagels ~~~\n");
            Console.WriteLine($"       {DateTime.Now.ToString(new CultureInfo("ja-JA"))}\n");
            Console.WriteLine($"{new ('-', 36)}\n");

            int deals = 0, bagels = (products.OfType<Bagel>().Count());
            products = products.OrderBy(x => x.itemNr).ToList();

            StringBuilder sb;
            int elements;

            List<Filling> fillings = new List<Filling>();
            foreach ( Bagel fillingHolders in products.OfType<Bagel>())
            {
                if (fillingHolders._filling.Count > 0) fillings.AddRange(fillingHolders._filling);
            }

            foreach ( var elm in products.DistinctBy(x => x.itemNr))
            {
                sb = new StringBuilder();

                sb.Append($"{elm.GetType().Name} {elm.name()}");
                sb.Append($"{new (' ', 24 - sb.Length)}");

                int count = products.Count(x => x.SKU == elm.SKU);
                elements = (int) Math.Ceiling(Math.Log10(count + 1));
                sb.Append($"{new string(' ', 4 - elements )}{count}");

                double price = count * elm.price;
                elements = (int)Math.Ceiling(Double.Max(Math.Log10(price + 1), 0.0));

                sb.Append($"{new string(' ', 4 - elements)}£");
                sb.Append(String.Format("{0:F2}", Math.Round(price, 2)));
                Console.WriteLine(sb.ToString());
            }

            Console.WriteLine();

            foreach( var elm in fillings.DistinctBy(x => x.SKU))
            {
                sb = new StringBuilder();
                sb.Append($"{elm.GetType().Name} {elm.name()}");
                sb.Append($"{new (' ', 24 - sb.Length)}");

                int count = fillings.Count(x => x.SKU == elm.SKU);
                elements = (int)Math.Ceiling(Math.Log10(count + 1));
                sb.Append($"{new (' ', 4 - elements)}{count}");

                double price = count * elm.price;
                elements = (int)Math.Ceiling(Double.Max(Math.Log10(price + 1), 0.0));
                sb.Append($"{new (' ', 4 - elements)}");
                sb.Append(String.Format("£{0:F2}", Math.Round(price, 2)));

                Console.WriteLine(sb.ToString());
            }

            
            double cost, 
                costDeal;

            Console.WriteLine($"\n{new string('-', 36)}\n");

            if ( bagels  >= 12)
            {
                cost = products.Take((bagels / 12)*12).Sum(x => x.GetPrice());
                costDeal = bagelDeals(bagels, 12, out deals);

                Console.WriteLine("12 Bagels for £3.99        {0}  -£{1:F2}", bagels / 12, Math.Abs(costDeal - cost));
            }


            if ( bagels >= 6 )
            {
                cost = products.Skip(deals).Take(((bagels % 12) / 6)*6).Sum(x => x.GetPrice());
                costDeal = bagelDeals(bagels, 6, out deals);

                Console.WriteLine("6 Bagels for £2.49         1  -£{0:F2}", Math.Abs(costDeal - cost));
            }

            int coffeeDeals = Math.Min(bagels - deals, products.Count - bagels);
            if ( coffeeDeals > 0 )
            {
                cost = products.Skip(deals).Take(coffeeDeals).Sum(x => x.GetPrice());
                costDeal = CoffeeDeals(bagels, coffeeDeals, deals);
            }


            Console.WriteLine($"\n{new string('-', 36)}\n");
            sb = new StringBuilder();
            sb.Append($"Total{new (' ', 23)}");
            double totalCost = TotalCost();
            elements = (int)Math.Ceiling(Math.Log10(totalCost + 1));
            sb.Append($"{new (' ', 4 - elements)}£{Math.Round(totalCost, 2)}");

            Console.WriteLine(sb.ToString());


            Console.WriteLine("           Thank you");
            Console.WriteLine("         for your order!");
        }
    }
}
