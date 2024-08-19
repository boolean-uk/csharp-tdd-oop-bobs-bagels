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
        public Reciept(List<Product> basket, double total) 
        {
            _date = DateTime.Now;
            _basket = basket;
            this.total = total;
        }

        public Reciept PrintReciept()
        {
            List<Product> uniqueProducts = _basket.Distinct().ToList();
            StringBuilder productsString = new StringBuilder();

            foreach (Product product in uniqueProducts) 
            {
                int productAmount = _basket.Where(item => product.SKU == item.SKU).Count();
                productsString.Append(Environment.NewLine);
                productsString.Append(product.Variant);
                productsString.Append(" ");
                productsString.Append(product.Name);
                productsString.Append("     ");
                productsString.Append(productAmount);
                productsString.Append(" £");
                productsString.Append(Math.Round(product.Price*productAmount, 2));
            }


            Console.WriteLine(_TITLE);
            Console.WriteLine(_date);
            Console.WriteLine("------------------------");
            Console.WriteLine(productsString);
            Console.WriteLine("------------------------");
            Console.WriteLine("Total            £" + total ); 
            return this;
        }

        private string _TITLE = "~~~ Bob's Bagels ~~~";
        private DateTime _date {  get; set; }
        private List<Product> _basket {  get; set; }
        public double total {  get; set; }
    }
}
