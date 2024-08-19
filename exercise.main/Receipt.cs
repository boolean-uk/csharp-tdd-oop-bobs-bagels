using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public static class Receipt
    {
        private static DateTime date = DateTime.Now;




        public static void PrintReciept(Basket basket)
        {
            Console.WriteLine("~~~ Bob's Bagels ~~~");
            Console.WriteLine("");
            Console.WriteLine(date);
            Console.WriteLine("----------------------");

            foreach (var item in basket.Items)
            {
                Console.WriteLine(item.Name + " " + item.Price);
            }

            Console.WriteLine("----------------------");
            Console.WriteLine(basket.GetPrice());
            

        }
    }
}
