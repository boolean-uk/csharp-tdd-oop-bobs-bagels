using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public static class CashRegister
    {
        /// <summary>
        /// Sorry for not refactoring this absolute mess. But time is running out and I have to do the other exercises. No time for refactor. 
        /// I can see multiple ways to make things easier for me here, but I am some exercises behind now.
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public static double CalculateReceipt(List<Product> products)
        {
            Dictionary<string, int> discountTracker = PopulateTracker();
            double total = 0.00d;
            if (!products.Any())
            {
                return total;
            }

            StringBuilder receipt = new StringBuilder();
            receipt.Append("      ~~~ Bob's Bagels ~~~      ");
            receipt.Append(System.Environment.NewLine + System.Environment.NewLine);
            receipt.Append("       " + DateTime.Now);
            receipt.Append(System.Environment.NewLine + System.Environment.NewLine);
            receipt.Append("--------------------------------");
            receipt.Append(System.Environment.NewLine + System.Environment.NewLine);

            foreach (Product product in products)
            {
                if (product.SKU.Contains("BGLP"))
                {
                    discountTracker["BGLP"]++;
                }
                else if (product.SKU.Contains("BGLO"))
                {
                    discountTracker["BGLO"]++;
                }
                else if (product.SKU.Contains("BGLE"))
                {
                    discountTracker["BGLE"]++;
                }
                else if (product.SKU.Contains("BGLS"))
                {
                    discountTracker["BGLS"]++;
                }
                else if (product.SKU.Contains("COFB"))
                {
                    discountTracker["COFB"]++;
                }
            }

            double twelveDiscount = discountTracker["BGLP"] / 12;
            double sixDiscount = discountTracker["BGLE"] / 6;
            double discount = 0.00d;

            // Bagel discount adder
            if (twelveDiscount >= 1)
            {
                for (int i = 0; i < twelveDiscount; i++)
                {
                    receipt.Append("Plain Bagel          12   £3.99 ");
                    receipt.Append(System.Environment.NewLine);
                    receipt.Append("                        (-£0.69)");
                    receipt.Append(System.Environment.NewLine);
                    discount += 0.69d;
                    discountTracker["BGLP"] -= 12;
                }
            }
            if (sixDiscount >= 1)
            {
                for (int i = 0; i < sixDiscount; i++)
                {
                    receipt.Append("Everything Bagel       6   £2.49 ");
                    receipt.Append(System.Environment.NewLine);
                    receipt.Append("                        (-£0.45)");
                    receipt.Append(System.Environment.NewLine);
                    discount += 0.45d;
                    discountTracker["BGLE"] -= 6;
                }
            }

            // Coffee deals discount adder
            if (discountTracker["COFB"] >= 1)
            {
                int iterations = discountTracker["COFB"];
                for (int i = 0; i < iterations; i++)
                {
                    if (discountTracker["BGLP"] >= 1)
                    {
                        receipt.Append("Coffee+Plain Bagel     1   £1.25 ");
                        receipt.Append(System.Environment.NewLine);
                        receipt.Append("                        (-£0.13)");
                        receipt.Append(System.Environment.NewLine);
                        discount += 0.13;
                        discountTracker["BGLP"]--;
                        discountTracker["COFB"]--;
                    }
                    else if (discountTracker["BGLE"] >= 1)
                    {
                        receipt.Append("Coffee+Everything Bgl  1   £1.25 ");
                        receipt.Append(System.Environment.NewLine);
                        receipt.Append("                        (-£0.23)");
                        receipt.Append(System.Environment.NewLine);
                        discount += 0.23;
                        discountTracker["BGLE"]--;
                        discountTracker["COFB"]--;
                    }
                    else if (discountTracker["BGLS"] >= 1)
                    {
                        receipt.Append("Coffee+Sesame Bagel    1   £1.25 ");
                        receipt.Append(System.Environment.NewLine);
                        receipt.Append("                        (-£0.23)");
                        receipt.Append(System.Environment.NewLine);
                        discount += 0.23;
                        discountTracker["BGLS"]--;
                        discountTracker["COFB"]--;
                    }
                    else if (discountTracker["BGLO"] >= 1)
                    {
                        receipt.Append("Coffee+Onion Bagel     1   £1.25 ");
                        receipt.Append(System.Environment.NewLine);
                        receipt.Append("                        (-£0.23)");
                        receipt.Append(System.Environment.NewLine);
                        discount += 0.23;
                        discountTracker["BGLO"]--;
                        discountTracker["COFB"]--;
                    }
                    else
                    {
                        break; // Exit if bagels are no more
                    }
                }
            }

            if (discountTracker.Values.Any(value => value > 0))
            {
                foreach (var item in discountTracker)
                {
                    if (item.Value > 0)
                    {
                        if (item.Key == "BGLP")
                        {
                            receipt.Append($"Plain Bagel           {item.Value}   £{Math.Round(item.Value * 0.39, 2)}");
                        }
                        else if (item.Key == "BGLO")
                        {
                            receipt.Append($"Onion Bagel           {item.Value}   £{Math.Round(item.Value * 0.49, 2)}");
                        }
                        else if (item.Key == "BGLE")
                        {
                            receipt.Append($"Everything Bagel      {item.Value}   £{Math.Round(item.Value * 0.49, 2)}");
                        }
                        else if (item.Key == "BGLS")
                        {
                            receipt.Append($"Sesame Bagel          {item.Value}   £{Math.Round(item.Value * 0.49, 2)}");
                        }
                        else if (item.Key == "COFB")
                        {
                            receipt.Append($"Black Coffee          {item.Value}   £{Math.Round(item.Value * 0.99, 2)}");
                        }
                        receipt.Append(System.Environment.NewLine);
                    }
                }
            }

            total = products.Sum(product => product.Price);
            double returnPrice = total - discount;

            receipt.Append(System.Environment.NewLine);
            receipt.Append("--------------------------------");
            receipt.Append(System.Environment.NewLine);
            receipt.Append($"Total                    £{Math.Round(returnPrice, 2)}");
            receipt.Append(System.Environment.NewLine);
            receipt.Append(System.Environment.NewLine);
            receipt.Append("           Thank you            ");
            receipt.Append(System.Environment.NewLine);
            receipt.Append("        For your order!         ");


            Console.WriteLine(receipt);
            return returnPrice;
        }



        public static Dictionary<string, int> PopulateTracker()
        {
            Dictionary<string, int> discountTracker = new Dictionary<string, int>
            {
                {"BGLO", 0},
                {"BGLP", 0},
                {"BGLE", 0},
                {"BGLS", 0},
                {"COFB", 0},
                {"COFW", 0},
                {"COFC", 0},
                {"COFL", 0},
                {"FILB", 0},
                {"FILE", 0},
                {"FILC", 0},
                {"FILX", 0},
                {"FILS", 0},
                {"FILH", 0}
            };

            return discountTracker;
        }

        public static string PrintReceipt()
        {
            return "receipt";
        }
    }
}
