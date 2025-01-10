using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        private DateTime _receiptDate;
        private DateTime _deliveryTime;
        private string _shopName;
        private double _totalPrice;
        private double _discountPrice;
        private List<Item> _items;
        private string _receipt;

        public Receipt(Basket basket)
        {
            _receiptDate = DateTime.Now;
            _shopName = BobsBagel.Name;
            _totalPrice = basket.GetPrice();
            _discountPrice = basket.GetDiscountPrice();
            _items = basket.Items;
            _receipt = GetReceipt(basket);
        }




        public string GetReceipt(Basket basket)
        {
            StringBuilder sb = new StringBuilder();
            DateTime deliveryTime = DateTime.UtcNow.AddMinutes(150);
    
            
            sb.AppendLine($"        ~~~ Bob's Bagels ~~~\n");
            sb.AppendLine($"     {_receiptDate:yyyy-MM-dd HH:mm:ss}\n");
            sb.AppendLine($"------------------------------\n");

            
            double priceFillings = 0;

            foreach (var item in basket.Items)
            {
                sb.AppendLine($"{item.Name.PadRight(5)} {item.Variant.PadRight(3)} {item.Price:F2}");
                if (item.GetType() == typeof(Bagel))
                {
                    Bagel bagel = (Bagel)item;
                    foreach (var item1 in bagel.Fillings)
                    {
                        sb.AppendLine(" - " + item1.Name + " " + item1.Price);
                        priceFillings += item1.Price;
                    }

                }
            }


            sb.AppendLine($"------------------------------\n");
            double priceBeforeDiscount = basket.GetPrice() + priceFillings;
            priceBeforeDiscount = Math.Round(priceBeforeDiscount, 2);
            double priceAfterDiscount = basket.GetDiscountPrice();
            double savings = priceBeforeDiscount - priceAfterDiscount;
            sb.AppendLine($"   You saved a total of {Math.Round(savings,2)}");
            sb.AppendLine($"   Your total price is: {priceAfterDiscount}");
    
            sb.AppendLine($"           Thank you");
            sb.AppendLine($"        for your order!\n");
            sb.AppendLine($"Estimated delivery time is: {deliveryTime}");

            SMSService sms = new SMSService();
            sms.SendSMS(sb.ToString());
            return sb.ToString(); 


        }

        public void PrintReceipt()
        {
            Console.WriteLine(_receipt);
        }
    }
}
