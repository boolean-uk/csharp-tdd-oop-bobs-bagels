using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        DateTime _time;
        Basket _basket;
        double _total;
        public Receipt(Basket basket) 
        { 
            _time = DateTime.Now;
            _basket = basket;
            _total = _basket.GetTotal();
        }

        public DateTime Time { get => _time; }
        public List<IProduct> Items { get => _basket.Items; }
        public double Total { get => _total; }

        public void PrintReceipt()
        {
            string header = "\t~~~ Bob's Bagels ~~~\t";
            Console.WriteLine(header);
            Console.WriteLine();
            Console.WriteLine("\t" + Time.ToString());
            Console.WriteLine();
            Console.WriteLine(new string('-', header.Length + (8*2)));
            Console.WriteLine();

            Dictionary<string, int> counts = _basket.getCount(Items);
            List<string> printedSKUs = new List<string>();

            foreach (var item in Items)
            {
                if (!printedSKUs.Contains(item.SKU)) {
                    Console.Write(item.GetType().Name + " " + item.Variant.ToString());
                    Console.Write("\t\t" + counts[item.SKU]);
                    double discountPrice = Math.Round(_basket.GetPrice(counts[item.SKU], item.Price, true), 2);
                    double originalPrice = Math.Round(_basket.GetPrice(counts[item.SKU], item.Price, false), 2);
                    Console.WriteLine("\t£ " + discountPrice);
                    if (discountPrice != originalPrice)
                    {
                        Console.WriteLine($"\t\t\t\t(-£{Math.Round(originalPrice - discountPrice, 2)})");
                    }
                    printedSKUs.Add(item.SKU);
                }
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', header.Length + (8 * 2)));
            Console.WriteLine($"Total\t\t\t\t £{Total}");
            Console.WriteLine();
            Console.WriteLine("\t    Thank you\t");
            Console.WriteLine("\tfor your order!\t");
        }
    }
}
