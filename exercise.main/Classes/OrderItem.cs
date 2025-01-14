using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class OrderItem
    {
        public string Sku { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Savings { get; set; }

        public OrderItem(string sku, string itemName, int quantity, decimal? price, decimal? savings)
        {
            Sku = sku; 
            ItemName = itemName;
            Quantity = quantity;
            Price = price;
            Savings = savings;
        }
    }
}
