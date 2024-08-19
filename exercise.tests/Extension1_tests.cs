using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    internal class Extension1_tests
    {
        public void SetBsketSizeToTwenty( Customer p)
        {
            Manager M = new Manager("Manager");
            M.SetMaxSize(20, p);
        }

        public void PoppulateBaskets(int i, Customer p,productType productType)
        {
            for (int j = 0; j < i; j++)
            {
                p.addItemToBascet(productType);
            }

        }

        [Test]
        public void BGLO_DiscountTest()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToTwenty(p);
            PoppulateBaskets(6, p, productType.BGLO);
            Assert.That(p.ImplementDiscount() == 2.49f);
        }

        [Test]
        public void BGLP_DiscountTest()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToTwenty(p);
            PoppulateBaskets(12, p, productType.BGLP);
            Assert.That(p.ImplementDiscount() == 3.99f);
        }

        [Test]
        public void BGLE_DiscountTest()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToTwenty(p);
            PoppulateBaskets(6, p, productType.BGLE);
            Assert.That(p.ImplementDiscount() == 2.49f);
        }

        [Test]
        public void COFB_DiscountTest()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToTwenty(p);
            p.addItemToBascet(productType.BGLO);
            p.addItemToBascet(productType.COFB);
            Assert.That(p.ImplementDiscount() == 1.25f);
        }

        [Test]
        public void comboTest_1()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToTwenty(p);
            PoppulateBaskets(6, p, productType.BGLE);
            PoppulateBaskets(6, p, productType.BGLO);
            Assert.That(p.ImplementDiscount() == (2.49f + 2.49f));
        }
    }
}

