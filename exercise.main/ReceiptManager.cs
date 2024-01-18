using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class ReceiptManager
    {
        public class Receipt
        {
            public List<Entry> Entries { get; set; }
            public DateTime DateOfPurchase { get; set; }
            public double TotalCost { get; set; }

            public Receipt()
            {
                Entries = new List<Entry>();
                DateTime DateOfPurchase = DateTime.Now;
            }

            public class Entry
            {
                public string Name { get; private set; }
                public int Quantity { get; private set; }
                public double Price { get; private set; }

                public Entry(string name, int quantity, double price)
                {
                    Name = name;
                    Quantity = quantity;
                    Price = price;
                }
            }
        }

        public Receipt GetReceipt(BasketManager.Order order)
        {
            throw new NotImplementedException();
        }

        public void DisplayReceipt(BasketManager.Order order)
        {
            throw new NotImplementedException();
        }
    }
}
