using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        private Basket _receiptBasket = new Basket();
        private DateTime _receiptDateTime;
        public Receipt(Basket receiptBasket, DateTime receiptDateTime)
        {

            _receiptBasket = receiptBasket;
            _receiptDateTime = receiptDateTime;
        }

        public Basket ReceiptBasket { get {  return _receiptBasket; } set { _receiptBasket = value; } }
        public DateTime ReceiptDateTime {  get { return _receiptDateTime; } set { _receiptDateTime = value; } }


        public void PrintReceipt()
        {
            Console.WriteLine("");
            Console.WriteLine("           ~~~Bob's Bagels ~~~    ");
            Console.WriteLine("");
            Console.WriteLine("           "  +  ReceiptDateTime.ToString());
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("");
            List<Item> receiptItems = ReceiptBasket.BasketItems;
            foreach(var item in receiptItems)
            {
                if(item.Sku == "COFW")
                {
                    Console.WriteLine($"{item.Variant} {item.Name} {String.Format("{0, 21}", item.Quantity)} £{Math.Round(item.Quantity * item.Price, 2)}");
                } else
                {
                    Console.WriteLine($"{item.Variant} {item.Name} {String.Format("{0, 22}", item.Quantity)} £{Math.Round(item.Quantity * item.Price, 2)}");
                }
                
            }
            Console.WriteLine("");
            double total = ReceiptBasket.TotalCostBasket();
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("");
            Console.WriteLine($"Total                               £{total}");
            Console.WriteLine("");
            Console.WriteLine("               Thank you");
            Console.WriteLine("             for your order!");
           
        }


    }
}
