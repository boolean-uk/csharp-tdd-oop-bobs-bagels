using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            double priceFillings = 0;

            foreach (var item in basket.Items)
            {
                Console.WriteLine(item.Name + " " + item.Variant + " " + item.Price);
                if (item.GetType() == typeof(Bagel))
                {
                    Bagel bagel = (Bagel)item;
                    foreach (var item1 in bagel.Fillings)
                    {
                        Console.WriteLine(" - " + item1.Name + " " + item1.Price);
                        priceFillings += item1.Price;
                    }

                }
            }
            

            Console.WriteLine("----------------------");
            double priceBeforeDiscount = basket.GetPrice() + priceFillings;
            priceBeforeDiscount = Math.Round(priceBeforeDiscount, 2);
            double priceAfterDiscount = basket.GetDiscountPrice(basket);
            double savings = priceBeforeDiscount - priceAfterDiscount;
            Console.WriteLine("You saved: " + Math.Round(savings,2));
            Console.WriteLine("Total: " + Math.Round(priceAfterDiscount,2));
            

        }
    }
}
