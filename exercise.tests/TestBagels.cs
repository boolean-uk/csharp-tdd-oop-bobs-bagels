using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main;
using NUnit.Framework.Interfaces;

namespace exercise.tests
{
    public class TestBagels
    {
        //[SetUp]
        //public void Setup()
        //{
        //}
        [Test]
        public void TestAddBagel()
        {
           Bagel bagel = new Bagel();
           Assert.AreEqual("BGLO", bagel.AddBagel("BGLO"));
        }

        [Test]
        public void TestRemoveBagel()
        {
            Bagel bagel = new Bagel();
            bagel.AddBagel("BGLO");


            Assert.AreEqual("Bagel removed from basket", bagel.RemoveBagel("BGLO"));
            Assert.AreEqual("Bagel not in basket", bagel.RemoveBagel("BGLO"));
            Assert.AreEqual("Bagel not found", bagel.RemoveBagel("sdfg"));
        }

        [Test]
        public void TestChangeCapacity()
        {
            Bagel bagel = new Bagel();

            Assert.AreEqual(2, bagel.ChangeCap(2));
        }

        [Test]
        public void TestBasketFull()
        {
            Bagel bagel = new Bagel();
            bagel.ChangeCap(2);
            bagel.AddBagel("BGLO");
            bagel.AddBagel("BGLP");

            Assert.IsTrue( bagel.BasketFull());
        }


    }
}
