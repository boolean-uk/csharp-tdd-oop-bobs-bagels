using System;
using System.Collections.Generic;
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
            if ( bagels >= 6)
            {
                deals = (bagels / 6) * 6;
                for ( int i = 0; i < deals; i++ )
                {
                    products[i].price = 0;
                }
                total += (bagels / 12) * 3.99d + ((bagels % 12) / 6) * 2.49d;
            }


            int coffeeDeals = Math.Min(bagels - deals, products.Count - bagels);
            // check if there are non discounted bagels and coffees in the order
            if ( coffeeDeals > 0)
            {
                for ( int i = 0; i < coffeeDeals; i++ )
                {
                    products[deals + i].price = 0;
                    products[bagels + i].price = 0;
                }

                total += coffeeDeals * 1.25d;
            }

            return total + products.Sum(x => x.GetPrice());
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

            Console.WriteLine( "    ~~~ Bob's Bagels ~~~\n");
            Console.WriteLine($"    {DateTime.Now.ToString("ja-JA")}\n");
            Console.WriteLine("----------------------------\n");
        }
    }
}
