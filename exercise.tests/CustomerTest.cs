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
                customer.ShowCost();
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
                customer.ShowCost();
                bool result = customer.AddToBasket(name, variant, filling);
                Assert.That(result == expected[i]);
            }
        }


        [TestCase("Bagel", "Plain", 222.0, 2, 0.78)]
        [TestCase("Fish", "Plain", 222.0, 4, 0.0)]//does not exist
        [TestCase("Bagel", "Kangeroo", 222.0, 2, 0.0)]  //does not exist
        [TestCase("Bagel", "Everything", 0.6, 4, 0.49)]  //fund issue
        [TestCase("Bagel", "Everything", 222.0, 7, 2.45)] //basket overfill
        [TestCase("Coffee", "White", 222.0, 1, 1.19)]
        public void TestShowCost(string name, string variant, double funds, int iterations, double expectedCost)
        {
            Customer customer = new Customer(funds);

            for (int i = 0; i < iterations; i++)
            {
                customer.AddToBasket(name, variant);
            }

            Assert.That(customer.ShowCost() == expectedCost);
        }


        [TestCase("Bagel", "Plain", true)]
        [TestCase("Fish", "Plain", false)]
        [TestCase("Bagel", "Kangeroo", false)]
        [TestCase("Bagel", "Plain", true)]
        [TestCase("Bagel", "Plain", true)]
        [TestCase("Coffee", "White", true)]
        public void TestRemoveFromBasket(string name, string variant, bool expected)
        {
            Customer customer = new Customer(222.0);
            customer.AddToBasket(name, variant);

            bool result = customer.RemoveItem(name, variant);

            Assert.That(result == expected);    
        }
    }
} 
