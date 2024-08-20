using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Reciept
    {
        public Reciept(List<Product> basket, double totalDiscount, double totalNoDiscount) 
        {
            _date = DateTime.Now;
            _basket = basket;
            this.total = Math.Round(totalDiscount, 2);
            this.totalNoDiscount = Math.Round(totalNoDiscount, 2);
        }

        public Reciept PrintReciept()
        {
            List<Product> uniqueProducts = _basket.Distinct().ToList();
            StringBuilder productsString = new StringBuilder();

            foreach (Product product in uniqueProducts) 
            {
                int productAmount = _basket.Where(item => product.SKU == item.SKU).Count();
                productsString.Append(Environment.NewLine);
                productsString.Append(String.Format("{0, -21}", product.Name + " " + product.Variant));
                productsString.Append(String.Format("{0, -5}", productAmount));
                productsString.Append(Math.Round(product.Price*productAmount, 2));
            }

            Console.WriteLine();
            Console.WriteLine(_TITLE);
            Console.WriteLine(_date);
            Console.WriteLine("------------------------------");
            Console.WriteLine(productsString);
            Console.WriteLine("------------------------------");
            Console.Write(String.Format("{0, -25}", "Total no discount"));
            Console.WriteLine("£" + totalNoDiscount);
            Console.Write(String.Format("{0, -25}", "Money saved"));
            Console.WriteLine("£" + (Math.Round(totalNoDiscount - total, 2)));
            Console.Write(String.Format("{0, -25}", "Total"));
            Console.WriteLine("£" + total);
            return this;
        }

        private string _TITLE = "~~~ Bob's Bagels ~~~";
        private DateTime _date {  get; set; }
        private List<Product> _basket {  get; set; }
        public double total { get; set; }
        public double totalNoDiscount { get; set; }
    }
}
