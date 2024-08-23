/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        private string _storename;
        private List<Item> _purchasedItems = new List<Item>();
        private double _totalprice;
        private int quantity;

        public Receipt(string storename, List<Item> purchasedItems, double totalprice)
        {

            _storename = storename;
            _purchasedItems = purchasedItems;
            _totalprice = totalprice;
        }

        public void printReceipt()
        {
            Item newItem = new Item("BGLO", 0.49, "Bagel", "Onion");

            string sku = newItem.Sku;
            double price = newItem.Price;
            string name = newItem.Name;
            string variant = newItem.Variant;

            foreach (var item in PurchasedItems)
            {
                
            }

        }


        public string Storename { get { return _storename; } }
        public List<Item> PurchasedItems { get { return _purchasedItems; } }

        public double Totalprice { get { return _totalprice; } }

        public int Count { get { return count; }    

    }
}
*/