using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tdd_bobs_bagels.Main;

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

        public void PrintHeader()
        {
            Console.WriteLine("{0, 47}", "~~~ Bob's Bagels ~~~");
            Console.WriteLine();
            Console.WriteLine("{0, 46}", Time.ToString());
            Console.WriteLine();
            Console.WriteLine(new string('-', 70));
            Console.WriteLine();
        }

        public void PrintItems()
        {
            Dictionary<string, int> counts = _basket.getCount(Items);
            List<string> printedSKUs = new List<string>();

            Console.WriteLine("{0,20}    {1, 20}    {2, 20}", "Product", "Quantity", "Price");
            Console.WriteLine();

            foreach (var item in Items)
            {
                if (!printedSKUs.Contains(item.SKU))
                {
                    string itemName = item.GetType().Name + " " + item.Variant.ToString();
                    string quantity = counts[item.SKU].ToString();
                    double originalPrice = Math.Round(_basket.GetPrice(counts[item.SKU], item.Price, false), 2);
                    double discountPrice = Math.Round(_basket.GetPrice(counts[item.SKU], item.Price, true), 2);
                    string discounted = "";

                    if (discountPrice != originalPrice)
                    {
                        discounted = $"(-£{Math.Round(originalPrice - discountPrice, 2)})";
                    }

                    Console.WriteLine("{0,20}    {1, 20}    {2, 20}", itemName, quantity, "£" + discountPrice.ToString());

                    if (discounted != "")
                    {
                        Console.WriteLine("{0, 69}", discounted);
                    }

                    printedSKUs.Add(item.SKU);
                }
            }
        }

        public void PrintEnd()
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 70));
            Console.WriteLine("{0, 20}    {1, 20}    {2, 20}", "Total", Items.Count, "£" + Total);
            Console.WriteLine();
            Console.WriteLine("{0, 42}", "Thank you");
            Console.WriteLine("{0, 45}", "for your order!");
        }

        public void PrintReceipt()
        {
            PrintHeader();
            PrintItems();
            PrintEnd();
        }
    }
}
