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
        public void ChangeCapacity(int newCapacity)
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
    }
}
