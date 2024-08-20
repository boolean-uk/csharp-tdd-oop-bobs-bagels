using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    internal class Extension2_tests
    {
        public Customer createCustomerAndItems()
        {
            Customer p = new Customer("Tom");
            p.addItemToBascet(bagleType.BGLO);
            p.addItemToBascet(drinkType.COFB);
            p.addItemToBascet(drinkType.COFB);
            p.addItemToBascet(fillingType.FILS);
            return p;
        }

        [Test]
        public void TestPlainReceipt_1()
        {
            Customer p = createCustomerAndItems();
            Console.WriteLine(p.GetPlainReceipt());
        }
    }
}
