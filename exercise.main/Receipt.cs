using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        public string ShopName { get; set; }
        public DateTime Date { get; set; }
        public List<ReceiptItem> Items { get; set; } = new List<ReceiptItem>();
        public double TotalCost { get; set; }

        public void PrintReceipt()
        {
            Console.WriteLine($"    ~~~ {ShopName} ~~~");
            Console.WriteLine($"\n    {Date}\n");
            Console.WriteLine("----------------------------\n");

            foreach (var item in Items)
            {
                Console.WriteLine($"{item.Name,-20}{item.Quantity,-5}{item.Price:C}");
            }

            Console.WriteLine("\n----------------------------");
            Console.WriteLine($"Total{new string(' ', 18 - "Total".Length)}{TotalCost:C}\n");
            Console.WriteLine("        Thank you\n      for your order!");
        }
        public class ReceiptItem
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }
        }
    }
}
