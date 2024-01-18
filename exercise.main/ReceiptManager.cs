using exercise.main.Products;
using exercise.main.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class ReceiptManager
    {
        private string _currency;
        private int _leftColumnWidth;
        private int _middleColumnWidth;
        private int _rightColumnWidth;
        private int _totalColumnWidth;
        public ReceiptManager() 
        {
            _currency = "$";
            _leftColumnWidth = 20;
            _middleColumnWidth = 7;
            _rightColumnWidth = 9;
            _totalColumnWidth = _leftColumnWidth + _middleColumnWidth + _rightColumnWidth;
        }

        /// <summary>
        /// Print the content and price of the provided basket item to a nicely formatted console output.
        /// </summary>
        /// <param name="basket"> A basket of the items to generate a receipt for</param>
        /// <param name="user"> The owner of the basket item provided </param>
        public void PrintReceipt(Basket basket, Person user) 
        {
            // Make it so that the float presents with "." as seperator instead of ","
            CultureInfo culture = new CultureInfo("en-US");
            // Set the current culture to the one with a dot as the decimal separator
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;


            List<IProduct> products = basket.GetProducts();
            float totalPrice = basket.GetBasketPrice(); // This does NOT include discount!

            PrintHeader(user);
            PrintItemizedLines(products, totalPrice);
            PrintFooter();
        }

        /// <summary>
        /// Print all provided products to console
        /// </summary>
        /// <param name="products"> List of products that is in the current basket</param>
        /// <param name="totalPrice">A total price for all the products</param>
        private void PrintItemizedLines(List<IProduct> products, float totalPrice) 
        {
            foreach (IProduct prod in products) 
            {
                Tuple<string, string> item = TranslateSKU.GetNameAndVariantFromSKU(prod.GetSKUName());
                Console.WriteLine(
                    $"| {item.Item2} {item.Item1.ToLower()}".PadRight(_leftColumnWidth)
                    +$"".PadRight(_middleColumnWidth)
                    +$"{prod.GetPrice():F2} {_currency}".PadRight(_rightColumnWidth) 
                    + "|"
                    ) ;
                if (prod is Bagel) 
                {
                    foreach (Filling fill in (prod as Bagel).GetFilling()) 
                    {
                        Tuple<string, string> fillItem = TranslateSKU.GetNameAndVariantFromSKU(fill.SKUName);
                        Console.WriteLine(
                            $"|  -{fillItem.Item2}".PadRight(_leftColumnWidth)
                            + $"".PadRight(_middleColumnWidth)
                            + $"{fill.GetPrice():F2} {_currency}".PadRight(_rightColumnWidth)
                            + "|"
                            );
                    }
                }
            }
            Console.WriteLine("|" + "|".PadLeft(_totalColumnWidth));
            Console.WriteLine($"| Total:".PadRight(_leftColumnWidth) + $"".PadRight(_middleColumnWidth) + $"{totalPrice:F2} {_currency}".PadRight(_rightColumnWidth) + "|");
        }

        /// <summary>
        /// Print the header start of the receipt
        /// </summary>
        /// <param name="user"> The operator/user that is purchasing the basket</param>
        private void PrintHeader(Person user)
        {
            string[] bobBagels = new string[]
{
            "|     .------.    .------.          |",
            "|    /  Bob's \\  / Bagels \\         |",
            "|   |`-------'| |'-------'|         |",
            "|    \\       /   \\       /          |",
            "|     `-----'     `-----'           |"
};
            Console.WriteLine(new string('-', _totalColumnWidth + 1));
            foreach (string bob in bobBagels) 
            {
                Console.WriteLine(bob);
            }

            Console.WriteLine("|".PadRight(_totalColumnWidth / 2) + "|".PadLeft((_totalColumnWidth / 2 + 1)));
            string userName = $"| Customer: {user.Name}";
            Console.WriteLine(userName.PadRight(_totalColumnWidth / 2) + "|".PadLeft((_totalColumnWidth / 2) + 1));

            Console.WriteLine(new string('-', _totalColumnWidth + 1));

            string time = $"| time: {DateTime.Now.ToString("HH: mm: ss")}";
            Console.WriteLine(time.PadRight(_totalColumnWidth /2) + "|".PadLeft((_totalColumnWidth / 2) + 1));

            string date = $"| date: {DateTime.Now.ToString("dd.mm.yyyy")}";
            Console.WriteLine(date.PadRight(_totalColumnWidth /2  ) + "|".PadLeft((_totalColumnWidth / 2) + 1));

            Console.WriteLine(new string('-', _totalColumnWidth + 1));
        }

        /// <summary>
        /// Print the footer ending of the receipt
        /// </summary>
        private void PrintFooter() 
        {
            Console.WriteLine(new string('-', _totalColumnWidth+1));
            Console.WriteLine($"| Thank you for your purchase at".PadLeft(_totalColumnWidth / 2) + "|".PadLeft(5));
            Console.WriteLine($"| Bob's Bagels!".PadLeft(_totalColumnWidth / 2 - 4) + "|".PadLeft(22));
            Console.WriteLine(new string('-', _totalColumnWidth + 1));
        }
    }
}
