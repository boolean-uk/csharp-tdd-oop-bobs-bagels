using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt 
    {
        private bool _isPurchased;

        private Basket _basket;


        public Receipt(string storename, List<Purchase> products, double totalcost ) {
            
            this.StoreName = storename; 
            this.Products = products;
            this.TotalCost = totalcost;


        
        }
        
        public string ReceiptToString()
        {
            string receipt = $"        ~~~{StoreName}~~~         \n" +
                $"        {DateTime.Now:yyyy-MM-dd HH:mm:ss}           \n\n" +
                $"----------------------------------- \n\n";
           
            foreach (var item in Products)
            {
                string varName = $"{item.Variant} {item.Name}".PadRight(25);
                receipt += $"{varName}{item.Quantity}   £{item.Price} \n";
            }
            receipt += "----------------------------------- \n" +
               $"Total{new string(' ', 24)}£{TotalCost:F2}\n\n" +
               "            Thank you \n          for your order!\n";

            return receipt;

        }
        public string StoreName { get; set; }
        public List<Purchase> Products { get; set; }
        public double TotalCost { get; set; }
        public Basket Basket { get; set; }

        public bool IsPurchased { get { return _isPurchased; } set { _isPurchased = value; } }

    }
}
