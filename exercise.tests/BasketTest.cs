using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    [TestFixture]
    public class BasketTest
    {
        [TestCase("BGLO")]
        public void AddItemTest(string sku)
        {

            //arrange
            Basket basket = new Basket();

            //act
            basket.AddItem(sku);
            
            //assert
            Assert.IsTrue(basket.BasketItems.Count > 0);

        }


        [TestCase("BGLO")]
        public void RemoveBagelTest(string sku)
        {
            //arrange
            Basket basket = new Basket();
            basket.AddItem(sku);

            //act
            basket.RemoveBagel(sku);

            //assert
            Assert.IsTrue(basket.BasketItems.Count == 0);
        }

        [TestCase(3)]
        public void IsBasketFullTest(int cap)
        {
            //arrange
            Basket basket = new Basket(cap);
            basket.AddItem("BGLO");
            basket.AddItem("BGLP");
            basket.AddItem("BGLE");

            //act
            bool result = basket.IsBasketFull();

            //assert
            Assert.IsTrue(result);

        }

        [TestCase(5)]
        public void ChangeBasketCapacityTest(int newCapacity)
        {
            //arrange
            Basket basket = new Basket();
            

            //act
            basket.ChangeBasketCapacity(newCapacity);


            //assert
            Assert.IsTrue(basket.Capacity == newCapacity);

        }

        [Test]
        public void TotalCostBasketTest()
        {
            //arrange
            Basket basket = new Basket();
            basket.AddItem("BGLO");
            basket.AddItem("COFW");
            basket.AddItem("FILE");

            //act
            double result = basket.TotalCostBasket();

            //assert
            Assert.AreEqual(result, 1.8d);
        }

        [Test]
        public void CostOfBagelTest()
        {
            //arrange
            Basket basket = new Basket();
            basket.AddItem("BGLO");
            basket.AddItem("COFB");
            basket.AddItem("FILB");
            basket.AddItem("FILE");

            //act
            double result = basket.CostOfBagel();


            //assert
            Assert.AreEqual(result, 0.73d);
        }

        [Test]
        public void CostOfFillingTest()
        {
            //arrange
            Basket basket = new Basket();
            basket.AddItem("BGLO");
            basket.AddItem("COFB");
            basket.AddItem("FILB");
            basket.AddItem("FILE");

            //act
            double result = basket.CostOfFilling();

            //assert
            Assert.AreEqual(result, 0.24d);
        }
    }
}
