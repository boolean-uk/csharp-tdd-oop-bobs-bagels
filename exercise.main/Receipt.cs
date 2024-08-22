using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt : Basket
    {
        private bool _isPurchased;

        private string _storename;
        private List<Purchase> _products;
        private double _totalcost;

        public Receipt(Basket basket)
        {

            _storename = basket.GetStoreName();
            _products = basket.ListItems();
            _totalcost = _products.Select(x => x.Price).Sum();




        }

        

        public string ReceiptToString()
        {
            string receipt = $"        ~~~{_storename}~~~         \n" +
                $"        {DateTime.Now:yyyy-MM-dd HH:mm:ss}           \n\n" +
                new String('-', 35) + "\n\n";

            foreach (var item in Products)
            {
                string varName = $"{item.Variant} {item.Name}".PadRight(25);
                receipt += $"{varName}{item.Quantity.ToString().PadLeft(2)}   £{item.Price:F2} \n\n";

                if(item.Saved > 0){
                    receipt += new string(' ', 28) +$"(-£{item.Saved:F2}) \n";
                }

            }
            receipt += "\n";

            receipt += new String('-', 35) + "\n" +
               $"Total{new string(' ', 24)}£{_totalcost:F2}\n\n" +
               $"      You saved a total of £{Products.Select(x => x.Saved).Sum():F2} \n          on this shop \n\n" +
               "            Thank you \n          for your order!\n";

            return receipt;

        }

        public string StoreName { get { return _storename; } }
        public List<Purchase> Products { get { return _products; } }




        public bool IsPurchased { get { return _isPurchased; } set { _isPurchased = value; } }

    }
}
