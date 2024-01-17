using exercise.main.Core;
using exercise.main.Objects.Containers;
using exercise.main.Objects.People;
using exercise.main.Objects.Products;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Objects.Tools
{
    public class Checkout
    {

        public Checkout() { 
        
        }

        public bool PurchaseWares(Person payer, List<Product> stock, List<Discount> discounts)
        {
            /*
            // --- Calculate Discounts ---
            List<Ware> basketContents = payer.Basket.Contents;
            double totalCostUndiscounted = payer.Basket.GetPriceTotal();
            // Tuple contains <SKU, moneyToRemoveFromProduct>
            List<Tuple<string, double>> discountsToGivePayer = new List<Tuple<string, double>>();

            // Discovers discounted elements within the list(basketContents) and removes them.
            foreach (Discount discount in discounts) {

                // Find the group of products that the given discount affects
                var group = basketContents.Where(x => x.SKU.StartsWith(discount.SKU)).ToList();
                if (group.Count() < discount.Amount)
                    break;

                int discountCount = 0;
                // Removes multiple times based on discount.
                while (group.Count() >= discount.Amount)
                {
                    int removedCount = 0;
                    
                    // Remove X elements from the basketContents
                    basketContents.RemoveAll(x =>
                    {
                        if (removedCount < discount.Amount)
                        {
                            removedCount++;
                            group.Remove(group.First());
                            return true;
                        }
                        return false;
                    });

                    discountCount++;

                    if (discount.IsMultipleUse)
                        break;
                }
                
                if (discountCount > 0)
                {
                    Product productToDiscount = stock.First(x => x.SKU == discount.SKU);
                    double amountToSubtract = (discount.Price - (discount.Amount * productToDiscount.GetPriceSingle())) * discountCount;
                    discountsToGivePayer.Add(new Tuple<string, double>(discount.SKU.ToString(), amountToSubtract));
                }
            }


            // --- Check If Payer Can Afford ---
            double totalCostDiscounted = totalCostUndiscounted - discountsToGivePayer.Sum(x => x.Item2);

            if (payer.money < totalCostDiscounted)
                return false;


            // --- Print Reciept ---
            basketContents = payer.Basket.Contents;
            PrintReciept(basketContents, discountsToGivePayer);


            // --- Pay For Product ---
            payer.money -= totalCostDiscounted;

            foreach (var ware in payer.Basket.Contents)
                payer.AddToInventory(ware);
            payer.Basket.Contents.Clear();

            return true;*/

            throw new NotImplementedException();
        }


        /* EXAMPLE RECIEPT
         *      ~~~ Bob's Bagels ~~~
         *      
         *      2021-03-16 21:38:44
         *      
         * ------------------------------
         * Onion Bagel        2     £0.98
         * Filling
         *                       (-£0.20)
         * Plain Bagel        12    £3.99
         * Coffee             3     £2.97
         * Everything Bagel   6     £2.49
         * ------------------------------
         * Total                   £10.43
         *           Thank you
         *        for your order!
         */

        protected internal void PrintReciept(List<Ware> wares, List<Tuple<string, double>> discountToGivePayer)
        {
            double sum = 0.0d;

            Console.WriteLine("     ~~~ Bob's Bagels ~~~\n");
            Console.WriteLine("     2021-03-16 21:38:44\n");
            Console.WriteLine("------------------------------");

            // Write a line to console of the product, amount of product, + attachment - discount


            foreach(var ware in wares)
            {
                string lineToPrint = $"{ware.Variant} {ware.Name}";
                string costStr = $" £{ware.GetPriceSingle()}";

                Console.WriteLine(lineToPrint);

                if (ware.Attachment != null)
                {
                    string lineToPrint1 = ware.Variant.ToString() + " " + ware.Name.ToString();
                    string costStr1 = $"£{ware.GetPriceSingle()}";

                    Console.WriteLine(lineToPrint1);
                }


                //Check if product was discounted
                var discount = discountToGivePayer.Find(x => x.Item1 == ware.SKU);
                if (discount != null)
                {
                    string discountStr = $"(-£{discount.Item2})";
                    discountStr.PadLeft(30 - discountStr.Length);
                    Console.WriteLine(discountStr);
                }
            }

            Console.WriteLine("------------------------------");

            string sumStr = "Total"; 
            sumStr.PadRight(24 - sum.ToString().Count());
            sumStr += $"£{sum}";
            Console.WriteLine(sumStr);

            Console.WriteLine("          Thank you");
            Console.WriteLine("       for your order!");
        }
    }
}
