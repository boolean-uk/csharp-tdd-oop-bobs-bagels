using exercise.main.Core;
using exercise.main.Objects.Containers;
using exercise.main.Objects.People;
using exercise.main.Objects.Products;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Mail;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Objects.Tools
{
    public class Checkout
    {

        public Checkout() { 
        
        }

        public bool PurchaseWares(Person payer, List<Discount> discounts)
        {
            List<Ware> nonDiscountedWares = new List<Ware> (payer.Basket.Contents);
            double totalCostUndiscounted = payer.Basket.GetPriceTotal();
            // Tuple contains <SKU, moneyToRemoveFromProduct>
            List<Tuple<string, double, int>> discountsToGivePayer = new List<Tuple<string, double, int>>();

            // --- Calculate Discounts ---
            foreach (Discount discount in discounts)
            {
                bool isMeetingRequirements = true;
                int discountCount = 0; 

                do
                {
                    // Check Requirements
                    foreach (Requirement requirement in discount.Requirement)
                    {
                        var group = nonDiscountedWares.Where(x => x.SKU.StartsWith(requirement.SKU)).ToList();
                        if (group.Count() < requirement.Amount)
                        {
                            isMeetingRequirements = false;
                            break;
                        }

                        if (!isMeetingRequirements)
                            continue;
                    }
                    if (!isMeetingRequirements)
                        break;

                    // DO SOMETHING THAT REMOVES THE PRODUCT FROM THE LIST AND MAKE SURE TO SUBTRACT.
                    foreach (Requirement requirement in discount.Requirement)
                    {
                        int removedCount = 0;
                        // Remove X elements from the basketContents
                        nonDiscountedWares.RemoveAll(x =>
                        {
                            if (removedCount < requirement.Amount)
                            {
                                removedCount++;
                                //group.Remove(group);
                                return true;
                            }
                            return false;
                        });
                    }

                    discountCount++;
                    if (discount.IsMultipleUse)
                        break;

                } while (isMeetingRequirements);

                if(discountCount > 0)
                    discountsToGivePayer.Add(new Tuple<string, double, int>(
                        $"{discount.Requirement.First().SKU}", 
                        discount.Price * discountCount,
                        discountCount)
                        );
            }

            // --- Check If Payer Can Afford ---
            double totalCostDiscounted = nonDiscountedWares.Sum(x => x.GetPrice()) + discountsToGivePayer.Sum(x => x.Item2);

            if (payer.money < totalCostDiscounted)
                return false;
            

            // --- Print Reciept ---
            List<Ware> basketContents = payer.Basket.Contents;
            PrintReciept(payer.Basket.Contents, discountsToGivePayer, totalCostDiscounted);


            // --- Pay For Product ---
            payer.money -= totalCostDiscounted;

            payer.AddToInventory(basketContents);
            payer.Basket.Contents.Clear();

            return true;
        }


        /* EXAMPLE RECIEPT
         *      ~~~ Bob's Bagels ~~~
         *      
         *      2021-03-16 21:38:44
         *      
         * ------------------------------
         * Onion Bagel        2     £3.98
         * + Filling             (+£1.20)
         *                       (-£0.20)
         * Plain Bagel        12    £3.99
         * Coffee             3     £2.97
         * Everything Bagel   6     £2.49
         * ------------------------------
         * Total                   £10.43
         *           Thank you
         *        for your order!
         */

        protected void PrintReciept(List<Ware> wares, List<Tuple<string, double, int>> discountToGivePayer, double totalCost)
        {
            Console.WriteLine("     ~~~ Bob's Bagels ~~~\n");
            Console.WriteLine("     2021-03-16 21:38:44\n");
            Console.WriteLine("------------------------------\n");

            wares = wares.OrderBy(x => x.SKU).ToList();


            List<Ware> uniqueSKUWare = wares.DistinctBy(x => x.SKU).ToList();

            // Pseudo-code: Write a line to console of the product, amount of product, + attachment - discount

            foreach(var ware in uniqueSKUWare)
            {
                List<Ware> specifiedSDKWare = wares.Where(x => x.SKU == ware.SKU).ToList();
                double wareCost = 0.0d;
                double wareDiscountedCost = 0.0d;


                List<Tuple<string, double>> attachments = new List<Tuple<string, double>>();

                foreach (var sWare in specifiedSDKWare)
                {
                    wareCost += sWare.GetPrice();

                    // Check for attachment
                    if (sWare.Attachment != null)
                    {
                        attachments.Add(new Tuple<string, double>(sWare.Attachment.Name, sWare.Attachment.GetPriceSingle()));
                    }
                    
                }

                // Calculate ware cost
                if(discountToGivePayer.Any(x => x.Item1 == ware.SKU))
                {
                    // REMOVED UNTIL DISCOUNT IS PATCHED
                    wareDiscountedCost = wareCost - discountToGivePayer.First(x => x.Item1 == ware.SKU).Item2;
                }

                // --- Print --- 
                PrintWare($"{ware.Variant} {ware.Name}", specifiedSDKWare.Count(), wareCost);
                foreach(Tuple<string, double> attachment in attachments)
                {
                    PrintAttachment(attachment);
                }

                if (discountToGivePayer.Any(x => x.Item1 == ware.SKU))
                {
                    PrintDiscount(discountToGivePayer.First(x => x.Item1 == ware.SKU).Item2);
                }
            }

            Console.WriteLine("\n------------------------------");

            string sumStr = "Total"; 
            sumStr = sumStr.PadRight(29 - Math.Round(totalCost, 2).ToString().Count(), ' ');
            sumStr += $"£{Math.Round(totalCost, 2)}";
            Console.WriteLine(sumStr);

            Console.WriteLine("          Thank you");
            Console.WriteLine("       for your order!");
        }
        private void PrintWare(string wareFullName, int amount, double cost)
        {
            // Print ware
            string lineToPrint = $"{wareFullName}";
            string costStr = $"{amount}  £{Math.Round(cost, 2)}";
            lineToPrint = lineToPrint.PadRight(30 - costStr.Length);
            lineToPrint += costStr;

            Console.WriteLine(lineToPrint);
        }
        private void PrintAttachment(Tuple<string, double> attachment)
        {
            string lineToPrint = $"  + {attachment.Item1}";
            string costStr = $"(+£{Math.Round(attachment.Item2, 2)})";
            lineToPrint = lineToPrint.PadRight(30 - costStr.Length, ' ');
            lineToPrint += costStr;

            Console.WriteLine(lineToPrint);
        }
        private void PrintDiscount(double priceReduction)
        {
            string lineToPrint = "";
            string costStr = $"(-£{Math.Round(priceReduction, 2)})";
            lineToPrint = lineToPrint.PadRight(30 - costStr.Length, ' ');
            lineToPrint += costStr;

            Console.WriteLine(lineToPrint);
        }
    }

}
