using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    internal class Extension2
    {

        private DateTime combined;
        private List<Product> basketCopy;
        private Dictionary<string, int> productAmount;
        public Extension2(List<Product> basket) {
            basketCopy = basket;
            productAmount = new Dictionary<string, int>();
        }

        public string Receipt(float v)
        {


            DateTime date = DateTime.Now;
            TimeSpan time = new TimeSpan(36, 0, 0, 0);
            this.combined = date.Add(time);


            string ReceiptString = $"    ~~~ Bob's Bagels ~~~ \n\n    {combined} \n\n----------------------------\n";
            foreach (Product product in basketCopy)
            {
                if (productAmount.ContainsKey(product.Name))
                {
                    productAmount[product.Name]++;
                } else
                {
                    productAmount.Add(product.Name, 1);
                }
                 
            }

            foreach (KeyValuePair<string, int> i in productAmount) {

                ReceiptString += $"{i.Key}   {i.Value}  £{basketCopy.FirstOrDefault(p => p.Name.Equals(i.Key)).Cost}\n";
            }

            ReceiptString += $"----------------------------\nTotal                 £{v}\n\n         Thank you\n\n      for your order!";

            return ReceiptString;
        }

        public string ReciptWithDiscount(float v)
        {

            DateTime date = DateTime.Now;
            TimeSpan time = new TimeSpan(36, 0, 0, 0);
            this.combined = date.Add(time);
            Extension1 discount = new Extension1(basketCopy, v);

            Dictionary<string, int> discounts = discount.GetRecieptDiscount();

            string ReceiptString = $"    ~~~ Bob's Bagels ~~~ \n\n    {combined} \n\n----------------------------\n";
            foreach (Product product in basketCopy)
            {
                if (productAmount.ContainsKey(product.Name))
                {
                    productAmount[product.Name]++;
                }
                else
                {
                    productAmount.Add(product.Name, 0);
                }

            }

            foreach (KeyValuePair<string, int> i in productAmount)
            {

                ReceiptString += $"{i.Key}   {i.Value}  £{basketCopy.FirstOrDefault(p => p.Name.Equals(i.Key)).Cost}\n";
            }

            return ReceiptString;
        }

    }
}
