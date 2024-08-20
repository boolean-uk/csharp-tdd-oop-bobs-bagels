using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
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
            this.combined = date.Add(time);
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

                ReceiptString += $"{i.Key}   {i.Value}  £{permanentBasketCopy.FirstOrDefault(p => p.Name.Equals(i.Key)).Cost}\n";
            }
            ReceiptString += $"----------------------------\nTotal                 £{discount.ValidateDiscounts()}\n";
            ReceiptString += $"  You saved a total of £{v - discount.ValidateDiscounts()} \n       on this shop\n\n         Thank you\n\n      for your order!\n";

            return ReceiptString;
            }
        }
    }
