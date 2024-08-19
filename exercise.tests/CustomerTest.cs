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
        [TestCase("Fish", "Plain", 2.0, new bool[] { false, false })]
        [TestCase("Bagel", "Kangeroo", 2.0, new bool[] { false, false })]
        [TestCase("Bagel", "Plain", 0.6, new bool[] { true, false })]
        [TestCase("Bagel", "Plain", 222.0, new bool[] { true, true, true, true, true, false, false })]
        [TestCase("Coffee", "White", 2.0, new bool[] { true, false })]
        public void TestAddToBasket(string name, string variant, double funds,bool[] expected)
        {
            Customer customer = new Customer(funds);

            for(int i = 0; i < expected.Length; i++)
            {
                bool result = customer.AddToBasket(name, variant);
                Assert.That(result == expected[i]);
            }
        }



        [TestCase("Bagel", "Plain", 2.0, "Bacon", new bool[] { true, true })]
        [TestCase("Fish", "Plain", 2.0, "Bacon", new bool[] { false, false })]
        [TestCase("Bagel", "Kangeroo", 2.0, "Bacon", new bool[] { false, false })]
        [TestCase("Bagel", "Plain", 0.7, "Egg", new bool[] { true, false })]
        [TestCase("Bagel", "Plain", 222.0, "Cheese", new bool[] { true, true, true, true, true, false, false })]
        [TestCase("Coffee", "White", 2.0, "Bacon", new bool[] { false, false })]
        public void TestAddToBasketWithFilling(string name, string variant, double funds, string filling, bool[] expected)
        {
            Customer customer = new Customer(funds);

            for (int i = 0; i < expected.Length; i++)
            {
                bool result = customer.AddToBasket(name, variant, filling);
                Assert.That(result == expected[i]);
            }
        }


        //[TestCase("Bagel", "Plain", 2.0, new bool[] { true, true })]
        //[TestCase("Fish", "Plain", 2.0, new bool[] { false, false })]
        //[TestCase("Bagel", "Kangeroo", 2.0, new bool[] { false, false })]
        //[TestCase("Bagel", "Plain", 0.6, new bool[] { true, false })]
        //[TestCase("Bagel", "Plain", 222.0, new bool[] { true, true, true, true, true, false, false })]
        //[TestCase("Coffee", "White", 2.0, new bool[] { true, false })]
        //public void TestShowCost(string name, string variant, double funds)
        //{
        //    Customer customer = new Customer(funds);

        //    for (int i = 0; i < expected.Length; i++)
        //    {
        //        bool result = customer.AddToBasket(name, variant, funds);
        //        Assert.That(result == expected[i]);
        //    }
        //}
    }
}
