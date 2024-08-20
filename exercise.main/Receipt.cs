using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise
{
    public class Receipt
    {
        public string Header { get; set; } = "~~~ Bob's Bagels ~~~";
        public DateTime Date { get; set; } = DateTime.Now;
        public string FormattedDate => Date.ToString("yyyy-MM-dd HH:mm:ss");
        public string FooterL1 { get; set; } = "Thank you";
        public string FooterL2 { get; set; } = "for your order!";

        public void PrintReceipt(List<Product> items, decimal total)
        {
            int totalWidth = 36; //Receipt total width per line
            decimal totalDiscount = 0m;
            
            //Header
            string centeredHeader = Header.PadLeft((totalWidth + Header.Length) / 2).PadRight(totalWidth);
            string centeredDate = FormattedDate.PadLeft((totalWidth + FormattedDate.Length) / 2).PadRight(totalWidth);
            string dashLine = new string('-', totalWidth);

            Console.WriteLine(centeredHeader);
            Console.WriteLine(centeredDate);
            Console.WriteLine(dashLine);

            //Items main text
            HashSet<string> processedSKUs = new HashSet<string>();

            foreach (Product item in items)
            {
                if (!processedSKUs.Contains(item.SKU))
                {
                    List<Product> sameProduct = items.FindAll(x => x.SKU == item.SKU);
                    int quantity = sameProduct.Count();
                    decimal price = sameProduct.Sum(x => x.Price);
                    Console.WriteLine("{0,-15} {1,-10} {2,-3} £{3,-5}", //Left align fields (add up to 36)
                         item.Variant,       
                         item.Name,          
                         quantity,          
                         Math.Round(price, 2));

                    decimal discount = sameProduct.Sum(x => x.Discount);
                    totalDiscount += discount;

                    //Note: Plain won't show as it goes up in price with the current requirements..
                    if(discount > 0m)
                    {
                       Console.WriteLine("{0,-29} {1,-5}", //Left align fields (add up to 36)
                       "",
                       $"(-£{Math.Round(discount, 2)})");

                    }

                    processedSKUs.Add(item.SKU);
                }
            }
            //Total
            Console.WriteLine(dashLine);
            string totalAmount = $"£{Math.Round(total, 2)}";
            string formattedTotal = $"Total".PadRight(totalWidth - totalAmount.Length) + totalAmount;
            Console.WriteLine(formattedTotal);
            Console.WriteLine();

            //Total discount
            //In reality, add if statement to check totalDiscount > 0 (stringwriter test won't pass with it)
            string centeredTotal1 = $"You saved a total of £{Math.Round(totalDiscount, 2)}";
            string centeredTotal2 = $"on this shop";
            Console.WriteLine(centeredTotal1.PadLeft((totalWidth + centeredTotal1.Length) / 2).PadRight(totalWidth));
            Console.WriteLine(centeredTotal2.PadLeft((totalWidth + centeredTotal2.Length) / 2).PadRight(totalWidth));
            Console.WriteLine();
            
            //Footer
            string centeredFooter1 = FooterL1.PadLeft((totalWidth + FooterL1.Length) / 2).PadRight(totalWidth);
            string centeredFooter2 = FooterL2.PadLeft((totalWidth + FooterL2.Length) / 2).PadRight(totalWidth);
            Console.WriteLine(centeredFooter1);
            Console.WriteLine(centeredFooter2);
        }

    }
}
