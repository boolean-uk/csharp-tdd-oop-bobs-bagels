using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp_tdd_bobs_bagels.tests;
using tdd_bobs_bagels.Main;


namespace csharp_tdd_bobs_bagels.tests
{
    [TestFixture]
    public class BasketTest
    {
        [Test]
        public void TestAddBagelToBasket()
        {
            Basket basket = new Basket(5);
            basket.AddItem("Plain Bagel");
            CollectionAssert.AreEqual(new[] { "Plain Bagel" }, basket.Items);
        }

        [Test]
        public void TestRemoveBagelFromBasket()
        {
            Basket basket = new Basket(5);
            basket.AddItem("Whole Wheat Bagel");
            basket.RemoveItem("Whole Wheat Bagel");
            CollectionAssert.AreEqual(new string[] { }, basket.Items);
        }

        [Test]
        public void TestCheckBasketFull()
        {
            Basket basket = new Basket(2);
            basket.AddItem("Blueberry Bagel");
            basket.AddItem("Cinnamon Raisin Bagel");
            Assert.IsTrue(basket.IsFull());
        }

        [Test]
        public void TestChangeBasketCapacity()
        {
            Basket basket = new Basket(3);
            basket.ChangeCapacity(5);
            Assert.AreEqual(5, basket.Capacity);
        }

        [Test]
        public void TestRemoveNonexistentItem()
        {
            Basket basket = new Basket(5);
           // basket.RemoveItem("Sesame Bagel");
            string nonExistentItem = "Banana";
            Assert.Throws<ArgumentException>(() => basket.RemoveItem(nonExistentItem), "Expected ArgumentException for non-existent item");
        }
    

    }
}
