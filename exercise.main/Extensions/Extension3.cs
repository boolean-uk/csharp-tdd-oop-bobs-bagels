using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.products;

namespace exercise.main.Extensions
{
    internal class Extension3
    {

        private DateTime combined;
        private List<Product> basketCopy;
        private Dictionary<string, int> productAmount;
        private List<Product> permanentBasketCopy;
        public Extension3(List<Product> basket)
        {
            basketCopy = basket;
            permanentBasketCopy = basket.ToList();

            productAmount = new Dictionary<string, int>();
        }

        public string ReciptWithDiscount(float v)
        {

            DateTime date = DateTime.Now;
            TimeSpan time = new TimeSpan(36, 0, 0, 0);
            combined = date.Add(time);
            Extension1 discount = new Extension1(basketCopy, v);

            Dictionary<string, int> discounts = discount.GetRecieptDiscount();



            string ReceiptString = $"    ~~~ Bob's Bagels ~~~ \n\n    {combined} \n\n----------------------------\n";
            foreach (Product product in permanentBasketCopy)
            {
                if (productAmount.ContainsKey(product.Name))
                {
                    productAmount[product.Name]++;
                }
                else
                {
                    productAmount.Add(product.Name, 1);
                }

            }

            foreach (KeyValuePair<string, int> i in productAmount)
            {

                if (discounts.ContainsKey(i.Key))
                {
                    ReceiptString += $"{i.Key}   {i.Value}  £{permanentBasketCopy.FirstOrDefault(p => p.Name.Equals(i.Key)).Cost}\n";
                    Console.WriteLine("Value: " + i.Value);
                    if (12 > i.Value && i.Value >= 6)
                    {
                        ReceiptString += $"            (- £{(float)Math.Round(permanentBasketCopy.FirstOrDefault(p => p.Name.Equals(i.Key)).Cost * i.Value - 2.49f, 2)})\n";

                    }
                    else if (16 > i.Value && i.Value >= 12)
                    {
                        ReceiptString += $"            (- £{(float)Math.Round(permanentBasketCopy.FirstOrDefault(p => p.Name.Equals(i.Key)).Cost * i.Value - 3.99f, 2)})\n";

                    }
                    else if (16 <= i.Value)
                    {
                        ReceiptString += $"            (- £{(float)Math.Round(permanentBasketCopy.FirstOrDefault(p => p.Name.Equals(i.Key)).Cost * i.Value - 3.99f - 2.49f, 2)})\n";

                    }
                    else if (i.Key == "Black Coffe" || i.Key == "White Coffe")
                    {
                        ReceiptString += $"            (- £{(float)Math.Round(permanentBasketCopy.FirstOrDefault(p => p.Name.Equals(i.Key)).Cost * i.Value + 0.49 - 1.25f, 2)})\n";
                    }

                }
                else
                {
                    ReceiptString += $"{i.Key}   {i.Value}  £{(float)Math.Round(permanentBasketCopy.FirstOrDefault(p => p.Name.Equals(i.Key)).Cost, 2)}\n";
                }

            }
            ReceiptString += $"----------------------------\nTotal                 £{(float)Math.Round(discount.ValidateDiscounts(), 2)}\n\n ";
            ReceiptString += $"  You saved a total of £{(float)Math.Round(v - discount.ValidateDiscounts(), 2)} \n       on this shop\n\n         Thank you\n\n      for your order!\n";

            return ReceiptString;
        }
    }
}
