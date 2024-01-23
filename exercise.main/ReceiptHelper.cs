using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class ReceiptHelper
    {
        public Basket _basket;
        public Discounts _discounts;
        public ReceiptHelper(Basket basket, Discounts discounts)
        {
            _basket = basket;

            _discounts = discounts;

        }

        public Dictionary<Product, int> createReceiptList(Basket basket)
        {
            Dictionary<Product, int> keyValuePairs = new Dictionary<Product, int>();

            foreach (Product p in basket._basket)
            {
                if (keyValuePairs.ContainsKey(p))
                {
                    keyValuePairs[p]++;
                }
                else
                {
                    keyValuePairs.Add(p, 1);
                }
            }

            return keyValuePairs;
        }

        public void printReceipt()
        {
 

            Dictionary<Product, int> products = createReceiptList(_basket);
            // _discounts.CalculateDiscount();
            Console.WriteLine("                                                     Bobs Bagels receipt                                                                         ");
            Console.WriteLine("                         ---------------------------------------------------------------------                                                   ");

            foreach (KeyValuePair<Product, int> entry in products)
            {
                Console.WriteLine($"                {entry.Key.Name}      {entry.Key.Variant}                 Number: {entry.Value}                   Price: {entry.Key.Price * entry.Value}");
                if (entry.Key.SKU.StartsWith("BGL") && entry.Value > 6)
                {
                    Console.WriteLine($"                                                                      Discounted Price: {_discounts.BagelDiscount(entry.Key.SKU, entry.Value, out int bagelCountAfter)} ({entry.Value - bagelCountAfter})");

                    if (entry.Key.SKU.StartsWith("COF") && entry.Value > 0 && bagelCountAfter > 0)
                    {
                        Console.WriteLine($"     Coffee Discount:        ");

                    }
                    Console.WriteLine($"                {entry.Key.Name}      {entry.Key.Variant}                 Number: {bagelCountAfter}                   Price: {entry.Key.Price * bagelCountAfter}");



                }
               
            }

            Console.WriteLine($"                            TOTAL:  {Math.Round(_discounts.CalculateDiscount(), 2)}");
        }



    }
}
