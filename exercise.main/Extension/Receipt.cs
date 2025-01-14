using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Extension
{
    public class Receipt
    {
        private readonly List<(string name, int quantity, double totalCost, double savings)> items = new();
        private double totalCost;

        // Add item to the receipt
        public void AddItem(string name, int quantity, double totalCost, double savings = 0.0)
        {
            items.Add((name, quantity, totalCost, savings));
        }

        // Calculate total cost
        public void CalculateTotal()
        {
            totalCost = items.Sum(item => item.totalCost);
        }

        // Extension 2: Receipt
        public string GenerateReceipt()
        {
            var receiptOutput = new StringBuilder();

            // Add header
            receiptOutput.AppendLine("    ~~~ Bob's Bagels ~~~");
            receiptOutput.AppendLine($"    {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            receiptOutput.AppendLine("----------------------------");

            // Add items
            foreach (var item in items)
            {
                receiptOutput.AppendLine($"{item.name,-20} {item.quantity}   £{item.totalCost:F2}".Replace(',', '.'));
                if (item.savings > 0)
                {
                    receiptOutput.AppendLine($"                     (-£{item.savings:F2})".Replace(',', '.'));
                }
            }

            // Add total
            receiptOutput.AppendLine("----------------------------");
            receiptOutput.AppendLine($"Total                 £{totalCost:F2}".Replace(',', '.'));
            receiptOutput.AppendLine("        Thank you");
            receiptOutput.AppendLine("      for your order!");

            return receiptOutput.ToString();
        }




    }

}
