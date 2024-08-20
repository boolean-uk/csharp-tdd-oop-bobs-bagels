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
            string receipt = $"~~~ {StoreName}~~~\\n\" +\r\n     " +
                $"          $\"{DateTime.Now} \\n\" +\r\n        " +
                $"       \"---------------------------- \\n\"";
           
            foreach (var item in Products)
            {
                receipt += $"{item.Variant} {item.Name} {item.Quantity} £{item.Price} \n";
            }
            receipt += "---------------------------- \n" +
               $"Total                  £{TotalCost}\n" +
               "Thank you \n for your order!";

            return receipt;

        }
        public string StoreName { get; set; }
        public List<Purchase> Products { get; set; }
        public double TotalCost { get; set; }
        public Basket Basket { get; set; }

        public bool IsPurchased { get { return _isPurchased; } set { _isPurchased = value; } }

    }
}
