using exercise.main;
using exercise.main.products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    internal class Extension1_tests
    {
        public void SetBsketSizeToThirty( Customer p)
        {
            Manager M = new Manager("Manager");
            M.SetMaxSize(30, p);
        }
        
        public void PoppulateBaskets(int i, Customer p, productType productType)
        {

            for (int j = 0; j < i; j++)
            {
                p.Basket.addItemToBascet(productType);
            }

        }

        [Test]
        public void SixBagles_DiscountTest()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToThirty(p);
            PoppulateBaskets(6, p,productType.BGLO);
            Assert.That(p.ImplementDiscount() == 2.49f);
        }

        [Test]
        public void Twelve_DiscountTest()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToThirty(p);
            PoppulateBaskets(12, p, productType.BGLP);
            Assert.That(p.ImplementDiscount() == 3.99f);
        }

        [Test]
        public void BGLE_DiscountTest()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToThirty(p);
            PoppulateBaskets(6, p, productType.BGLE);
            Assert.That(p.ImplementDiscount().Equals(2.49f));
        }

        [Test]
        public void COFB_DiscountTest()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToThirty(p);
            p.Basket.addItemToBascet(productType.BGLO);
            p.Basket.addItemToBascet(productType.COFB);
            Assert.That(p.ImplementDiscount() == 1.25f);
        }

        [Test]
        public void comboTest_1()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToThirty(p);
            PoppulateBaskets(6, p, productType.BGLE);
            PoppulateBaskets(6, p, productType.BGLO);
            Assert.That(p.ImplementDiscount(), Is.EqualTo((float)Math.Round((2.49f + 2.49f), 2)));
        }

        [Test]
        public void comboTest_2()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToThirty(p);
            PoppulateBaskets(6, p, productType.BGLE);
            PoppulateBaskets(6, p, productType.BGLO);
            PoppulateBaskets(6, p, productType.BGLO);
            Assert.That(p.ImplementDiscount() == (float)Math.Round((3.99f + 2.49f),2));
        }

        [Test]
        public void comboTest_3()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToThirty(p);
            PoppulateBaskets(6, p, productType.BGLE);
            PoppulateBaskets(12, p, productType.BGLO);
            PoppulateBaskets(3, p, productType.BGLP);
            p.Basket.addItemToBascet(productType.COFB);
            p.Basket.addItemToBascet(productType.COFB);
            Assert.That(p.ImplementDiscount(), Is.EqualTo((float)Math.Round((3.99f + 2.49f+1.25f +1.25f + 0.39f), 2)));
        }
    }
}

