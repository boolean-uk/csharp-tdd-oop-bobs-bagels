using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    public class CustomerTest
    {

        [TestCase("Bagel", "Plain", 2.0, new bool[] {true, true})]
        public void TestAddToBasket(string name, string variant, double remainingFunds,bool[] expected)
        {
            Customer customer = new Customer(remainingFunds);

            for(int i = 0; i < expected.Length; i++)
            {
                bool result = customer.AddToBasket(name, variant, remainingFunds);
                Assert.That(result == expected[i]);
            }
        }



        [TestCase("Bagel", "Plain", 2.0, "Bacon", new bool[] { true, true })]
        public void TestAddToBasket(string name, string variant, double remainingFunds, string filling, bool[] expected)
        {
            Customer customer = new Customer(remainingFunds);

            for (int i = 0; i < expected.Length; i++)
            {
                bool result = customer.AddToBasket(name, variant, remainingFunds, filling);
                Assert.That(result == expected[i]);
            }
        }
    }
}
