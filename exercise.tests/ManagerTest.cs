using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    public class ManagerTest
    {

        [TestCase(2)]
        [TestCase(-2)]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(27)]
        [TestCase(38)]
        [TestCase(8)]
        [TestCase(-444)]
        public void TestChangeCapacity(int newCapacity)
        {
            Manager manager = new Manager();
            bool expected = true;
            if(newCapacity < 0)
            {
                expected = false;
            }
 
            bool result = manager.ChangeCapcity(newCapacity);

            Assert.That(result == expected);
        }



        [TestCase("Bagel", "Onion", 5.0, 2, true)]
        [TestCase("Bagol", "Onion", 5.0, 2, false)]
        [TestCase("Bagel", "Pineapple", 5.0, 2, false)]
        [TestCase("Bagel", "Onion", 0.1, 2, false)]
        [TestCase("Bagel", "Onion", 5.0, 22, false)]
        [TestCase("Coffee", "Black", 5.0, 2, true)]
        [TestCase("Filling", "Bacon", 5.0, 2, true)]
        [TestCase("Filling", "Egg", 5.0, 0, true)]
        public void TestConfirmOrder(string name, string variant, double remainingFunds, int basketSize, bool expected)
        {
            Manager manager = new Manager();
            //if no filling, string filling = string.empty

            bool result = manager.ConfirmOrder(name, variant, remainingFunds, basketSize);

            Assert.That(result == expected);
        }
    }
}
