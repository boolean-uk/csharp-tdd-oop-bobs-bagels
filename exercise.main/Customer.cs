using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Extensions;

namespace exercise.main
{
    public class Customer 
    {
        private Basket basket;
        private string name;

        public Customer(string name)
        {
            this.basket = new Basket();
            this.name = name;
        }

        public Basket Basket { get { return basket; } }

        public float ImplementDiscount()
        {
            Extension1 discount = new Extension1(this.basket.GetBasket(), this.basket.GetCost());
            return discount.ValidateDiscounts();
        }

        public string GetPlainReceipt()
        {
            Extension2 receipt = new Extension2(this.basket.GetBasket());
            return receipt.Receipt(this.basket.GetCost());
        }

        public string GetReceiptWithDiiscount()
        {
            Extension3 receipt = new Extension3(this.basket.GetBasket());
            return receipt.ReciptWithDiscount(this.basket.GetCost());
        }
    }
}
