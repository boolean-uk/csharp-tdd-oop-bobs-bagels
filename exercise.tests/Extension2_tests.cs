using exercise.main;
using exercise.main.products;
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
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.COFB);
            p.Basket.addItemToBascet(productType.COFB);
            p.Basket.addItemToBascet(productType.FILS);
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
