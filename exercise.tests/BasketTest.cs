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
        public void AddBagelTest(string sku)
        {

            //arrange
            Basket basket = new Basket();

            //act
            basket.AddBagel(sku);
            
            //assert
            Assert.IsTrue(basket.BasketItems.Count > 0);

        }


        [TestCase("BGLO")]
        public void RemoveBagelTest(string sku)
        {
            //arrange
            Basket basket = new Basket();
            basket.AddBagel(sku);

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
            basket.AddBagel("BGLO");
            basket.AddBagel("BGLP");
            basket.AddBagel("BGLE");

            //act
            bool result = basket.IsBasketFull();

            //assert
            Assert.IsTrue(result);

        }

        [TestCase(5)]
        public void ChangeBasketCapacity(int newCapacity)
        {
            //arrange
            Basket basket = new Basket();
            

            //act
            basket.ChangeBasketCapacity(newCapacity);


            //assert
            Assert.Fail();

        }

        [Test]
        public void TotalCostBasket()
        {
            //arrange

            //act

            //assert
            Assert.Fail();
        }

        [Test]
        public void AddFilling()
        {
            //arrange

            //act

            //assert
            Assert.Fail();
        }

        [Test]
        public void CostOfFilling()
        {
            //arrange

            //act

            //assert
            Assert.Fail();
        }

        [Test]
        public void CostOfBagel()
        {
            //arrange

            //act

            //assert
            Assert.Fail();
        }
    }
}
