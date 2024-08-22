using exercise.main;
using exercise.main.products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    public class Extension3_tests
    {
        public void SetBsketSizeToThirty(Customer p)
        {
            Manager M = new Manager("Manager");
            M.SetMaxSize(30, p);
        }
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
            Console.WriteLine(p.GetReceiptWithDiiscount());
        }

        [Test]
        public void TestPlainReceipt_2()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToThirty(p);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            Console.WriteLine(p.GetReceiptWithDiiscount());
        }

        [Test]
        public void TestPlainReceipt_3()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToThirty(p);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            Console.WriteLine(p.GetReceiptWithDiiscount());
        }

        [Test]
        public void TestPlainReceipt_4()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToThirty(p);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.COFB);

            Console.WriteLine(p.GetReceiptWithDiiscount());
        }

        [Test]
        public void TestPlainReceipt_5()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToThirty(p);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.BGLO);

            p.Basket.addItemToBascet(productType.BGLE);
            p.Basket.addItemToBascet(productType.BGLE);
            p.Basket.addItemToBascet(productType.BGLE);
            p.Basket.addItemToBascet(productType.BGLE);
            p.Basket.addItemToBascet(productType.BGLE);
            p.Basket.addItemToBascet(productType.BGLE);

            p.Basket.addItemToBascet(productType.FILB);

            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.COFB);

            Console.WriteLine(p.GetReceiptWithDiiscount());
        }
    }
}
