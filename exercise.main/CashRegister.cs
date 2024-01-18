using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public static class CashRegister
    {

        public static double CalculateReceipt(List<Product> products)
        {
            Dictionary<string, int> discountTracker = PopulateTracker();
            double total = 0.00d;
            if (!products.Any())
            {
                return total;
            }

            int bagels = 0;
            int plainBagels = 0;
            int blackCoffe = 0;
            foreach (Product product in products)
            {
                //discountTracker[product.SKU] += 1;
                if (product.SKU.Contains("BGLP"))
                {
                    plainBagels++;
                }
                else if (product.SKU.Contains("BGL"))
                {
                    bagels++;
                }
                else if (product.SKU.Contains("COFB"))
                {
                    blackCoffe++;
                }
            }

            double twelveDiscount = plainBagels / 12;
            double sixDiscount = bagels / 6;
            double discount = 0.00d;


            //Bagel discount adder
            if (twelveDiscount >= 1)
            {
                for (int i = 0; i < twelveDiscount; i++)
                {
                    discount += 0.69d;
                    plainBagels -= 12;
                }
            }
            if (sixDiscount >= 1)
            {
                for (int i = 0; i < sixDiscount; i++)
                {
                    discount += 0.45d;
                    bagels -= 6;
                }
            }

            //coffee deals discount adder
            if (blackCoffe >= 1 && (plainBagels >= 1 || bagels >= 1))
            {
                for (int i = 0; i < blackCoffe; i++)
                {
                    if (plainBagels >= 1)
                    {
                        discount += 0.13;
                        plainBagels--;
                    }
                    else if (bagels >= 1)
                    {
                        discount += 0.23;
                        bagels--;
                    }
                }

            }

            total = products.Sum(product => product.Price);
            double returnPrice = total - discount;
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
