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
        public void RemoveItemTest(string sku)
        {
            //arrange
            Basket basket = new Basket();
            basket.AddItem(sku);

            //act
            basket.RemoveItem(sku);

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
            basket.AddItem("COFW");
            basket.AddItem("BGLO");
            basket.AddItem("FILE");

            //act
            double result = basket.TotalCostBasket();

            //assert
            Assert.AreEqual(Math.Round(0.12d + 1.25d, 2), result);
        }

        [Test]
        public void BasketDiscountTest()
        {
            //arrange
            Basket basket = new Basket();
            for (int i = 0; i < 6; i++)
            {
                basket.AddItem("BGLO");
            }

            basket.AddItem("COFB");
            for (int i = 0; i < 14; i++)
            {
                basket.AddItem("BGLP");
            }

            basket.AddItem("COFB");


            //act
            double result = basket.TotalCostBasket();

            //assert
            Assert.AreEqual(Math.Round(2.49d + 3.99d + 1.25d + 1.25d, 2), result);

        }
    }
}
