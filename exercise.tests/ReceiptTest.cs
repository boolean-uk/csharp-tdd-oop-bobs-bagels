using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    public  class ReceiptTest
    {

        [TestCase(2, 3, false)]
        [TestCase(1, 7, true)]
        [TestCase(8, 3, false)]
        [TestCase(16, 7, false)]
        [TestCase(12, 5, true)]
        [TestCase(0, 0, false)]
        [TestCase(15, 33, false)]
        public void TestPrintReceipt(int buyBagel, int buyCoffee, bool filling)
        {
            Customer customer = new Customer(2222.0);
            Basket basket = new Basket();

            

            for(int i = 0; i < buyBagel; i++)
            {
                customer.AddToBasket("Bagel", "Onion");
                customer.AddToBasket("Bagel", "Everything");
                customer.AddToBasket("Bagel", "Everything");
                if (filling)
                {
                    customer.AddToBasket("Bagel", "Sesame", "Bacon");
                }
            }
            for(int i = 0; i < buyCoffee; i++)
            {
                customer.AddToBasket("Coffee", "Black");
                customer.AddToBasket("Coffee", "Black");
                customer.AddToBasket("Coffee", "Latte");
            }
            // now our customer is ready to order

            bool result = customer.Purchase();

            if(buyBagel <= 0 && buyCoffee <= 0) //nothing in cart
            {
                Assert.That(result, Is.False);
            }
            else
            {
                Assert.That(result, Is.True);
            }
        }
    }
}
