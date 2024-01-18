using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    public class ExtensionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void SumOfferTotalCost()
        {
            //Arrange
            Basket basket = new Basket();
            double sum = 4.38;
            Product prod = new Product("BGLP", 0.39, "Bagel", "Plain", 13);
            
            basket.addProductToBasket(prod);
            



            //Act
            basket.changeBasketCapacity(10);
            double totalCost = basket.CalculateTotalCost();

            //Assert
            Assert.AreEqual(sum, totalCost);

        }

    }
}
