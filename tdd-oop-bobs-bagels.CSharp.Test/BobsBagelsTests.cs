using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tdd_oop_bobs_bagels.CSharp.Source;

namespace tdd_oop_bobs_bagels.CSharp.Test
{
    [TestFixture]
    public class BobsBagelsTests
    {
        [Test]
        public void InitialTest()
        {
            Assert.Pass();
        }
        
        [Test]
        public void TestAddBagel()
        {
            //I'd like to add a specific type of bagel to my basket
            BobsBagelsApp _basket = new BobsBagelsApp();
            _basket.AddProduct("COFB");
            Assert.IsTrue(_basket.basket.Any(s => s.SKU =="COFB"));
        }
        [Test]
        public void TestRemoveBagel()
        {
            //I'd like to remove a bagel from my basket
            BobsBagelsApp _basket = new BobsBagelsApp();
            _basket.AddProduct("COFB");
            _basket.AddProduct("BGLE");
            _basket.RemoveProduct("BGLE");
            //Assert.IsFalse(_basket.basket.Contains("BGLE"));
            Assert.IsFalse(_basket.basket.Any(s => s.SKU == "BGLE"));
            Assert.AreEqual(_basket.RemoveProduct("COFB"), "COFB removed");

        }
        [Test]
        public void TestRemoveNonExistingBagel()
        {
            //I'd like to know if I try to remove an item that doesn't exist in my basket.
            BobsBagelsApp _basket = new BobsBagelsApp();
            _basket.AddProduct("COFB");
            _basket.RemoveProduct("COFB");
            Assert.AreEqual(_basket.RemoveProduct("COFB"), "Item not found");
        }

        [Test]
        public void TestBasketCapacityReached()
        {
            //I'd like to know when my basket is full when I try adding an item beyond my basket capacity
            BobsBagelsApp _basket = new BobsBagelsApp();
            _basket.AddProduct("COFB");
            _basket.AddProduct("BGLE");
            _basket.AddProduct("FILX");
            _basket.AddProduct("BGLP");
            Assert.AreEqual(_basket.basket.Count, _basket.MaxCapacityBasket);
        }

        [TestCase(5)]
        public void TestChangeBasketCapacity(int count)
        {
            //I’d like to change the capacity of baskets
            BobsBagelsApp _basket = new BobsBagelsApp();
            _basket.AddProduct("COFB");
            _basket.AddProduct("BGLE");
            _basket.AddProduct("FILX");
            _basket.AddProduct("BGLP");
            _basket.ChangeBasketCapacity(count);
            Assert.AreEqual(_basket.MaxCapacityBasket, 5);
            Assert.AreEqual(_basket.ChangeBasketCapacity(count), $"The new basketsize is {count}");

        }
        [TestCase(2)]
        public void TestChangeBasketCapacity1(int count)
        {
            BobsBagelsApp _basket = new BobsBagelsApp();
            _basket.AddProduct("COFB");
            _basket.AddProduct("BGLE");
            _basket.AddProduct("FILX");
            _basket.AddProduct("BGLP");
            _basket.ChangeBasketCapacity(count);
            Assert.AreEqual(_basket.ChangeBasketCapacity(count), $"There are more items in the basket than {count}");
        }
        
        [TestCase ("COFC", true)]
        public void TestSKU(string SKU, bool expectedResult)
        {
            // I want customers to only be able to order things that we stock in our inventory.
            BobsBagelsApp _basket = new BobsBagelsApp();
            bool result = _basket.AddProduct(SKU);
            Assert.AreEqual(result, expectedResult);
        }
        
    }
}
