using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        public string StoreName { get; set; }
        public List<Purchase> Products { get; set; }
        public double TotalCost { get; set; }



        public Receipt(string storename, List<Purchase> products, double totalcost ) {
            
            Console.WriteLine($"~~~ {StoreName}~~~\n" +
                $"{DateTime.Now} \n" +
                "---------------------------- \n" );
            foreach(var item in Products)
            {
                Console.WriteLine($"{item.Variant} {item.Name} {item.Quantity} £{item.Price}");
            }
            Console.WriteLine("---------------------------- \n" +
               $"Total                  £{TotalCost}\n" +
               "Thank you \n for your order!");
            

        
        }

    }
}
