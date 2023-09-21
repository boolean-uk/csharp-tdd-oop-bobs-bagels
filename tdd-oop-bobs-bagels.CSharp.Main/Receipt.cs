using System.Text;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Receipt
    {
        public List<OrderItem> OrderItems { get; private set; }
        public decimal Total { get; private set; }
        public DateTime PurchaseTime { get; private set; }

        public Receipt()
        {
            OrderItems = new List<OrderItem>();
            PurchaseTime = DateTime.Now;
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
            CalculateTotal();
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            OrderItems.Remove(orderItem);
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            Total = OrderItems.Sum(item => item.TotalPrice());
        }

        public decimal GetTotalSavings()
        {
            return OrderItems.Sum(item => item.OriginalPrice * item.Quantity) - Total;
        }

        public string DisplayItemSavings()
        {
            StringBuilder savingsBuilder = new StringBuilder();
            foreach (var item in OrderItems)
            {
                savingsBuilder.AppendLine($"{item.Product.SKU}: £{item.GetSavings():0.00}");
            }
            return savingsBuilder.ToString();
        }

        public string GeneratePrint()
        {
            return ToString();
        }

        public override string ToString()
        {
            StringBuilder receiptBuilder = new StringBuilder();
            receiptBuilder.AppendLine("~~~ Bob's Bagels ~~~");
            receiptBuilder.AppendLine(PurchaseTime.ToString("yyyy-MM-dd HH:mm:ss"));
            receiptBuilder.AppendLine("\n----------------------------\n");

            foreach (var item in OrderItems)
            {
                string productName = item.Product.Name;
                if (item.Product is Bagel bagel)
                {
                    productName = $"{bagel.Name} ({bagel.Variant})";
                }
                else if (item.Product is Coffee coffee)
                {
                    productName = $"{coffee.Name} Coffee";
                }

                receiptBuilder.AppendLine($"{productName.PadRight(20)} {item.Quantity} £{item.TotalPrice():0.00}");
                if (item.GetSavings() > 0)
                {
                    receiptBuilder.AppendLine($"                     (-£{item.GetSavings():0.00})");
                }
            }

            receiptBuilder.AppendLine("\n----------------------------\n");
            receiptBuilder.AppendLine($"Total                 £{Total:0.00}");
            receiptBuilder.AppendLine($"\nYou saved a total of £{GetTotalSavings():0.00}\non this shop");
            receiptBuilder.AppendLine("\nThank you\nfor your order!");

            return receiptBuilder.ToString();
        }
    }
}