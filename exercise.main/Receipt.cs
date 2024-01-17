using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        private DateTime _timeInfo = DateTime.Now;
        private double _totalPrice;
        private double _totalPrice1;
        private double _totalDiscount;
        private string _title = $"{"",4}~~~ Bob's Bagels ~~~";
        private string _footer = $"{"",7}Thank you \n{"",4}for you order!";
        private string _enter = "\n";
        private string _line = "----------------------------";
       

        // Diction of <variant,(qty,double)>
        private Dictionary<string, (int qty,double price)> _cashier = new Dictionary<string, (int,double)>();
       
        
        public Receipt(Basket basket)
        {
            var _basket = basket.getBasket();
            _totalPrice = Math.Round(basket.getTotalPrice(),2);
            _totalDiscount = Math.Round(basket.checkDisCount(),2);
            
            foreach (var product in _basket)
            {
                int _qty = 1;    //Start with 1
                string _variant = string.Join(" ", product.variant, product.name);
                double _price = product.getPrice();
                if (_cashier.ContainsKey(_variant)) {
                    _qty = _cashier[_variant].qty + 1;      // Access the existed qty and add 1 to it.
                }

                _cashier[_variant] = (_qty, _price);
            }

        }

        public void printReceipt() {
            Console.WriteLine(_title,1000);
            Console.WriteLine(_enter);
            Console.WriteLine($"{"",4}{_timeInfo}");
            Console.WriteLine(_line);
            Console.WriteLine(_enter);

            Console.WriteLine("Variant       Qty.    Price");
            Console.WriteLine(_enter);

            foreach (var product in _cashier) {
                int _qty = product.Value.qty;  
                string _variant = product.Key;
                double _price = product.Value.price;
                Console.WriteLine("{0}      {1}     {2}", _variant,_qty,_price);
                //Console.WriteLine($"{_qty},{_variant},{_price}");
                _totalPrice1 += _price * _qty;
            }
            Console.WriteLine(_enter);
            
        

            Console.WriteLine(_line);
            Console.WriteLine($"Price               £{_totalPrice1}");
            Console.WriteLine($"Discount           -£{_totalDiscount}");
            Console.WriteLine(_line);
            Console.WriteLine($"Total               £{_totalPrice}");
            Console.WriteLine(_enter);
            Console.WriteLine($"You saved a total of {_totalDiscount} \n    on this shop");
            Console.WriteLine(_enter);
            Console.WriteLine(_footer);
            Console.WriteLine(_enter);
            Console.WriteLine(_enter);



        }

    }
}
